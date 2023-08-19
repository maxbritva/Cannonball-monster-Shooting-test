using System.Collections;
using UnityEngine;

namespace Game.Core
{
	public class Rotate : MonoBehaviour
	{
		[SerializeField] private Vector3 _rotationByUser;
		[SerializeField] private bool _isRandom;
		private Vector3 _rotation;

		private void OnEnable() => StartCoroutine(StartRotation());

		private IEnumerator StartRotation()
		{
			_rotation = _isRandom ? new Vector3(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f)) : _rotationByUser;
			while (true) {
				transform.Rotate(_rotation * Time.deltaTime);
				yield return null;
			}
		}
	}
}