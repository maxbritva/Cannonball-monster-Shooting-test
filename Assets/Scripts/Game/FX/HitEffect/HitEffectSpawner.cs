using Game.Core;
using UnityEngine;
using Zenject;

namespace Game.FX.HitEffect
{
	public class HitEffectSpawner : MonoBehaviour
	{
		private ObjectPool _objectPool;
		public void Activate(Transform target)
		{
			GameObject effect = _objectPool.GetObjectFromPool(3);
			effect.transform.position = target.position;
			effect.SetActive(true);
		}
		[Inject] private void Construct(ObjectPool objectPool) => _objectPool = objectPool;
	}
}