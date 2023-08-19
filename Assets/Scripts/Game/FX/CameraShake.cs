using System.Collections;
//using Cinemachine;
using UnityEngine;

namespace Game.FX
{
	public class CameraShake : MonoBehaviour
	{
		//[SerializeField] private CinemachineVirtualCamera _cinemachineVirtual;
		private readonly float _shakeIntensity = 3f;
		//private CinemachineBasicMultiChannelPerlin _channelPerlin;
		private void Start() {
		//	_channelPerlin = _cinemachineVirtual.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
			StopShake();
		}

		private void StartShake() {
		//	_channelPerlin.m_AmplitudeGain = _shakeIntensity;
		}

		private void StopShake() {
			//_channelPerlin.m_AmplitudeGain = 0f;
		}
		
		public IEnumerator ShakeCamera() {
			StartShake();
			yield return new WaitForSeconds(1f);
			StopShake();
		}
	}
}