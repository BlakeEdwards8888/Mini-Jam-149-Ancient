using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Movement
{
    public class FallHandler : MonoBehaviour
    {
        const float DefaultGravityScale = 1;
        const float FallingGravityScale = 2.5f;

        Rigidbody2D rb2d;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if(rb2d.velocity.y < 0)
            {
                rb2d.gravityScale = FallingGravityScale;
            }
            else
            {
                rb2d.gravityScale = DefaultGravityScale;
            }
        }
    }
}
