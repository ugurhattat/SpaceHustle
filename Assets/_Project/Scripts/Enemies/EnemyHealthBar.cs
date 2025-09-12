using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Enemies
{
    // Healthbar (holder) dusmanin child'idir.
    // 'bar' Transform'unun localScale.x'i, HP oranina gore her frame ayarlanir.
    // tum referanslar Inspector'da elle atanir.
    public class EnemyHealthBar : MonoBehaviour
    {
        [Header("Refs")]
        public EnemyHealth target;      // Enemy01 uzerindeki EnemyHealth elle surukle
        public Transform bar;           // HealthBar/Bar elle surukle

        [Header("Layout")]
        public Vector3 offset = new Vector3(0f, 0.33f, 0f);  //dusmanin ustunde

        Vector3 _barBaseScale;  // editorde verdigin baslangic olcegi

        private void Awake()
        {
            if (target == null || bar == null)
            {
                enabled = false;
                Debug.LogWarning("[EnemyHealthBar] Target veya Bar atanmadi.");
                return;
            }

            _barBaseScale = bar.localScale;  // editorde verdigin olcegi sakla
        }

        private void LateUpdate()  // dusman pozisyonu update/fixed update'de hareket ettirilmis olabilir.Bar'i en son local offset'e oturtmak, frame icinde kaymamasini saglar.
        {
            transform.localPosition = offset;  //holderi ustte sabit tut

            float t = (target.maxHealth <= 0) ? 0f : target.Current / (float)target.maxHealth; //hp orani
            t = Mathf.Clamp01(t);

            bar.localScale = new Vector3(_barBaseScale.x * t, bar.localScale.y, bar.localScale.z);
        }
    }
}