using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.VFX
{
    public class ExhaustPulse : MonoBehaviour // player dikey hizina gore egzoz buyuklugunu nazikce degistirir.
    {
        public Rigidbody2D playerRb;  // player'in RigidBody2D'sini surukle
        public float baseScale = 1f;  // normal olcek
        public float scaleBySpeed = 0.2f;  // hiz basina ek olcek

        private void LateUpdate()
        {
            if (!playerRb) return;
            float s = baseScale + Mathf.Clamp01(Mathf.Abs(playerRb.velocity.y)) * scaleBySpeed;
            transform.localScale = new Vector3(1f, s, 1f);
        }
    }
}

