using Game.Enemy;
using Game.Player;
using Game.Player.Ball;
using UnityEngine;
using Zenject;

namespace DI
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private BallPool _ballPool;
		[SerializeField] private PlayerInput _playerInput;
		[SerializeField] private Shoot _shoot;
		[SerializeField] private Explode _explode;
		[SerializeField] private PatrolPoints _patrolPoints;
		public override void InstallBindings()
		{
			PlayerInstall();
			EnemyInstall();
		}

		private void PlayerInstall()
		{
			Container.Bind<PlayerInput>().FromInstance(_playerInput).AsSingle().NonLazy();
			Container.Bind<Shoot>().FromInstance(_shoot).AsSingle().NonLazy();
			Container.Bind<BallPool>().FromInstance(_ballPool).AsSingle().NonLazy();
		}
		
		private void EnemyInstall()
		{
			Container.Bind<Explode>().FromInstance(_explode).AsSingle().NonLazy();
			Container.Bind<PatrolPoints>().FromInstance(_patrolPoints).AsSingle().NonLazy();
		}
	}
}