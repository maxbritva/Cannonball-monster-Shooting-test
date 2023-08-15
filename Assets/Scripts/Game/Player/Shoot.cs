using Game.Player.Ball;
using UnityEngine;
using Zenject;

namespace Game.Player
{
	public class Shoot : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _shootParticle;
		private readonly float _gravity = Physics.gravity.y;
		private BallPool _ballPool;
		
		[Inject] private void Construct(BallPool ballPool) => _ballPool = ballPool;
		
		public void Shot(Vector3 aim, Vector3 spawnPoint) {
			_shootParticle.Play();
			Vector3 direction = aim - transform.position;
			Vector3 directionXZ = new Vector3(direction.x, 0f, direction.z);
			transform.rotation = Quaternion.LookRotation(directionXZ, Vector3.up);
			float x = directionXZ.magnitude;
			float y = direction.y;
			float angleInRadians = 45 * Mathf.PI / 180;
			float v2 = (_gravity * x * x) / (2 * (y - Mathf.Tan(angleInRadians) * x) * Mathf.Pow(Mathf.Cos(angleInRadians), 2));
			float v = Mathf.Sqrt(Mathf.Abs(v2));
			GameObject ballFromPool = _ballPool.GetBallFromPool();
			ballFromPool.GetComponent<Rigidbody>().velocity = spawnPoint * v;
		}
	}
}