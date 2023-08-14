using UnityEngine;

namespace Game.Player
{
	public class CannonMove : MonoBehaviour
	{
		[SerializeField] private Transform _cannonTransform;
		private Camera _camera;
		private float _distance;

		private void Awake() => _camera = Camera.main;
		private void Update() => Move();

		private void Move()
		{
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			Plane plane = new Plane(-Vector3.forward, Vector3.zero);
			plane.Raycast(ray, out _distance);
			Vector3 point = ray.GetPoint(_distance);
			Vector3 toAim = point - transform.position;
			toAim = new Vector3(toAim.x,0,toAim.z);
			transform.rotation = Quaternion.LookRotation(toAim);
		}
	}
}