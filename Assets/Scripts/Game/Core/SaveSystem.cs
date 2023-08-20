using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Core
{
	public class SaveSystem : MonoBehaviour
	{
		private PlayerData _playerData;

		[Inject] private void Construct(PlayerData playerData) => _playerData = playerData;

		public void SaveData()
		{
			PlayerPrefs.SetInt("Coins", _playerData.Coins);
			PlayerPrefs.SetInt("TopScore", _playerData.TopScore);
			PlayerPrefs.SetInt("damageUpgrade", _playerData.DamageUpgradeIndex);
			PlayerPrefs.SetInt("speedUpgrade", _playerData.SpeedUpgradeIndex);
		}

		public void LoadData()
		{
			_playerData.SetCoins(PlayerPrefs.GetInt("Coins"));
			_playerData.SetTopScore(PlayerPrefs.GetInt("TopScore"));
			_playerData.SetDamageUpgradeIndex(PlayerPrefs.GetInt("damageUpgrade"));
			if (PlayerPrefs.GetInt("damageUpgrade") == 0)
				_playerData.SetDamageUpgradeIndex(1);
			_playerData.SetSpeedUpgradeIndex(PlayerPrefs.GetInt("speedUpgrade"));
			if (PlayerPrefs.GetInt("speedUpgrade") == 0)
				_playerData.SetSpeedUpgradeIndex(1);
		}
	}
}