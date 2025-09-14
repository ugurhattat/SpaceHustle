using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Enemies;

namespace SpaceHustle.Core
{
    public class EnemyPool : GenericPool<EnemyMover>
    {
        public static EnemyPool Instance { get; private set; }

        public override void ResetAllObjects()
        {
            foreach (EnemyMover child in GetComponentsInChildren<EnemyMover>())
            {
                if (!child.gameObject.activeSelf) continue;

                child.KillGameObject();
            }
        }

        protected override void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}

