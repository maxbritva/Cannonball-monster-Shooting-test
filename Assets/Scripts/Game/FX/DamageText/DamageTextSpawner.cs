using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.FX.DamageText
{
	[RequireComponent(typeof(DamageTextPool))]
	public class DamageTextSpawner : MonoBehaviour
	{
		[SerializeField] private DamageTextPool _damageTextPool;
		private WaitForSeconds _wait;
		private Color _color;

		private void Awake() {
			_wait = new WaitForSeconds(0.05f);
			_color = new Color(221, 7, 120);

		}
		public void Activate(Transform target, int damage, bool isCriticalDamage) {
			GameObject effect = _damageTextPool.GetEffectFromPool();
			effect.transform.position = target.position + NewRandomPositionText();
			if (!effect.TryGetComponent(out DamageText damageText)) return;
			damageText.TextDamage.text = damage.ToString();
			float damageSize = damage / 4f;
			damageText.TextDamage.fontSize = Mathf.Clamp(damageSize, 10f,40f);
			if (isCriticalDamage)
			{
				damageText.TextDamage.color = Color.cyan;
				damageText.TextDamage.text = damage.ToString() + "!";
			}
			else {
				damageText.TextDamage.color = Color.white;
			}
			effect.SetActive(true);
			StartCoroutine(DamageTextSetup(damageText.TextDamage, effect));
		}

		private Vector3 NewRandomPositionText() {
			Vector3 newPosition =  new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
			return newPosition;
		}

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