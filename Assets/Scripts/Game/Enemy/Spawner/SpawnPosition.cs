using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy.Spawner
{
	public class SpawnPosition : MonoBehaviour
	{
		[SerializeField] private List<Transform> _turtleSpawnPosition = new List<Transform>();
		[SerializeField] private List<Transform> _eyeSpawnPoints = new List<Transform>();
		public List<Transform> TurtleSpawnPosition => _turtleSpawnPosition;
		public List<Transform> EyeSpawnPoints => _eyeSpawnPoints;

		public Vector3 GetRandomPointToGo(Vector3 compareVector3, List<Transform> target)
		{
			Vector3 newPosition = GetRandomPoint(target);
			if (newPosition != compareVector3) return newPosition;
			do
				newPosition = GetRandomPoint(target);
			while (newPosition == compareVector3);
			return newPosition;
		}
		public Vector3 GetRandomPoint(List<Transform> target) => target[Random.Range(0, target.Count)].position;
	}
}