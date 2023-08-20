using Game.Player;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Core.Shop
{
	public class Shop : MonoBehaviour
	{
		[SerializeField] private Text _damageCostText;
		[SerializeField] private Text _speedCostText;

		[SerializeField] private Button _damageButton;
		[SerializeField] private Button _speedButton;
		private UpgradeLoader _upgradeLoader;
		private PlayerData _playerData;
		private MenuUIUpdater _menuUIUpdater;
		private SaveSystem _saveSystem;

		private void OnEnable()
		{
			ShowPrice();
			CheckAvailableButtons();
		}

		public void ShowPrice()
		{
			_damageCostText.text = "Цена: " + _upgradeLoader.DamageCurrentLevel.Cost.ToString();
			_speedCostText.text = "Цена: " + _upgradeLoader.SpeedCurrentLevel.Cost.ToString();
			_menuUIUpdater.UpdateUI();
			_menuUIUpdater.UpdateUpgradeWindowCoins();
		}
		
		public void TryUpgrade(int id)
		{
			switch (id)
			{
				case 1:
				{
					SpendCredits(_upgradeLoader.DamageCurrentLevel);
					if (_playerData.DamageUpgradeIndex < 5) 
						_playerData.DamageUpgrade();
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}
				case 2:
				{
					SpendCredits(_upgradeLoader.SpeedCurrentLevel);
					if (_playerData.SpeedUpgradeIndex < 5) 
						_playerData.SpeedUpgrade();
					CheckAvailableButtons();
					ShowPrice();
					_upgradeLoader.LoadCurrentLevels();
					break;
				}
			}
		}
		
		private void SpendCredits(ItemShop target) {
			if (_playerData.Coins >= target.Cost)
				_playerData.AddSpendCoins(-target.Cost);
			_saveSystem.SaveData();
		}
		
		[Inject] private void Construct(UpgradeLoader upgradeLoader, PlayerData playerData, MenuUIUpdater menuUIUpdater, SaveSystem saveSystem)
		{
			_upgradeLoader = upgradeLoader;
			_playerData = playerData;
			_menuUIUpdater = menuUIUpdater;
			_saveSystem = saveSystem;
		}

		private void CheckAvailableButtons()
		{
			_damageButton.interactable = _playerData.Coins >= _upgradeLoader.DamageCurrentLevel.Cost && _playerData.DamageUpgradeIndex < 5;
			_speedButton.interactable = _playerData.Coins >= _upgradeLoader.SpeedCurrentLevel.Cost && _playerData.SpeedUpgradeIndex < 5;
		}
		
	}
}