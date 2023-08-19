using System.Collections;
using UnityEngine;

namespace Game.Core.EndGame
{
	[RequireComponent(typeof(AudioSource))]
	public class EndGameSoundFX : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;
		private WaitForSeconds _tick = new WaitForSeconds(0.1f);
		private float _targetTimer;

		public void StartSoundFX() => StartCoroutine(SoundScore());

		private IEnumerator SoundScore() {
			_targetTimer = 0f;
			_audioSource.pitch = 1f;
			while (_targetTimer <=2.5f) {
				_audioSource.Play();
				_audioSource.pitch += 0.1f;
				_targetTimer += 0.1f;
				yield return _tick;
			}
		}
	}
}