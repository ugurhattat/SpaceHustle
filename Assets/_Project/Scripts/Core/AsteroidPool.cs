using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Enemies;

namespace SpaceHustle.Core
{
    public class AsteroidPool : GenericPool<Asteroid>
    {
        public static AsteroidPool Instance { get; private set; }

        public override void ResetAllObjects()
        {
            foreach(Asteroid child in GetComponentsInChildren<Asteroid>())
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