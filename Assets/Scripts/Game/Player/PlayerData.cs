using System;
using UnityEngine;

namespace Game.Player
{
	public class PlayerData : MonoBehaviour
	{
		[SerializeField] private float _shotInterval;
		[SerializeField] private float _damage;
		[SerializeField] private int _topScore;
		[SerializeField] private int _coins;
		public float ShotInterval => _shotInterval;
		public float Damage => _damage;
		public int TopScore => _topScore;
		public int Coins => _coins;

		public void SetShotInterval(float value)
		{
			if (value <= 0)
				throw new ArgumentOutOfRangeException("ShotInterval value must be more than 0");
			value = Mathf.Clamp(value, 0.1f, 1f);
			_shotInterval = value;
		}

		public void SetDamage(float value)
		{
			if (value <= 0)
				throw new ArgumentOutOfRangeException("Damage value must be more than 0");
			value = Mathf.Clamp(value, 10f, 100f);
			_damage = value;
		}
		
		public void SetTopScore(int value)
		{
			if (value > _topScore)
				_topScore = value;
		}
		
		public void SetCoins(int value)
		{
			if (value == 0)
				throw new ArgumentOutOfRangeException("Coins must be more, or less than 0");
			_coins += value;
		}
		
	}
}