using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        public int maxHealth = 10;
        int _current;

        [Tooltip("Olurken oynatilacak efekt (Opsiyonel)")]
        public GameObject deathVfxPrefab;

        private void Awake()
        {
            _current = maxHealth;
        }
        
        public void TakeDamage(int amount)
        {
            _current -= amount;
            if (_current < 0)
            {
                Die();
            }
        }

        public void Die()
        {
            if (deathVfxPrefab != null)
            {
                Instantiate(deathVfxPrefab, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}


