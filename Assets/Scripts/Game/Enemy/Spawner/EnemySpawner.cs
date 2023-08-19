using System.Collections;
using Game.Core;
using Game.LevelSystem;
using Game.Player;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Enemy.Spawner
{
	public class EnemySpawner : MonoBehaviour
	{
		private SpawnPosition _spawnPosition;
		private LevelWaves _levelWaves;
		private PlayerInput _playerInput;
		private EnemyCounter _enemyCounter;
		private Coroutine _spawnTurtle;
		private Coroutine _freeze;
		private Coroutine _spawnEye;
		private WaitForSeconds _turtleInterval; 
		private WaitForSeconds _eyeInterval; 
		private WaitForSeconds _eyeBeforeSpawnInterval = new WaitForSeconds(5f); 
		private WaitForSeconds _freezeInterval = new WaitForSeconds(3f);
		private ObjectPool _objectPool;

		private void Awake() => ReloadIntervals();

		[Inject] private void Construct(SpawnPosition spawnPosition, ObjectPool objectPool, 
			PlayerInput playerInput, EnemyCounter enemyCounter, LevelWaves levelWaves)
		{
			_spawnPosition = spawnPosition;
			_objectPool = objectPool;
			_playerInput = playerInput;
			_enemyCounter = enemyCounter;
			_levelWaves = levelWaves;
		}

		public void ActivateSpawn()
		{
			_spawnTurtle = StartCoroutine(SpawnTurtle());
			_spawnEye = StartCoroutine(SpawnEye());
		}

		public void DeactivateSpawn()
		{
			StopCoroutine(_spawnTurtle);
			StopCoroutine(_spawnEye);
		}

		public void DeactivateAll()
		{
			DeactivateSpawn();
			if(_freeze != null)
				StopCoroutine(_freeze);
		}

		public void ReloadIntervals()
		{
			_turtleInterval = new WaitForSeconds(_levelWaves.CurrentLevelSettings.TurtleSpawnInterval);
			_eyeInterval = new WaitForSeconds(_levelWaves.CurrentLevelSettings.EyeSpawnInterval);
		}
		public  void GetFreeze() => _freeze = StartCoroutine(StartFreeze());
		private IEnumerator SpawnTurtle()
		{
			while (true)
			{
				GameObject turtleFromPool = _objectPool.GetObjectFromPool(1);
				turtleFromPool.transform.position = _spawnPosition.GetRandomPoint(_spawnPosition.TurtleSpawnPosition);
				turtleFromPool.transform.rotation = Quaternion.identity;
				_enemyCounter.SetCurrentEnemyInGame(1);
				_enemyCounter.OnChange?.Invoke();
				yield return _turtleInterval;
			}
		}
		
		private IEnumerator SpawnEye()
		{
			yield return _eyeBeforeSpawnInterval;
			while (true)
			{
				GameObject eyeFromPool = _objectPool.GetObjectFromPool(2);
				eyeFromPool.transform.position = _spawnPosition.GetRandomPoint(_spawnPosition.EyeSpawnPoints);
				eyeFromPool.transform.LookAt(_playerInput.gameObject.transform.position);
				_enemyCounter.SetCurrentEnemyInGame(1);
				_enemyCounter.OnChange?.Invoke();
				yield return _eyeInterval;
			}
		}

		private IEnumerator StartFreeze()
		{
			DeactivateSpawn();
			//effect
			yield return _freezeInterval;
			ActivateSpawn();
		}
	}
}