using System;
using System.Collections;
using Game.Enemy.Spawner;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Booster
{
	public class FreezeBooster : MonoBehaviour, IBooster
	{
		private EnemySpawner _enemySpawner;

		[Inject] private void Construct(EnemySpawner enemySpawner) => _enemySpawner = enemySpawner;

		public void Activate() => Freeze();

		private void Freeze()
		{
			_enemySpawner.GetFreeze();
			gameObject.SetActive(false);
		}
	}
}