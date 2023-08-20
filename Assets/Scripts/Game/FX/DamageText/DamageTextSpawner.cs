using System.Collections;
using Game.Core;
using TMPro;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.FX.DamageText
{
	
	public class DamageTextSpawner : MonoBehaviour
	{
		private ObjectPool _objectPool;
		private readonly WaitForSeconds _wait = new WaitForSeconds(0.05f);

		public void Activate(Transform target, int damage)
		{
			GameObject effect = _objectPool.GetObjectFromPool(4);
			effect.transform.position = target.position + NewRandomPositionText();
				if (!effect.TryGetComponent(out TextMeshPro damageText)) return;
			damageText.text = damage.ToString();
			float damageSize = damage / 3f;
			damageText.fontSize = Mathf.Clamp(damageSize, 10f,40f);
			effect.SetActive(true);
			StartCoroutine(DamageTextSetup(damageText, effect));
		}
		[Inject] private void Construct(ObjectPool objectPool) => _objectPool = objectPool;
		private Vector3 NewRandomPositionText() => new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 3f));

		private IEnumerator DamageTextSetup(TextMeshPro text, GameObject targetEffect) {
			Color color = text.color;
			color.a = 1f;
			for (float f = 1f; f >= -0.05f; f-=0.05f) {
				text.color = color;
				color.a = f;
				yield return _wait;
			}
			targetEffect.SetActive(false);
		}

		
	}
}