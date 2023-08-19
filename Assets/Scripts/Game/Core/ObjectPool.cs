using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Core
{
	public class ObjectPool : MonoBehaviour
	{
		[Header("Prefabs")]
		[SerializeField] private GameObject _turtlePrefab;
		[SerializeField] private GameObject _eyePrefab;
		[SerializeField] private GameObject _explosionFXPrefab;
		[SerializeField] private GameObject _damageFx;
		
		[Inject] private DiContainer _diContainer;
		private List<GameObject> _turtlePool = new List<GameObject>();
		private List<GameObject> _eyePool = new List<GameObject>();
		private List<GameObject> _explosionFXPool = new List<GameObject>();
		private List<GameObject> _damageFxPool = new List<GameObject>();
		private const int StartCount = 2;
		private GameObject _targetPrefab;
		private List<GameObject> _targetPool;
		private int _count;


		private void Awake()
		{
			PoolInitialize(_turtlePrefab,_turtlePool);
			PoolInitialize(_eyePrefab,_eyePool);
		}

		public GameObject GetObjectFromPool(int id)
		{
			switch (id)
			{
				case 1:
					_targetPrefab = _turtlePrefab;
					_targetPool = _turtlePool;
					break;
				case 2:
					_targetPrefab = _eyePrefab;
					_targetPool = _eyePool;
					break;
				case 3:
					_targetPrefab = _explosionFXPrefab;
					_targetPool = _explosionFXPool;
					break;
				case 4:
					_targetPrefab = _damageFx;
					_targetPool = _damageFxPool;
					break;
			}
			
			for (int i = 0; i < _targetPool.Count; i++) 
			{
				if (_targetPool[i].gameObject.activeInHierarchy == false) {
					_targetPool[i].gameObject.SetActive(true);
					return _targetPool[i]; 
				}
			}
			GameObject newObject = SpawnObject(_targetPrefab, _targetPool);
			newObject.gameObject.SetActive(true);
			return newObject;
		}

		private void PoolInitialize(GameObject targetPrefab, List<GameObject> targetPool) 
		{
			for (int i = 0; i < StartCount; i++) 
				SpawnObject(targetPrefab, targetPool);
		}

		private GameObject SpawnObject(GameObject targetPrefab, List<GameObject> targetPool) 
		{
			GameObject newObject = _diContainer.InstantiatePrefab(targetPrefab, transform);
			targetPool.Add(newObject);
			newObject.gameObject.SetActive(false);
			return newObject;
		}

		public int GetActive(bool needToDeactivate)
		{
			_count = 0;
			for (int i = 0; i < _turtlePool.Count; i++)
			{
				if (_turtlePool[i].gameObject.activeInHierarchy)
				{
					_count++;
					if (needToDeactivate) 
						_turtlePool[i].SetActive(false);
				}
			}
			for (int i = 0; i < _eyePool.Count; i++)
			{
				if (_eyePool[i].gameObject.activeInHierarchy)
				{
					_count++;
					if (needToDeactivate) 
						_eyePool[i].SetActive(false); // EFFECT
				}
			}
			return _count;
		}
	}
}