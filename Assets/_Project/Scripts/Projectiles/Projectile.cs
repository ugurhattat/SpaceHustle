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
        public float speed = 15f;              // mermi hizi (dunya birimi/sn)
        public Vector2 direction = Vector2.up; // spawn ederken veriyoruz

        [Header("Combat")]
        public int damage = 1;                  // power-up'a gore degisecek

        [Header("Lifecycle")]
        public float lifeTime = 2.5f;           // sure dolunca kendini sil
        float _lifeTimer;

        Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Kinematic;  // fizik kuvveti kullanilmiyor
            _rb.gravityScale = 0f;                     // 2d uzay oyunu -> yercekimi yok
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
        private void OnTriggerEnter2D(Collider2D other)  // trigger kullaniyorsak mermi collider'i IsTrigger=true olmali
        {
            // tag ile ugrasmadan dogrudan EnemyHealth var mi diye bak
                var enemy = other.GetComponentInParent<EnemyHealth>();
            if (enemy == null) return;

            enemy.TakeDamage(damage);  // power-up'a gore degisen damage uygula
            Debug.Log("HIT: " + other.name);
            gameObject.SetActive(false);
        }

    }
}