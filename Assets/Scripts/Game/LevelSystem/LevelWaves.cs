using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem
{
	public class LevelWaves : MonoBehaviour
	{
		[SerializeField] private List<LevelSettings> _allLevels = new List<LevelSettings>();
		[SerializeField] private LevelSettings _currentLevelSettings;
		private LevelSystem _levelSystem;

		private void OnEnable() => _currentLevelSettings = _allLevels[0];

		private void Awake() => _currentLevelSettings = _allLevels[0];
		
		[Inject] private void Construct(LevelSystem levelSystem) => _levelSystem = levelSystem;
		public LevelSettings CurrentLevelSettings => _currentLevelSettings;

		public void NextLevel() => _currentLevelSettings = _allLevels[_levelSystem.LevelCounter - 1];
	}
}