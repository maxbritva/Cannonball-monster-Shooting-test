using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Game.FX.DamageText
{
	public class DamageText : MonoBehaviour
	{
		private DamageTextSpawner _damageTextSpawner;
		[SerializeField] private TextMeshPro _textDamage;

		public TextMeshPro TextDamage => _textDamage;
	}
}