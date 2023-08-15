using System.Collections;
using UnityEngine;

namespace Game.Player.Ball
{
	public class Explode : MonoBehaviour
	{
		[SerializeField] private float _radius;
		[SerializeField] private float _force;
		
		
		public void Terminate(Vector3 position)
		{
			Collider[] overlappedColliders = Physics.OverlapSphere(position, _radius);
			for (int i = 0; i < overlappedColliders.Length; i++)
			{
				Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
				if (rigidbody) 
					rigidbody.AddExplosionForce(_force, position, _radius,1f);
				//StartCoroutine(RaycastOff(rigidbody));
			}
		}

		private IEnumerator RaycastOff(Rigidbody rigidbody)
		{
			yield return new WaitForSeconds(2f);
			int layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
			rigidbody.gameObject.layer = layerIgnoreRaycast;
		}
	}
}