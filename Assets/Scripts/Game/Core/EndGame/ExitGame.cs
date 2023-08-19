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

		public void Calculate() {
			if (_overAnimator.TargetScore > _playerData.TopScore) 
				_playerData.SetTopScore(_overAnimator.TargetScore);
			if (_overAnimator.Coins > 0)
				_playerData.SetCoins(_overAnimator.Coins);
			_gameManager.ReturnToMenu();
		}
		
		[Inject] private void Construct(GameOverAnimator gameOverAnimator, PlayerData playerData, GameManager gameManager)
		{
			_overAnimator = gameOverAnimator;
			_playerData = playerData;
			_gameManager = gameManager;
		}

	}
}