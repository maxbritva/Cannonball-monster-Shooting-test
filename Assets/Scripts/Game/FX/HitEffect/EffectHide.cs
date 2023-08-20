using System.Collections;
using UnityEngine;

namespace Game.FX.HitEffect
{
	public class EffectHide : MonoBehaviour
	{
		private WaitForSeconds _wait = new WaitForSeconds(2.2f);

		private void OnEnable() => StartCoroutine(Hide());

		private IEnumerator Hide() {
			yield return _wait;
			gameObject.SetActive(false);
		}
	}
}