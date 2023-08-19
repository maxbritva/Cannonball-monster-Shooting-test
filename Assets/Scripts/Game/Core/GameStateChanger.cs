using System.Collections;
using Game.Booster;
using Game.Core.EndGame;
using Game.Enemy.Spawner;
using Game.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Core
{
	public class GameStateChanger : MonoBehaviour
	{
		[SerializeField] private Text _startAnimationText;
		[SerializeField] private GameObject _gameUI;
		[SerializeField] private GameObject _menuUI;
		private LevelSystem.LevelSystem _levelSystem;
		private BoosterSpawner _boosterSpawner;
		private EnemySpawner _enemySpawner;
		private PlayerInput _playerInput;
		private GameManager _gameManager;
		private ObjectPool _objectPool;
		private WaitForSeconds _tick = new WaitForSeconds(1f);

		[Inject] private void Construct(LevelSystem.LevelSystem levelSystem, BoosterSpawner boosterSpawner, 
			EnemySpawner enemySpawner, PlayerInput playerInput, GameManager gameManager, ObjectPool objectPool)
		{
			_levelSystem = levelSystem;
			_boosterSpawner = boosterSpawner;
			_enemySpawner = enemySpawner;
			_playerInput = playerInput;
			_gameManager = gameManager;
			_objectPool = objectPool;
		}
		public void StartGame() => StartCoroutine(GameStartAnimation());

		private IEnumerator GameStartAnimation()
		{
			_menuUI.SetActive(false);
			_gameUI.SetActive(true);
			_levelSystem.ResetLevel();
			_startAnimationText.gameObject.SetActive(true);
			for (int i = 3; i > 0; i--)
			{
				_startAnimationText.text = i.ToString();
				yield return _tick;
			}
			_startAnimationText.gameObject.SetActive(false);
			InitializeCore();
		}

		private void InitializeCore()
		{
			_levelSystem.ActivateLevelTimer();
			_boosterSpawner.ActivateSpawner();
			_enemySpawner.ActivateSpawn();
			_playerInput.DisableCannon(false);
		}

		public void InitializeGameOver()
		{
			_levelSystem.DeactivateLevelTimer();
			_boosterSpawner.Deactivate();
			_enemySpawner.DeactivateAll();
			_objectPool.GetActive(true);
			_playerInput.DisableCannon(true);
			_gameUI.SetActive(false);
			_gameManager.EndGame();
		}
	}
}