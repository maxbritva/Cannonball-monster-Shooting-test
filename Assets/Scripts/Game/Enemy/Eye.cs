using System.Collections;
using Game.Enemy.Spawner;
using Game.Player;
using Game.Player.Ball;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
	public enum EyeStates
	{
		Idle, Attack
	}
	public class Eye : EnemyBase
	{
		[SerializeField] private Animator _animator;
		[SerializeField] private ParticleSystem _particleShot;
		private SpawnPosition _spawnPosition;
		private PlayerInput _playerInput;
		private Coroutine _attack;
		private Coroutine _idle;
		private Explode _explode;
		private WaitForSeconds _interval;
		private WaitForSeconds _intervalAfterAttack;

		[Inject] private void Construct(SpawnPosition spawnPosition, Explode explode, PlayerInput playerInput)
		{
			_spawnPosition = spawnPosition;
			_explode = explode;
			_playerInput = playerInput;
		}
		private void Awake()
		{
			_interval = new WaitForSeconds(4f);
			_intervalAfterAttack = new WaitForSeconds(1f);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_interval = new WaitForSeconds(4f);
			_animator.enabled = true;
			SetState(EyeStates.Idle);
			OnEndedHealth += Defeated;
		}

		private void OnDisable() => OnEndedHealth -= Defeated;

		private void SetState(EyeStates targetState)
		{
			if (targetState == EyeStates.Idle)
				_idle = StartCoroutine(Idle());
			else if (targetState == EyeStates.Attack)
				_attack = StartCoroutine(Attack());
		}

		protected override void Defeated()
		{
			base.Defeated();
			_animator.enabled = false;
			if(_attack != null)
				StopCoroutine(_attack);
			if(_idle != null)
				StopCoroutine(_idle);
			_explode.Terminate(transform.position, gameObject);
		}

		private IEnumerator Attack()
		{
			_animator.SetBool("IsAttack", true);
			_playerInput.Stunned = StartCoroutine(_playerInput.GetStunned());
			_particleShot.Play();
			yield return _intervalAfterAttack;
			SetState(EyeStates.Idle);
		}

		private IEnumerator Idle()
		{
			_animator.SetBool("IsAttack", false);
			yield return _interval;
			SetState(EyeStates.Attack);
		}
	}
}