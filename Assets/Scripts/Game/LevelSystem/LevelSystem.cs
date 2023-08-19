using System.Collections;
using Game.Enemy.Spawner;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.LevelSystem
{
	public class LevelSystem : MonoBehaviour
	{
		[SerializeField] private Image _levelBar;
		[SerializeField] private Text _text;
		private LevelWaves _levelWaves;
		private EnemySpawner _enemySpawner;
		private Coroutine _levelTimer;
		private readonly WaitForSeconds _tick = new WaitForSeconds(1f);
		private const float AllLevelTime = 30f;
		private float _timer = 1f;
		private int _levelCounter = 1;
		public int LevelCounter => _levelCounter;

		public void ActivateLevelTimer() => _levelTimer = StartCoroutine(LevelTimer());

		public void DeactivateLevelTimer() {
			if(_levelTimer != null)
				StopCoroutine(_levelTimer);
			_levelCounter = 1;
			_timer = 0f;
			_levelBar.fillAmount = 0f;
			_text.text = _levelCounter.ToString();
		}
		public void ResetLevel()
		{
			
		}

		[Inject] private void Construct(LevelWaves levelWaves, EnemySpawner enemySpawner)
		{
			_levelWaves = levelWaves;
			_enemySpawner = enemySpawner;
		}

		private IEnumerator LevelTimer()
		{
			while (true)
			{
				_levelBar.fillAmount = _timer/AllLevelTime;
				if (_levelBar.fillAmount == 1f) {
					_levelBar.fillAmount = 0f;
					_timer = 0f;
					LevelUp();
				}
				yield return _tick;
				_timer++;
			}
		}

		private void LevelUp()
		{
			_levelCounter++;
			_text.text = _levelCounter.ToString();
			_levelWaves.NextLevel();
			_enemySpawner.ReloadIntervals();
		}
	}
}