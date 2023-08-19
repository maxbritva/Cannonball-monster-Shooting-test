using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ScoreCollector : MonoBehaviour
	{
		[SerializeField] private Text _textCounter;
		private int _scoreCounter;
		public int ScoreCounter => _scoreCounter;

		private void ShowUi() => _textCounter.text = _scoreCounter.ToString();
		public void AddScore(int value)
		{
			if (value <= 0)
				throw new ArgumentOutOfRangeException("Score value must be more  than 0");
			_scoreCounter += value;
			ShowUi();
		}
	}
}