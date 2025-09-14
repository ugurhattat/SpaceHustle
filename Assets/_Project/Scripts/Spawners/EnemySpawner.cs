using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Core;
using SpaceHustle.Enemies;

namespace SpaceHustle.Spawners
{
    public class EnemySpawner : BaseSpawner
    {
        protected override void Spawn()
        {
            if (EnemyPool.Instance == null) return;

            EnemyMover newEnemy = EnemyPool.Instance.Get();
            newEnemy.transform.position = transform.position;
            newEnemy.gameObject.SetActive(true);
        }
    }
}

