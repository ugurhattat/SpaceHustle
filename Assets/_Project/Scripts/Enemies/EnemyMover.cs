using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Core;
using SpaceHustle.Player;

namespace SpaceHustle.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyMover : MonoBehaviour
    {
        public float speed = 2f;
        public int contactDamage = 2;    // carpisma hasari
        public float knocForce = 4f;

        private void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        public void KillGameObject()
        {
            EnemyPool.Instance.Set(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("KillZone"))
            {
                KillGameObject();
            }
            else if (other.CompareTag("Player"))
            {
                var hp = other.GetComponent<PlayerHealth>();
                if (hp)
                {
                    Vector2 dir = (other.transform.position - transform.position);
                    hp.Damage(contactDamage, dir, knocForce);   // kontrollu itis
                }

                KillGameObject();
            }
        }
    }
}

