using System;
using System.Collections;
using UnityEngine;

namespace Game.FX.DestroyEffect
{
	public class DestroyEffectHide : MonoBehaviour
	{
		private WaitForSeconds _wait;
		private void Awake() {
			_wait = new WaitForSeconds(2.2f);
		}
		private void OnEnable() {
			StartCoroutine(Hide());
		}
		private IEnumerator Hide() {
			yield return _wait;
			gameObject.SetActive(false);
		}
	}
}