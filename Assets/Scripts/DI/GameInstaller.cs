using Game.Booster;
using Game.Core;
using Game.Core.EndGame;
using Game.Enemy.Spawner;
using Game.LevelSystem;
using Game.Player;
using Game.Player.Ball;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private BallPool _ballPool;
		[SerializeField] private PlayerData _playerData;
		[SerializeField] private PlayerInput _playerInput;
		[SerializeField] private Shoot _shoot;
		[SerializeField] private Explode _explode;
		[SerializeField] private SpawnPosition _spawnPosition;
		[SerializeField] private EnemyCounter _enemyCounter;
		[SerializeField] private EnemySpawner _enemySpawner;
		[SerializeField] private GameOverAnimator _gameOverAnimator;
		[SerializeField] private ObjectPool _objectPool;
		[SerializeField] private LevelWaves _levelWaves;
		[SerializeField] private LevelSystem _levelSystem;
		[SerializeField] private ScoreCollector _scoreCollector;
		[SerializeField] private GameStateChanger _gameStateChanger;
		[SerializeField] private BoosterSpawner _boosterSpawner;
		[SerializeField] private EndGameSoundFX _soundFX;
		[SerializeField] private MenuStateChanger _menuStateChanger;
		[SerializeField] private GameManager _gameManager;
		public override void InstallBindings()
		{
			PlayerInstall();
			EnemyInstall();
			GameInstall();
		}

		private void PlayerInstall()
		{
			Container.Bind<PlayerInput>().FromInstance(_playerInput).AsSingle().NonLazy();
			Container.Bind<Shoot>().FromInstance(_shoot).AsSingle().NonLazy();
			Container.Bind<BallPool>().FromInstance(_ballPool).AsSingle().NonLazy();
			Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle().NonLazy();
		}
		
		private void EnemyInstall()
		{
			Container.Bind<Explode>().FromInstance(_explode).AsSingle().NonLazy();
			Container.Bind<SpawnPosition>().FromInstance(_spawnPosition).AsSingle().NonLazy();
			Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle().NonLazy();
		}
		
		private void GameInstall()
		{
			Container.Bind<ObjectPool>().FromInstance(_objectPool).AsSingle().NonLazy();
			Container.Bind<GameOverAnimator>().FromInstance(_gameOverAnimator).AsSingle().NonLazy();
			Container.Bind<EnemyCounter>().FromInstance(_enemyCounter).AsSingle().NonLazy();
			Container.Bind<LevelWaves>().FromInstance(_levelWaves).AsSingle().NonLazy();
			Container.Bind<LevelSystem>().FromInstance(_levelSystem).AsSingle().NonLazy();
			Container.Bind<ScoreCollector>().FromInstance(_scoreCollector).AsSingle().NonLazy();
			Container.Bind<GameStateChanger>().FromInstance(_gameStateChanger).AsSingle().NonLazy();
			Container.Bind<BoosterSpawner>().FromInstance(_boosterSpawner).AsSingle().NonLazy();
			Container.Bind<EndGameSoundFX>().FromInstance(_soundFX).AsSingle().NonLazy();
			Container.Bind<MenuStateChanger>().FromInstance(_menuStateChanger).AsSingle().NonLazy();
			Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle().NonLazy();
		}
	}
}