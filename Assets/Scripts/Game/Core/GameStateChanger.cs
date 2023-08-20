using System.Collections;
using Game.Booster;
using Game.Enemy.Spawner;
using Game.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Core
{
	[RequireComponent(typeof(AudioSource))]
	public class GameStateChanger : MonoBehaviour
	{
		[SerializeField] private Text _startAnimationText;
		[SerializeField] private GameObject _gameUI;
		[SerializeField] private GameObject _menuUI;
		[SerializeField] private AudioSource _audioSource;
		private LevelSystem.LevelSystem _levelSystem;
		private BoosterSpawner _boosterSpawner;
		private EnemySpawner _enemySpawner;
		private PlayerInput _playerInput;
		private GameManager _gameManager;
		private ObjectPool _objectPool;
		private MenuStateChanger _menuStateChanger;
		private WaitForSeconds _tick = new WaitForSeconds(1f);

		[Inject] private void Construct(LevelSystem.LevelSystem levelSystem, BoosterSpawner boosterSpawner, 
			EnemySpawner enemySpawner, PlayerInput playerInput, GameManager gameManager, ObjectPool objectPool, MenuStateChanger menuStateChanger)
		{
			_levelSystem = levelSystem;
			_boosterSpawner = boosterSpawner;
			_enemySpawner = enemySpawner;
			_playerInput = playerInput;
			_gameManager = gameManager;
			_objectPool = objectPool;
			_menuStateChanger = menuStateChanger;
		}
		public void StartGame() => StartCoroutine(GameStartAnimation());

		private IEnumerator GameStartAnimation()
		{
			_menuStateChanger.AudioSource.Stop();
			_audioSource.Play();
			_menuUI.SetActive(false);
			_gameUI.SetActive(true);
			_startAnimationText.gameObject.SetActive(true);
			for (int i = 3; i > 0; i--)
			{
				_startAnimationText.text = i.ToString();
				yield return _tick;
			}
			_startAnimationText.gameObject.SetActive(false);
			InitializeCore();
		}

		public void InitializeCore()
		{
			_levelSystem.ActivateLevelTimer();
			_boosterSpawner.ActivateSpawner();
			_enemySpawner.ActivateSpawn();
			_playerInput.DisableCannon(false);
		}

		public void InitializeGameOver()
		{
			_audioSource.Stop();
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