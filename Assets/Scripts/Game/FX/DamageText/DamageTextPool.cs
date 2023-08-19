using System.Collections.Generic;
using UnityEngine;

namespace Game.FX.DamageText
{
	public class DamageTextPool : MonoBehaviour
	{
		[SerializeField] private GameObject _damageEffectPrefab;
		private const int DefaultCount = 3;
		private List<GameObject> _damageTextEffectsPool = new List<GameObject>();

		private void Awake() {
			for (int i = 0; i < DefaultCount; i++) {
				CreateEffect();
			}
		}

		private GameObject CreateEffect() {
			GameObject effect = Instantiate(_damageEffectPrefab.gameObject, transform);
			effect.gameObject.SetActive(false);
			_damageTextEffectsPool.Add(effect);
			return effect;
		}

		public GameObject GetEffectFromPool() {
			for (int i = 0; i < _damageTextEffectsPool.Count; i++) {
				if (_damageTextEffectsPool[i].activeInHierarchy == false) {
					return _damageTextEffectsPool[i];
				}
			}
			GameObject effectFromPool = CreateEffect();
			effectFromPool.gameObject.SetActive(true);
			return effectFromPool;
		}
	}
}