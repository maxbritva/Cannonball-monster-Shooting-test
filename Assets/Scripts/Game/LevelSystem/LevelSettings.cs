using UnityEngine;

namespace Game.LevelSystem
{
	[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObject/LevelSettings")]
	public class LevelSettings : ScriptableObject
	{
		[SerializeField] private float _turtleSpawnInterval;
		[SerializeField] private float _eyeSpawnInterval;
		[SerializeField] private int _enemyHealthBonus;

		public float TurtleSpawnInterval => _turtleSpawnInterval;
		public float EyeSpawnInterval => _eyeSpawnInterval;
		public int EnemyHealthBonus => _enemyHealthBonus;
	}
}