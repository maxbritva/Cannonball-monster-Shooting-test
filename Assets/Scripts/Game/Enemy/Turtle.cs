using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	public class Turtle : EnemyBase, IMovable
	{
		private PatrolPoints _patrolPoints;

		[Inject] private void Construct(PatrolPoints patrolPoints) => _patrolPoints = patrolPoints;

		protected override void OnEnable()
		{
			StartCoroutine(StartPatrol());

		}

		public void Move()
		{
			
		}

		private IEnumerator StartPatrol()
		{
			while (true)
			{
				transform.position = Vector3.MoveTowards(transform.position, 
					_patrolPoints.Points[Random.Range(0,_patrolPoints.Points.Count)].position, 
					10f * Time.deltaTime); 
				yield return null;
			}
		}
	}
}