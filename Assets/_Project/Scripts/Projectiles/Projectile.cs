using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Enemies;

namespace SpaceHustle.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        [Header("Movement")]
        public float speed = 15f;
        public Vector2 direction = Vector2.up; //Player'dan spawn ederken set edecegiz

        [Header("Lifecycle")]
        public float lifeTime = 2f; //saniye
        float _lifeTimer;

        Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _rb.gravityScale = 0f;
        }

        private void OnEnable()
        {
            _lifeTimer = lifeTime;
        }

        private void Update()
        {
            _rb.MovePosition(_rb.position + direction.normalized * speed * Time.deltaTime); //ileriye dogru sabit hizda hareket

            _lifeTimer -= Time.deltaTime; // otomatik yok olma

            if (_lifeTimer <= 0f)
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(5);
                }

                Destroy(gameObject);
            }
        }

    }
}