using Game.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MenuUIUpdater : MonoBehaviour
    {
        [SerializeField] private Text _topScoreText;
        [SerializeField] private Text _coinsText;
        [SerializeField] private Text _upgradeWindowCoinsText;
        private PlayerData _playerData;

        [Inject] private void Construct(PlayerData playerData) => _playerData = playerData;

        public void UpdateUI()
        {
            _topScoreText.text = _playerData.TopScore.ToString();
            _coinsText.text = _playerData.Coins.ToString();
        }

        public void UpdateUpgradeWindowCoins() => _upgradeWindowCoinsText.text = _playerData.Coins.ToString();
    }
}