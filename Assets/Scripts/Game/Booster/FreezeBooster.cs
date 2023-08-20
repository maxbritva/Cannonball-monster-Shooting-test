using Game.Enemy.Spawner;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Booster
{
	public class FreezeBooster : MonoBehaviour, IBooster
	{
		private EnemySpawner _enemySpawner;
		
		public void Activate() => Freeze();
		[Inject] private void Construct(EnemySpawner enemySpawner) => _enemySpawner = enemySpawner;

		private void Freeze()
		{
			_enemySpawner.GetFreeze();
			gameObject.SetActive(false);
		}
	}
}