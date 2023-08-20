using Game.Enemy.Spawner;
using Game.LevelSystem;
using Game.Player.Ball;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
	public class EnemyInstaller : MonoInstaller
	{
		[SerializeField] private Explode _explode;
		[SerializeField] private SpawnPosition _spawnPosition;
		[SerializeField] private EnemyCounter _enemyCounter;
		[SerializeField] private EnemySpawner _enemySpawner;
		[SerializeField] private LevelWaves _levelWaves;
		
		public override void InstallBindings() => EnemyInstall();

		private void EnemyInstall()
		{
			Container.Bind<Explode>().FromInstance(_explode).AsSingle().NonLazy();
			Container.Bind<SpawnPosition>().FromInstance(_spawnPosition).AsSingle().NonLazy();
			Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle().NonLazy();
			Container.Bind<EnemyCounter>().FromInstance(_enemyCounter).AsSingle().NonLazy();
			Container.Bind<LevelWaves>().FromInstance(_levelWaves).AsSingle().NonLazy();
		}
	}
}