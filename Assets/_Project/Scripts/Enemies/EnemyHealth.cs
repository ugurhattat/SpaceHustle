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

        public int Current => _current;  // barin oran hesaplamasi icin okunur current.

        private void Awake()
        {
            _current = maxHealth;
        }
        
        public void TakeDamage(int amount)
        {
            _current = Mathf.Max(0, _current - amount);  // can = can - hasar (0'in altina inme)
            if (_current <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            if (deathVfxPrefab != null)
            {
                Instantiate(deathVfxPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}


