using UnityEngine;

namespace Game.Player.Ball {
public class BallMove : MonoBehaviour
{
   [SerializeField] private Rigidbody _rigidBody;
   [SerializeField] private float _speed;

   private void OnEnable()
   {
      //speed from slider
   }

   private void Update() => Move();
   private void Move() => _rigidBody.AddForce(Vector3.forward * (_speed * Time.deltaTime), ForceMode.Impulse);
}
}

