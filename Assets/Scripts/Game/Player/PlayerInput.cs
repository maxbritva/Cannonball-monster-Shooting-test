using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Player
{
	public class PlayerInput : MonoBehaviour 
	{
		[SerializeField] private Camera _camera;
		[SerializeField] private ParticleSystem _stunnedFX;
		private bool _isStunned = true;
		public Coroutine Stunned { get; set; }
		private Shoot _shoot;
		private PlayerData _playerData;
		private Vector3 _aim;
		private float _timer;
		private WaitForSeconds _stunnedTimer = new WaitForSeconds(2f);

		void Update () => GetRaycastClick();
		[Inject] private void Construct(Shoot shoot, PlayerData playerData)
		{
			_shoot = shoot;
			_playerData = playerData;
		}

		private void GetRaycastClick()
		{
			if (_isStunned) return;
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 1000))
				_aim = hit.point;
			transform.LookAt(hit.point);
			_timer += Time.deltaTime;
			if (!(_timer > _playerData.ShotInterval)) return;
			if (!Input.GetMouseButtonDown(0)) return;
			_shoot.Shot(_aim);
			_timer = 0;
		}

		public IEnumerator GetStunned()
		{
			_stunnedFX.Play();
			_isStunned = true;
			yield return _stunnedTimer;
			_isStunned = false;
		}
		public void DisableCannon(bool value) => _isStunned = value;
	}
}
