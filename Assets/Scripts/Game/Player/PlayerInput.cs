using System.Collections;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private float _shootPower;
  
        private void Update()
        {
            if (Input.GetMouseButton(0)) 
                Shoot();
        }

        private void Shoot() => StartCoroutine(ShootPower());

        private IEnumerator ShootPower()
        {
            while (true)
            {
                
                yield return null;
            }
        }
    }
}
