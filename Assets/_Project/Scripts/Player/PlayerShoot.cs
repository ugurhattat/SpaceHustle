using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceHustle.Projectiles;

namespace SpaceHustle.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform firePoint;  //Player'in child'i
        public float fireRate = 8f;  //saniyede mermi
        float _next;

        private void Update()
        {
            if(Input.GetKey(KeyCode.Space) && Time.time >= _next)
            {
                var go = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
                var p = go.GetComponent<Projectile>();
                p.direction = Vector2.up; //dikey gidecek mermi
                _next = Time.time + 1f / fireRate;
            }
        }
    }
}


