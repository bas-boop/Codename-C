using Gameplay;
using UnityEngine;

namespace Player.Movement
{
    public sealed class Walk : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2d;
        [SerializeField] private UniversalGroundChecker buttom;
        [SerializeField] private UniversalGroundChecker left;
        [SerializeField] private UniversalGroundChecker right;
        [SerializeField] private float speed = 1;
        
        private Vector2 _input;

        private void FixedUpdate()
        {
            rigidbody2d.linearVelocityX = _input.x * speed;
            
            if (left.IsGrounded 
                && !buttom.IsGrounded)
            {
                rigidbody2d.linearVelocityX = 0;
            }
            else if (right.IsGrounded
                     && !buttom.IsGrounded)
            {
                rigidbody2d.linearVelocityX = 0;
            }
        }

        public void SetInput(Vector2 input) => _input = input;
    }
}