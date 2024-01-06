using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Movement
{
    public class Move_2D : MoveScript
    {
        public void Move(Vector2 dir)
        {
            rb2d.velocity = dir * moveSpeed;
        }
    }
}
