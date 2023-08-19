using UnityEngine;

namespace Game.FX.DestroyEffect
{
	[RequireComponent(typeof(DestroyEffectGenerator))]
	public class DestroyEffectSpawner : MonoBehaviour
	{
		[SerializeField] private DestroyEffectGenerator _destroyEffectGenerator;

		private void OnEnable() {
			DestroyEffect.OnEffectActivated += Activate;
		}

		private void OnDisable() {
			DestroyEffect.OnEffectActivated -= Activate;
		}

		private void Activate(Transform target) {
			GameObject effect = _destroyEffectGenerator.GetEffectFromPool();
			effect.transform.position = target.position;
			effect.SetActive(true);
		}
	}
}