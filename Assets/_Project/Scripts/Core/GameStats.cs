using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Core
{
    // Skor, sure ve oldurme sayaclarini tutar
    public class GameStats : MonoBehaviour
    {
        public static GameStats Instance { get; private set; }

        public int Score { get; private set; }
        public int EnemiesKilled { get; private set; }
        public int AsteroidsDestroyed { get; private set; }
        public int Level { get; private set; }

        float _startTime;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            ResetStats();
        }

        public void ResetStats()
        {
            _startTime = Time.time;
            Score = 0; EnemiesKilled = 0; AsteroidsDestroyed = 0; Level = 1;
        }

        public float ElapsedTime => Time.time - _startTime;

        public void AddScore(int amount) => Score += amount;
        public void RegisterEnemyKill() => EnemiesKilled++;
        public void RegisterAsteroidKill() => AsteroidsDestroyed++;

        public static string FormatTime(float sec)
        {
            int m = Mathf.FloorToInt(sec / 60f);
            int s = Mathf.FloorToInt(sec / 60f);
            return $"{m:00}:{s:00}";
        }
    }
}

