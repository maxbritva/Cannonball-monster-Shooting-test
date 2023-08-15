using UnityEngine;
using UnityEngine.Events;

namespace Game.Enemy
{
	public abstract class EnemyBase : MonoBehaviour, IDamageable
	{
		[SerializeField] private UnityEvent _onEndedHealth;
		[SerializeField] private int _maxHealth;
		[SerializeField] private int _currentHealth;
		public int CurrentHealth => _currentHealth;
		
		protected virtual void OnEnable() => _currentHealth = _maxHealth;

		public void TakeDamage(int value)
		{
			value = Mathf.Clamp(value, 0, 1000);
			_currentHealth -= value;
			if (_currentHealth <= 0) 
				_onEndedHealth.Invoke();
		}

		protected virtual void Defeated()
		{
			
		}
	}
}