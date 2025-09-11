using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Managers
{
    public class VerticalScroller : MonoBehaviour
    {
        public float speed = 1.5f;   // Kayma hızı
        public float tileHeight;     // Sprite yüksekliği

        private void Start()
        {
            // Sprite yüksekliğini hesapla
            var sr = GetComponent<SpriteRenderer>();
            tileHeight = sr.sprite.bounds.size.y * transform.localScale.y;
        }

        private void Update()
        {
            // Aşağı kaydır
            transform.localPosition += Vector3.down * speed * Time.deltaTime;

            // Eğer çok aşağı indiysen yukarıya sar
            if (transform.localPosition.y <= -tileHeight)
            {
                transform.localPosition += Vector3.up * 2f * tileHeight;
            }
        }
    }
}