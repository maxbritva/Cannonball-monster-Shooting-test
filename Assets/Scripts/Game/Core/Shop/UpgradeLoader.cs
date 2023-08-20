using System.Collections.Generic;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Core.Shop
{
	public class UpgradeLoader : MonoBehaviour
	{
		[SerializeField] private List<ItemShop> _damageLevels = new List<ItemShop>();
		[SerializeField] private List<ItemShop> _speedShootLevels = new List<ItemShop>();
		public ItemShop DamageCurrentLevel { get; private set; }
		public ItemShop SpeedCurrentLevel { get; private set; }
		private PlayerData _playerData;

		private void Awake() => LoadCurrentLevels();

		public void LoadCurrentLevels() {
			DamageCurrentLevel = _damageLevels[_playerData.DamageUpgradeIndex -1];
			SpeedCurrentLevel = _speedShootLevels[_playerData.SpeedUpgradeIndex -1];
		}

		[Inject] private void Construct(PlayerData playerData) => _playerData = playerData;
	}
}