using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
	public class PatrolPoints : MonoBehaviour
	{
		[SerializeField] private List<Transform> _points = new List<Transform>();
		public Vector3 GetRandomPointToGo(Vector3 compareVector3)
		{
			Vector3 newPosition = GetRandomPoint();
			if (newPosition != compareVector3) return newPosition;
			do
				newPosition = GetRandomPoint();
			while (newPosition == compareVector3);
			return newPosition;
		}
		public Vector3 GetRandomPoint() => _points[Random.Range(0, _points.Count)].position;
	}
}