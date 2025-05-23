using UnityEngine;

namespace Player.Movement
{
    public sealed class Walk : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2d;
        [SerializeField] private float speed = 1;
        
        private Vector2 _input;

        private void FixedUpdate()
        {
            rigidbody2d.linearVelocityX = _input.x * speed;
        }

        public void SetInput(Vector2 input) => _input = input;
    }
}