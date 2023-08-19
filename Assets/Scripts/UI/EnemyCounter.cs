using System;
using Game.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
	public class EnemyCounter : MonoBehaviour
	{
		[SerializeField] private Image _image;
		public Action OnChange;
		private ObjectPool _objectPool;
		private GameStateChanger _gameStateChanger;
		private int _enemyInGame;
		private float _maxCount = 10;

		private void OnEnable()
		{
			OnChange += CheckEnemy;
			OnChange += ShowUi;
		}

		private void OnDisable()
		{
			OnChange -= ShowUi;
			OnChange -= CheckEnemy;
		}

		[Inject] private void Construct(ObjectPool objectPool, GameStateChanger gameStateChanger)
		{
			_objectPool = objectPool;
			_gameStateChanger = gameStateChanger;
		}

		private void ShowUi() => _image.fillAmount = _enemyInGame / _maxCount;

		private void CheckEnemy()
		{
			if (_enemyInGame < 10) return;
			_gameStateChanger.InitializeGameOver();
			_enemyInGame = 0;
		}

		public void SetCurrentEnemyInGame(int value)
		{
			_enemyInGame += value;
			_enemyInGame = Mathf.Clamp(_enemyInGame,0, 10);
		}
	}
}