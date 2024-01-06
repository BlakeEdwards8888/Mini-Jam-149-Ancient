using Ancient.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpScript : MonoBehaviour
    {
        [SerializeField] float jumpForce;
        [SerializeField] ContactFilter2D contactFilter;
        [SerializeField] Animator anim;
        Rigidbody2D rb2d;

        bool prevGroundCheck;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            if (GroundCheck())
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
        }

        public void CancelJump()
        {
            if(rb2d.velocity.y > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y / 2);
            }
        }

        bool GroundCheck()
        {
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            rb2d.Cast(Vector2.down, contactFilter, hits, 0.1f);

            return hits.Count > 0;
        }

        private void Update()
        {
            UpdateAnimator();

            CheckForLanding();
        }

        private void CheckForLanding()
        {
            prevGroundCheck = GroundCheck();
        }

        private void UpdateAnimator()
        {
            if (anim != null)
            {
                anim.SetFloat("yVelocity", rb2d.velocity.y);
                anim.SetBool("IsGrounded", GroundCheck());
            }
        }
    }
}
