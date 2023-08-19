using System.Collections.Generic;
using UnityEngine;

namespace Game.FX
{
	public class DestroyEffectGenerator : MonoBehaviour
	{
		[SerializeField] private GameObject _effectPrefab;
		private const int DefaultCount = 3;
		private List<GameObject> _effectsPool = new List<GameObject>();

		private void Awake() {
			for (int i = 0; i < DefaultCount; i++) {
				CreateEffect();
			}
		}

		private GameObject CreateEffect() {
			GameObject effect = Instantiate(_effectPrefab.gameObject, transform);
			effect.gameObject.SetActive(false);
			_effectsPool.Add(effect);
			return effect;
		}

		public GameObject GetEffectFromPool() {
			for (int i = 0; i < _effectsPool.Count; i++) {
				if (_effectsPool[i].activeInHierarchy == false) {
					return _effectsPool[i];
				}
			}
			GameObject effectFromPool = CreateEffect();
			effectFromPool.gameObject.SetActive(true);
			return effectFromPool;
		}

		public void HideAll() {
			for (int i = 0; i < _effectsPool.Count; i++) {
				if (_effectsPool[i].activeInHierarchy) {
					 _effectsPool[i].SetActive(false);
				}
			}
		}
	}
}