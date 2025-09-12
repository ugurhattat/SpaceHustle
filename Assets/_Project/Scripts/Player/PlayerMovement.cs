using SpaceHustle.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Player
{
    // WASD/OK ile hareket.
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 6f;

        Rigidbody2D _rb;
        Vector2 _input;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.gravityScale = 0f;    // uzayda yercekimi yok
            _rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }

        private void Update()
        {
            _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }

        private void FixedUpdate()
        {
            Vector2 target = _rb.position + _input * moveSpeed * Time.fixedDeltaTime;
            _rb.velocity = _input * moveSpeed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Boundary"))
            {
                Debug.Log("Kenara carptin, can azalmali");
                
            }
        }
    }
}

