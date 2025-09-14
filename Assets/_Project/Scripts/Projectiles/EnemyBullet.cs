using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Core;
using SpaceHustle.Player;
using System;

namespace SpaceHustle.Projectiles
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyBullet : MonoBehaviour
    {
        public float speed = 8f;

        private void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        public void KillGameObject() => BulletPool.Instance.Set(this);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>()?.Damage(1);
                BulletPool.Instance.Set(this);
            }
            else if (other.CompareTag("KillZone") || other.CompareTag("Boundary"))
            {
                BulletPool.Instance.Set(this);
            }
        }
    }
}

