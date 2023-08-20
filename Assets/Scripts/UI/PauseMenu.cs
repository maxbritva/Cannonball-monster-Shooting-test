using UnityEngine;

namespace UI
{
	public class PauseMenu : MonoBehaviour
	{
		private void OnEnable() => SetPause(true);
		private void OnDisable() => SetPause(false);
		private void SetPause(bool isPaused) => Time.timeScale = isPaused ? 0 : 1;
	}
}