using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.EndGame
{
	public class ExitGame : MonoBehaviour
	{
		private GameOverAnimator _overAnimator;
		private PlayerData _playerData;
		private GameManager _gameManager;
		private SaveSystem _saveSystem;

		public void Calculate() {
			if (_overAnimator.TargetScore > _playerData.TopScore) 
				_playerData.CompareTopScore(_overAnimator.TargetScore);
			if (_overAnimator.Coins > 0)
				_playerData.AddSpendCoins(_overAnimator.Coins);
			_gameManager.ReturnToMenu();
			_saveSystem.SaveData();
		}
		
		[Inject] private void Construct(GameOverAnimator gameOverAnimator, PlayerData playerData, GameManager gameManager, SaveSystem saveSystem)
		{
			_overAnimator = gameOverAnimator;
			_saveSystem = saveSystem;
			_playerData = playerData;
			_gameManager = gameManager;
		}

	}
}