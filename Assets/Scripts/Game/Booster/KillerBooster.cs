﻿using Game.Core;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Booster
{
	public class KillerBooster : MonoBehaviour, IBooster
	{
		private ObjectPool _objectPool;
		private EnemyCounter _enemyCounter;

		public void Activate()
		{
			gameObject.SetActive(false);
			_objectPool.GetActive(true);
			_enemyCounter.SetCurrentEnemyInGame(-10);
			_enemyCounter.OnChange?.Invoke();
			
		}
		[Inject] private void Construct(ObjectPool objectPool, EnemyCounter enemyCounter)
		{
			_objectPool = objectPool;
			_enemyCounter = enemyCounter;
		}
	}
}