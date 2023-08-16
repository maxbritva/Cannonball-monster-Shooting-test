using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	public enum TurtleStates
	{
		Idle, Walk, Died
	}
	public class Turtle : EnemyBase
	{
		[SerializeField] private Animator _animator;
		private PatrolPoints _patrolPoints;
		private Vector3 _targetPoint;

		[Inject] private void Construct(PatrolPoints patrolPoints) => _patrolPoints = patrolPoints;
		protected override void OnEnable() => SetState(TurtleStates.Idle);

		private void SetState(TurtleStates targetState)
		{
			if (targetState == TurtleStates.Idle)
				Idle();
			else if (targetState == TurtleStates.Walk)
				StartCoroutine(StartPatrol());
			else if (targetState == TurtleStates.Died)
			{ }
		}

		private IEnumerator StartPatrol()
		{
			_targetPoint = _patrolPoints.GetRandomPointToGo(transform.position);
			_animator.SetBool("IsRunning", true);
			RotationToTarget();
			while (true)
			{
				transform.position = Vector3.MoveTowards(transform.position, 
					_targetPoint,3f * Time.deltaTime);
				if (transform.position == _targetPoint)
				{
					SetState(TurtleStates.Idle);
					break;
				}
				yield return null;
			}
		}

		private async void Idle()
		{
			_animator.SetBool("IsRunning", false);
			await Task.Delay(2000);
			SetState(TurtleStates.Walk);
		}
		private void RotationToTarget() => transform.rotation = Quaternion.LookRotation((transform.position - _targetPoint).normalized);
	}
}