using Game.Player.Ball;
using UnityEngine;
using Zenject;

namespace Game.Player
{
	public class Shoot : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _shootParticle;
		private BallPool _ballPool;
		
		public void Shot(Vector3 aim) {
			_shootParticle.Play();
			Vector3 direction = (aim - transform.position).normalized;
			GameObject ballFromPool = _ballPool.GetBallFromPool();
			//ballFromPool.GetComponent<Rigidbody>().velocity = direction * (23000f * Time.deltaTime); may be upgrade for rotation ball
		}
		
		[Inject] private void Construct(BallPool ballPool) => _ballPool = ballPool;
	}
}