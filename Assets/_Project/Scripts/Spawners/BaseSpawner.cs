using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Spawners
{
    // tek bir noktadan, min/max araliginda periyodik spawn yapar.
    public abstract class BaseSpawner : MonoBehaviour
    {
        [Header("Spawn Interval (seconds)")]
        [SerializeField, Range(3f, 5f)] private float minSpawnTime = 3.5f;
        [SerializeField, Range(7f, 10f)] private float maxSpawnTime = 8.0f;

        [Header("Start Offset")]
        [SerializeField] Vector2 startDelayRange = new Vector2(0f, 1.5f);

        float _timer;
        float _next;

        private void Start()
        {
            _timer = -Random.Range(startDelayRange.x, startDelayRange.y);
            ResetTimer();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _next)
            {
                Spawn();
                ResetTimer();
            }
        }

        protected abstract void Spawn();

        private void ResetTimer()
        {
            _timer = 0f;
            _next = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}

