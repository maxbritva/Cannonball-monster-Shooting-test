using Game.Booster;
using Game.Core.Shop;
using Game.FX.DamageText;
using Game.FX.HitEffect;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Player.Ball
{
	[RequireComponent(typeof(AudioSource))]
	public class BallCollision : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;
		private int _damage;
		private ScoreCollector _scoreCollector;	
		private UpgradeLoader _upgradeLoader;	
		private DamageTextSpawner _damageTextSpawner;	
		private HitEffectSpawner _hitEffectSpawner;
		
		private void OnTriggerEnter(Collider other)
		{
			_audioSource.Play();
			if (other.TryGetComponent(out Enemy.EnemyBase enemy))
			{
				int randomDamage = RandomDamage();
				enemy.TakeDamage(randomDamage);
				_damageTextSpawner.Activate(transform, randomDamage);
				gameObject.SetActive(false);
				_hitEffectSpawner.Activate(transform);
			}
			if (other.TryGetComponent(out DeadZone deadZone))
				gameObject.SetActive(false);
			if (other.TryGetComponent(out Floor background))
			{
				gameObject.SetActive(false);
				_hitEffectSpawner.Activate(transform);
			}
			if (other.TryGetComponent(out IBooster booster))
			{
				booster.Activate();
				_scoreCollector.AddScore(20);
				gameObject.SetActive(false);
				_hitEffectSpawner.Activate(transform);
			}
		}
		
		[Inject] private void Construct(PlayerData playerData, ScoreCollector scoreCollector, 
			UpgradeLoader upgradeLoader, DamageTextSpawner damageTextSpawner, HitEffectSpawner hitEffectSpawner)
		{
			_scoreCollector = scoreCollector;
			_upgradeLoader = upgradeLoader;
			_damageTextSpawner = damageTextSpawner;
			_hitEffectSpawner = hitEffectSpawner;
		}
		private int RandomDamage() => (int)Random.Range(_upgradeLoader.DamageCurrentLevel.Value / 2f, (_upgradeLoader.DamageCurrentLevel.Value * 1.5f));
	}
}

