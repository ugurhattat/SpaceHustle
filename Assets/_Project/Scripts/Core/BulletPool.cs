using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Projectiles;

namespace SpaceHustle.Core
{
    public class BulletPool : GenericPool<EnemyBullet>
    {
        public static BulletPool Instance { get; private set; }

        public override void ResetAllObjects()
        {
            foreach (EnemyBullet child in GetComponentsInChildren<EnemyBullet>())
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

