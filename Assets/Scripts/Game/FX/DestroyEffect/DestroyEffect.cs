using System;
using UnityEngine;

namespace Game.FX.DestroyEffect
{
	public class DestroyEffect : MonoBehaviour
	{
		public static event Action<Transform> OnEffectActivated;

		public void Activate() {
			OnEffectActivated?.Invoke(transform);
		}
	}
}