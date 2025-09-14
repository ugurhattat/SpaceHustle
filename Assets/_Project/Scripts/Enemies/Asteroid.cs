using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Core;
using SpaceHustle.Player;

namespace SpaceHustle.Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class Asteroid : MonoBehaviour
    {
        public int hp = 2;
        public float speed = 3f;
        public float spin = 1f;

        private void OnEnable()
        {
            hp = Mathf.Max(1, hp);
        }
        private void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        public void KillGameObject()
        {
            hp = 2;
            AsteroidPool.Instance.Set(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>()?.Damage(5);
                KillGameObject();
            }
            else if (other.CompareTag("Projectile"))
            {
                hp--;
                if (hp <= 0)
                {
                    KillGameObject();
                }
            }
            else if (other.CompareTag("KillZone") || other.CompareTag("Boundary"))
            {
                KillGameObject();
            }
        }
    }
}

