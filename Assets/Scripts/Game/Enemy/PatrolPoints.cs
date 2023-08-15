using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
	public class PatrolPoints : MonoBehaviour
	{
		[SerializeField] private List<Transform> _points = new List<Transform>();
		public List<Transform> Points => _points;
	}
}