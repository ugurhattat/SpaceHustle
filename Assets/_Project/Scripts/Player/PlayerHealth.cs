using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        public float hitCooldown = 0.2f; // ayni temas spamini filtreler
        public float bounceImpulse = 6f; // carpisma anindaki geri itme gucu

        int currentHealth;
        float _nextHitTime;

        Rigidbody2D _rb;

        private void Awake()
        {
            currentHealth = maxHealth;
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Damage(int amount, Vector2? knockDir = null, float knockForce = 4f)
        {
            if (Time.time < _nextHitTime) return;    // spam engeli
            _nextHitTime = Time.time + hitCooldown;

            if (knockDir.HasValue)
            {
                _rb.velocity = Vector2.zero;           // hiz birikmesini kes
                _rb.AddForce(knockDir.Value.normalized * knockForce, ForceMode2D.Impulse);
            }
            currentHealth -= amount;
            Debug.Log("HP: " + currentHealth);
            if (currentHealth < 0)
            {
                Die();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Boundary") && Time.time >= _nextHitTime)
            {
                TakeDamage(1);
                _nextHitTime = Time.time + hitCooldown;
                var contact = collision.GetContact(0);
                Vector2 n = contact.normal;
                _rb.AddForce(n * -bounceImpulse, ForceMode2D.Impulse);
            }
        }

        private void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log("Can azaldi! Su anki can: " + currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Oyuncu oldu!)");
            // buraya respawn, game over, vs. eklenebilir
        }
    }
}

