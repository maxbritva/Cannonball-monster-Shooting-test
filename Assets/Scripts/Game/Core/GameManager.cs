using Game.Core.EndGame;
using UnityEngine;
using Zenject;

namespace Game.Core
{
	public enum GameStates
	{
		Menu,Game,EndGame
	}
	
	public class GameManager : MonoBehaviour
	{
		private GameStateChanger _gameStateChanger;
		private MenuStateChanger _menuStateChanger;
		private GameOverAnimator _gameOverAnimator;

		[Inject] private void Construct(GameStateChanger gameStateChanger, MenuStateChanger menuStateChanger, GameOverAnimator gameOverAnimator)
		{
			_gameStateChanger = gameStateChanger;
			_menuStateChanger = menuStateChanger;
			_gameOverAnimator = gameOverAnimator;
		}
		private void Awake() => SetState(GameStates.Menu);

		private void SetState(GameStates currentState)
		{
			if (currentState == GameStates.Menu) 
				_menuStateChanger.BackToMenu();
			if (currentState == GameStates.Game) 
				_gameStateChanger.StartGame();
			if (currentState == GameStates.EndGame) 
				_gameOverAnimator.Initialize();
		}
		public void StartGame() => SetState(GameStates.Game);
		public void ReturnToMenu() => SetState(GameStates.Menu);
		public void EndGame() => SetState(GameStates.EndGame);
	}
}