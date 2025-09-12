using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Projectiles;

namespace SpaceHustle.Player
{
    public enum FireMode { Single, Double, TripleSpread }
    //Space basili tutulunca mermi uretir. Fire mode/power-up seviyesine gore
    //tekli,ciftli veya yayli atis yapar. simdilik poolsuz (instantiate)
    //sonrada pool'a gecmek icin sadece SpawnProjectile() metodunu degistiricez
    public class PlayerShoot : MonoBehaviour
    {
        [Header("References")]
        public GameObject projectilePrefab;  //kullanilacak mermi prerfabi
        public Transform firePoint;  //ucagin burnu (child)

        [Header("Fire Settings")]
        public float fireRate = 8f;              // saniyede mermi
        public int baseDamage = 1;               // seviye 1 hasari
        public FireMode mode = FireMode.Single;  // atis sekli
        public int weaponLevel = 1;              // power-up ile artacak (1..5 gibi)

        float _nextFireTime;

        private void Update()
        {
            if(Input.GetKey(KeyCode.Space) && Time.time >= _nextFireTime)
            {
                Fire();
                _nextFireTime = Time.time + 1f / fireRate;
            }
        }

        private void Fire()
        {
            int dmg = baseDamage + Mathf.Max(0, weaponLevel - 1); // level'a gore hasari olcekle (cok basit ornek)

            switch (mode)
            {
                case FireMode.Single:
                    SpawnProjectile(firePoint.position, Vector2.up, dmg);
                    break;
                case FireMode.Double: // burnun sag/solundan paralel
                    float off = 0.2f; // yatay offset
                    SpawnProjectile(firePoint.position + Vector3.left * off, Vector2.up, dmg);
                    SpawnProjectile(firePoint.position + Vector3.right * off, Vector2.up, dmg);
                    break;

                case FireMode.TripleSpread: // 3'lu yay
                    SpawnProjectile(firePoint.position, Vector2.up, dmg);
                    SpawnProjectile(firePoint.position, (Quaternion.Euler(0, 0, -10) * Vector2.up), dmg);
                    SpawnProjectile(firePoint.position, (Quaternion.Euler(0, 0, +10) * Vector2.up), dmg);
                    break;
            }
        }

        private void SpawnProjectile(Vector3 pos, Vector2 dir, int damage)  // suan instantiate. ileride pool'a gecmek istersek burayi degistiricez.
        {
            var go = Instantiate(projectilePrefab, pos, Quaternion.identity);
            var p = go.GetComponent<Projectile>();
            p.direction = dir;
            p.damage = damage;
        }

        // Powwer-up icin basit API
        public void AddLevel(int amount = 1) => weaponLevel = Mathf.Clamp(weaponLevel + amount, 1, 5);
        public void SetMode(FireMode newMode) => mode = newMode;
    }

}


