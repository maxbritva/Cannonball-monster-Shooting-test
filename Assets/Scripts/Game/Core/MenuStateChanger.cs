using UI;
using UnityEngine;
using Zenject;

namespace Game.Core
{
	[RequireComponent(typeof(AudioSource))]
	public class MenuStateChanger : MonoBehaviour
	{
		[SerializeField] private GameObject _menuUI;
		[SerializeField] private GameObject _endGameUI;
		[SerializeField] private AudioSource _audioSource;
		private MenuUIUpdater _menuUIUpdater;
		private SaveSystem _saveSystem;
		public AudioSource AudioSource => _audioSource;

		public void BackToMenu()
		{
			_audioSource.Play();
			_menuUI.SetActive(true);
			_endGameUI.SetActive(false);
			_saveSystem.LoadData();
			_menuUIUpdater.UpdateUI();
		}

		[Inject] private void Construct(MenuUIUpdater menuUIUpdater, SaveSystem saveSystem)
		{
			_menuUIUpdater = menuUIUpdater;
			_saveSystem = saveSystem;
		}
	}
}