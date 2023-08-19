using Game.Core;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Player.Ball
{
	
	public class BallCollision : MonoBehaviour
	{
		private int _damage;
		private PlayerData _playerData;
		private ScoreCollector _scoreCollector;	
		[Inject] private void Construct(PlayerData playerData, ScoreCollector scoreCollector)
		{
			_playerData = playerData;
			_scoreCollector = scoreCollector;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Enemy.EnemyBase enemy))
			{
				enemy.TakeDamage(RandomDamage());
				gameObject.SetActive(false);
				// effect
			}

			if (other.TryGetComponent(out DeadZone deadZone))
				gameObject.SetActive(false);
			if (other.TryGetComponent(out Background background))
			{
				gameObject.SetActive(false);
				// effect
			}

			if (other.TryGetComponent(out IBooster booster))
			{
				booster.Activate();
				_scoreCollector.AddScore(20);
				gameObject.SetActive(false);
				// effect
			}
		}
		private int RandomDamage() => (int)Random.Range(_playerData.Damage / 2f, (_playerData.Damage * 1.5f));
	}
}

