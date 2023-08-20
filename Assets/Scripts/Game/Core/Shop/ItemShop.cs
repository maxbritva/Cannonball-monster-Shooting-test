using UnityEngine;

namespace Game.Core.Shop
{
	[CreateAssetMenu(fileName = "ItemShop", menuName = "ScriptableObject/ItemShop")]
	public class ItemShop : ScriptableObject
	{
		[SerializeField] private float _value;
		[SerializeField] private int _cost;

		public float Value => _value;
		public int Cost => _cost;
	}
}