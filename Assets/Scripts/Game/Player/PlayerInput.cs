using System.Collections;
using Game.Core.Shop;
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
		private UpgradeLoader _upgradeLoader;
		private Vector3 _aim;
		public Vector3 Aim => (_aim - transform.position).normalized;

		private float _timer;
		private WaitForSeconds _stunnedTimer = new WaitForSeconds(2f);

		void Update () => GetRaycastClick();
		[Inject] private void Construct(Shoot shoot, UpgradeLoader upgradeLoader)
		{
			_shoot = shoot;
			_upgradeLoader = upgradeLoader;
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
			if (!(_timer > _upgradeLoader.SpeedCurrentLevel.Value)) return;
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
