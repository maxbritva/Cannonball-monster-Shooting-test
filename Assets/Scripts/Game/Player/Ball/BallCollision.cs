using UnityEngine;
using Zenject;

namespace Game.Player.Ball
{
public class BallCollision : MonoBehaviour
{
	private Explode _explode;
	[Inject] private void Construct(Explode explode) => _explode = explode;

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Enemy.EnemyBase enemy))
		{
			_explode.Terminate(transform.position);
			gameObject.SetActive(false);
			// effect
		}
		if (other.TryGetComponent(out DeadZone deadZone))
			gameObject.SetActive(false);


	}
}
}

