using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Core;
using SpaceHustle.Enemies;

namespace SpaceHustle.Spawners
{
    public class AsteroidSpawner : BaseSpawner
    {
        protected override void Spawn()
        {
            if (AsteroidPool.Instance == null) return;

            Asteroid newEnemy = AsteroidPool.Instance.Get();
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
        }
    }
}

