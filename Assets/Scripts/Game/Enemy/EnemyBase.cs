using System;
using System.Threading.Tasks;
using Game.Core;
using Game.LevelSystem;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	public abstract class EnemyBase : MonoBehaviour, IDamageable
	{
		protected Action OnEndedHealth;
		[SerializeField] private int _baseHealth;
		[SerializeField] private int _currentHealth;
		private EnemyCounter _enemyCounter;
		private LevelWaves _levelWaves;
		private ScoreCollector _scoreCollector;	
		private int _maxHealth;
		private bool _firstSpawn = true;

		protected virtual void OnEnable()
		{
			if(_firstSpawn == false)
				SetMaxHealth();
			else
				_currentHealth = _maxHealth = _baseHealth;
			_firstSpawn = false;
			_currentHealth = _maxHealth;
			transform.GetComponent<Rigidbody>().isKinematic = true;
		}

		[Inject] private void Construct(EnemyCounter enemyCounter, LevelWaves levelWaves, ScoreCollector scoreCollector)
		{
			_enemyCounter = enemyCounter;
			_levelWaves = levelWaves;
			_scoreCollector = scoreCollector;
		}

		public void TakeDamage(int value)
		{
			value = Mathf.Clamp(value, 0, 1000);
			_currentHealth -= value;
			if (_currentHealth > 0) return;
			OnEndedHealth?.Invoke();
			_enemyCounter.SetCurrentEnemyInGame(-1);
			_enemyCounter.OnChange?.Invoke();
			_scoreCollector.AddScore(50);
		}

		protected virtual void Defeated()
		{
			transform.GetComponent<Rigidbody>().isKinematic = false;
			TimerToHide();
		}

		private async void TimerToHide()
		{
			await Task.Delay(2000);
			if(gameObject)
				gameObject.SetActive(false);
		}

		private void SetMaxHealth() => _maxHealth = _baseHealth + _levelWaves.CurrentLevelSettings.EnemyHealthBonus;
	}
}