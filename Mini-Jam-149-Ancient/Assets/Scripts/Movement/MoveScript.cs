using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class MoveScript : MonoBehaviour
    {
        protected Rigidbody2D rb2d;
        [SerializeField] protected float moveSpeed;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        public virtual void Move()
        {

        }

        public virtual void Stop()
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
