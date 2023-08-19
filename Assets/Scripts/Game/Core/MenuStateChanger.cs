using UnityEngine;

namespace Game.Core
{
	public class MenuStateChanger : MonoBehaviour
	{
		[SerializeField] private GameObject _menuUI;
		[SerializeField] private GameObject _endGameUI;

		public void BackToMenu()
		{
			_menuUI.SetActive(true);
			_endGameUI.SetActive(false);
		}
	}
}