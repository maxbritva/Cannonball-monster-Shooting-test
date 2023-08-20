using Game.Booster;
using Game.Core;
using Game.Core.EndGame;
using Game.Core.Shop;
using Game.FX.DamageText;
using Game.FX.HitEffect;
using Game.LevelSystem;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private GameOverAnimator _gameOverAnimator;
		[SerializeField] private ObjectPool _objectPool;
		[SerializeField] private LevelSystem _levelSystem;
		[SerializeField] private ScoreCollector _scoreCollector;
		[SerializeField] private GameStateChanger _gameStateChanger;
		[SerializeField] private BoosterSpawner _boosterSpawner;
		[SerializeField] private EndGameSoundFX _soundFX;
		[SerializeField] private MenuStateChanger _menuStateChanger;
		[SerializeField] private GameManager _gameManager;
		[SerializeField] private MenuUIUpdater _menuUIUpdater;
		[SerializeField] private Shop _shop;
		[SerializeField] private UpgradeLoader _upgradeLoader;
		[SerializeField] private DamageTextSpawner _damageTextSpawner;
		[SerializeField] private HitEffectSpawner _hitEffectSpawner;
		[SerializeField] private SaveSystem _saveSystem;
		public override void InstallBindings() => GameInstall();
		
		private void GameInstall()
		{
			Container.Bind<ObjectPool>().FromInstance(_objectPool).AsSingle().NonLazy();
			Container.Bind<GameOverAnimator>().FromInstance(_gameOverAnimator).AsSingle().NonLazy();
			Container.Bind<LevelSystem>().FromInstance(_levelSystem).AsSingle().NonLazy();
			Container.Bind<ScoreCollector>().FromInstance(_scoreCollector).AsSingle().NonLazy();
			Container.Bind<GameStateChanger>().FromInstance(_gameStateChanger).AsSingle().NonLazy();
			Container.Bind<BoosterSpawner>().FromInstance(_boosterSpawner).AsSingle().NonLazy();
			Container.Bind<EndGameSoundFX>().FromInstance(_soundFX).AsSingle().NonLazy();
			Container.Bind<MenuStateChanger>().FromInstance(_menuStateChanger).AsSingle().NonLazy();
			Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle().NonLazy();
			Container.Bind<MenuUIUpdater>().FromInstance(_menuUIUpdater).AsSingle().NonLazy();
			Container.Bind<Shop>().FromInstance(_shop).AsSingle().NonLazy();
			Container.Bind<UpgradeLoader>().FromInstance(_upgradeLoader).AsSingle().NonLazy();
			Container.Bind<DamageTextSpawner>().FromInstance(_damageTextSpawner).AsSingle().NonLazy();
			Container.Bind<HitEffectSpawner>().FromInstance(_hitEffectSpawner).AsSingle().NonLazy();
			Container.Bind<SaveSystem>().FromInstance(_saveSystem).AsSingle().NonLazy();
		}
	}
}