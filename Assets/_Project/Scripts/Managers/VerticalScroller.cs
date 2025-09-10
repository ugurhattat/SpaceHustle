using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Managers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class VerticalScroller : MonoBehaviour
    {
        [Tooltip("Dunya birimi/sn")]
        public float speed = 1.5f;
        public float tileHeight {  get; private set; } // Otomatik hesaplanir(SpriteRenderer.bounds.size.y scale dahil gercek yükseklik)

        SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            tileHeight = sr.bounds.size.y;
        }

        private void Update()
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime); // asagi dogru kaydirir

            if (transform.position.y <= -tileHeight)
            {
                transform.position += Vector3.up * (2f * tileHeight); //iki parca kullandigimiz icin, parca -tileHeight altina inerse 2*tileHeight yukari ziplat
            }
        }
    }
}


