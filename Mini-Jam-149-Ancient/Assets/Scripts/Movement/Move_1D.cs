using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Movement
{
    public class Move_1D : MoveScript
    {
        [SerializeField] ContactFilter2D contactFilter;
        [SerializeField] Animator anim;

        public void Move(float axis)
        {
            if (!WallCheck(Vector2.right * axis) && axis != 0)
            {
                rb2d.velocity = new Vector2(axis * moveSpeed, rb2d.velocity.y);

                if (anim != null)
                    anim.SetBool("IsIdle", false);
            }
            else
            {
                Stop();
            }
        }

        public override void Stop()
        {
            rb2d.velocity = new Vector2(0 * moveSpeed, rb2d.velocity.y);

            if (anim != null)
                anim.SetBool("IsIdle", true);
        }

        public bool WallCheck(Vector2 dir)
        {
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            rb2d.Cast(dir, contactFilter, hits, 0.1f);

            return hits.Count > 0;
        }
    }
}
