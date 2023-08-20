using UnityEngine;

namespace Game.Player.Ball
{
	public class BallMove : MonoBehaviour
	{
		[SerializeField] private Rigidbody _rigidbody;

		private void FixedUpdate() => _rigidbody.velocity = transform.forward * (3000f * Time.deltaTime);
	}
}