using System;
using UnityEngine;

namespace Game.Player
{
	public class PlayerData : MonoBehaviour
	{
		[SerializeField] private int _topScore;
		[SerializeField] private int _coins;
		[SerializeField] private int _damageUpgradeIndex;
		[SerializeField] private int _speedUpgradeIndex;
		
		public int TopScore => _topScore;
		public int Coins => _coins;
		public int DamageUpgradeIndex => _damageUpgradeIndex;
		public int SpeedUpgradeIndex => _speedUpgradeIndex;

	
		public void CompareTopScore(int value)
		{
			if (value > _topScore)
				_topScore = value;
		}
		public void SetTopScore(int value) => _topScore = value;

		public void SetDamageUpgradeIndex(int value)
		{
			if (value < 0 || value > 5)
				throw new ArgumentOutOfRangeException("DamageUpgrade must be in range from 1 to 5");
			_damageUpgradeIndex = value;
		}
		public void SetSpeedUpgradeIndex(int value)
		{
			if (value < 0 || value > 5)
				throw new ArgumentOutOfRangeException("SpeedUpgrade must be in range from 1 to 5");
			_speedUpgradeIndex = value;
		}
		public void AddSpendCoins(int value) => _coins += value;
		public void SetCoins(int value)
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException("value must be more than 0");
			_coins = value;
		}

		public void DamageUpgrade() => _damageUpgradeIndex++;
		public void SpeedUpgrade() => _speedUpgradeIndex++;
	}
}