using UnityEngine;

namespace Game.Player.Ball
{
	public class Explode : MonoBehaviour
	{
		[SerializeField] private float _radius;
		[SerializeField] private float _force;
		
		public void Terminate(Vector3 position, GameObject target)
		{
			Rigidbody attachedRigidbody = target.gameObject.GetComponent<Collider>().attachedRigidbody;
				if (attachedRigidbody) 
					attachedRigidbody.AddExplosionForce(_force, position, _radius,1f);
				attachedRigidbody.AddTorque(Vector3.forward * Time.deltaTime * 200f, ForceMode.VelocityChange);
		}
	}
}