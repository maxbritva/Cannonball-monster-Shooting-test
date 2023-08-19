using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Core.EndGame
{
	public class GameOverAnimator : MonoBehaviour
	{
		[SerializeField] private GameObject _gameOverUI;
		[SerializeField] private Text _scoreText;
		[SerializeField] private Text _coinsText;
		[SerializeField] private Button _extraCoins;
		[SerializeField] private Button _exit;
		private EndGameSoundFX _endGameSoundFX;
		private ScoreCollector _scoreCollector;
		private const float AnimationDuration = 2.5f;
		private int _targetScore;
		private int _currentScore;
		private int _coins;
		private WaitForSeconds _interval;

		public int TargetScore => _targetScore;
		public int Coins => _coins;

		public void Initialize()
		{
			Init();
			_gameOverUI.SetActive(true);
			if (_targetScore > 0)
				StartCoroutine(StartCalculating());
			else
				ButtonsActivate(false, true);
		}

		[Inject] private void Construct(EndGameSoundFX endGameSoundFX, ScoreCollector scoreCollector)
		{
			_endGameSoundFX = endGameSoundFX;
			_scoreCollector = scoreCollector;
		}
		
		private void OnEnable()
		{
			Init();
		}

		private void Init()
		{
			ButtonsActivate(false, false);
			_targetScore = _scoreCollector.ScoreCounter;
			_currentScore = 0;
			_coins = _targetScore / 100;
			_scoreText.text = _currentScore.ToString();
			_interval = new WaitForSeconds(2.6f);
		}

		private void ButtonsActivate(bool valueExtra, bool valueExit) {
			_extraCoins.gameObject.SetActive(valueExtra);
			_exit.gameObject.SetActive(valueExit);
		}
		private IEnumerator StartCalculating() {
			StartCoroutine(CountUp(_targetScore, _currentScore, _scoreText));
			yield return _interval;
			StartCoroutine(CountUp(_coins, _targetScore, _coinsText));
			yield return _interval;
			ButtonsActivate(true, true);
			_extraCoins.interactable = true;
			_exit.interactable = true;
		}
		private IEnumerator CountUp(float targetValue, float currentValue, Text targetText) {
			_endGameSoundFX.StartSoundFX();
			float rate = Mathf.Abs(targetValue - currentValue) / AnimationDuration;
			while (currentValue != targetValue) {
				currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);
				targetText.text = ((int)currentValue).ToString();
				yield return null;
			}
		}
	}
}