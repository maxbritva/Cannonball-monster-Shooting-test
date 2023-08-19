using System.Collections;
using Game.Enemy.Spawner;
using Game.Player.Ball;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	public enum TurtleStates
	{
		Idle, Walk
	}
	public class Turtle : EnemyBase
	{
		[SerializeField] private Animator _animator;
		private SpawnPosition _spawnPosition;
		private Vector3 _targetPoint;
		private Coroutine _patrol;
		private Coroutine _idle;
		private Explode _explode;
		private WaitForSeconds _interval;

		[Inject] private void Construct(SpawnPosition spawnPosition, Explode explode)
		{
			_spawnPosition = spawnPosition;
			_explode = explode;
		}
		private void Start() => _interval = new WaitForSeconds(2f);
		protected override void OnEnable()
		{
			base.OnEnable();
			_animator.enabled = true;
			SetState(TurtleStates.Idle);
			OnEndedHealth += Defeated;
		}

		private void OnDisable() => OnEndedHealth -= Defeated;

		private void SetState(TurtleStates targetState)
		{
			if (targetState == TurtleStates.Idle)
				_idle = StartCoroutine(Idle());
			else if (targetState == TurtleStates.Walk)
				_patrol = StartCoroutine(StartPatrol());
		}

		protected override void Defeated()
		{
			base.Defeated();
			_animator.enabled = false;
			if(_patrol != null)
				StopCoroutine(_patrol);
			if(_idle != null)
				StopCoroutine(_idle);
			_explode.Terminate(transform.position, gameObject);
		}

		private IEnumerator StartPatrol()
		{
			_targetPoint = _spawnPosition.GetRandomPointToGo(transform.position, _spawnPosition.TurtleSpawnPosition);
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

		private IEnumerator Idle()
		{
			_animator.SetBool("IsRunning", false);
			yield return _interval;
			SetState(TurtleStates.Walk);
		}
		private void RotationToTarget() => transform.rotation = Quaternion.LookRotation((transform.position - _targetPoint).normalized);
	}
}