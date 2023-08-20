using Game.Player;
using Game.Player.Ball;
using UnityEngine;
using Zenject;

namespace DI
{
	public class PlayerInstaller : MonoInstaller
	{
		[SerializeField] private BallPool _ballPool;
		[SerializeField] private PlayerData _playerData;
		[SerializeField] private PlayerInput _playerInput;
		[SerializeField] private Shoot _shoot;
		
		public override void InstallBindings() => PlayerInstall();

		private void PlayerInstall()
		{
			Container.Bind<PlayerInput>().FromInstance(_playerInput).AsSingle().NonLazy();
			Container.Bind<Shoot>().FromInstance(_shoot).AsSingle().NonLazy();
			Container.Bind<BallPool>().FromInstance(_ballPool).AsSingle().NonLazy();
			Container.Bind<PlayerData>().FromInstance(_playerData).AsSingle().NonLazy();
		}
	}
}