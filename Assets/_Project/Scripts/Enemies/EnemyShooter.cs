using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Core;

namespace SpaceHustle.Enemies
{
    public class EnemyShooter : MonoBehaviour
    {
        public Transform firePoint;

        [Header("Fire Interval (seconds)")]
        public float minInterval = 1.2f;
        public float maxInterval = 2.4f;

        [Header("Start Offset / Miss Chance")]
        public Vector2 startOffsetRange = new Vector2(0f, 1.2f); // ilk atis gecikmesi
        [Range(0f, 1f)] public float missChance = 0.15f;         // %15 ihtimalle atis yapmaz

        float _next;

        private void OnEnable()
        {
            _next = Time.time + Random.Range(startOffsetRange.x, startOffsetRange.y);
        }

        private void Update()
        {
            if(firePoint == null || BulletPool.Instance == null)
            {
                return;
            }
            if (Time.time >= _next)
            {
                _next = Time.time + Random.Range(minInterval, maxInterval);

                if (Random.value < missChance) return;  // bazen atis pas gecilsin

                var b = BulletPool.Instance.Get();
                b.transform.SetPositionAndRotation(firePoint.position, Quaternion.identity);
                b.gameObject.SetActive(true);
            }
        }
    }
}

