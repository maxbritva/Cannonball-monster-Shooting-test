using UnityEngine;
using Zenject;

namespace Game.Player
{
	public class PlayerInput : MonoBehaviour 
	{
		[SerializeField] private Transform _spawnPoint;
		[SerializeField] private Camera _camera;
		private Vector3 _aim;
		private Shoot _shoot;
		
		void Update () => GetRaycastClick();
		[Inject] private void Construct(Shoot shoot) => _shoot = shoot;

		private void GetRaycastClick()
		{
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 1000))
				_aim = hit.point;
			if (Input.GetMouseButtonDown(0)) 
				_shoot.Shot(_aim, _spawnPoint.forward);
		}
	}
}
