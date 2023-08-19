using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Booster
{
	public class BoosterSpawner : MonoBehaviour
	{
		[SerializeField] private List<GameObject> _boosters = new List<GameObject>();
		[SerializeField] private Transform _rootTransform;
		[Inject] private DiContainer _diContainer;
		private List<GameObject> _boostersPool = new List<GameObject>();
		private readonly WaitForSeconds _waitBeforeSpawn = new WaitForSeconds(3f);
		private readonly WaitForSeconds _waitBetweenSpawn = new WaitForSeconds(10f);
		private readonly WaitForSeconds _oneTick = new WaitForSeconds(2f);
		private int _moveCounter = 0;
		
		private void Start() {
			for (int i = 0; i < _boosters.Count; i++) 
			{
				GameObject newBonus = _diContainer.InstantiatePrefab(_boosters[i],transform);
				newBonus.gameObject.SetActive(false);
				_boostersPool.Add(newBonus);
			}
		}

		public void ActivateSpawner() => StartCoroutine(StartBoosterSpawn());

		public void Deactivate() => StopCoroutine(StartBoosterSpawn());

		private IEnumerator StartBoosterSpawn()
		{
			yield return _waitBeforeSpawn;
			while (true)
			{
				GameObject bonus = GetBonus();
				bonus.transform.position = RandomSpawn();
				bonus.SetActive(true);
				StartCoroutine(MoveBonus(bonus));
				yield return _waitBetweenSpawn;
			}
		}
		
		private GameObject GetBonus() {
			GameObject bonus = _boostersPool[Random.Range(0,_boostersPool.Count)].gameObject;
			if( bonus.activeInHierarchy == false)
				return bonus;
			bonus.SetActive(false);
				return bonus;
		}
		private Vector3 RandomSpawn() => _rootTransform.position + (Vector3)Random.insideUnitCircle * 5f;

		private IEnumerator MoveBonus(GameObject targetBonus) 
		{
			for ( _moveCounter = 0; _moveCounter < 3; _moveCounter++) 
			{
				targetBonus.gameObject.transform.position = RandomSpawn();
				yield return _oneTick;	
			}
			targetBonus.SetActive(false);
		}
	}
}