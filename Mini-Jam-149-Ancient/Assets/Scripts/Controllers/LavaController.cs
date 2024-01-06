using Ancient.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ancient.Controllers
{
    public class LavaController : MonoBehaviour
    {
        Move_2D moveScript;

        private void Awake()
        {
            moveScript = GetComponent<Move_2D>();
        }

        private void Update()
        {
            moveScript.Move(new Vector2(0, 1));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Artifact"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
