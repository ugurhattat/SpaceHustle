using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Managers
{
    public class BackgroundPairAligner : MonoBehaviour
    {
        public Transform bgA; // Alttaki
        public Transform bgB; // Üstteki

        private void Start()
        {
            // bgA'nın yüksekliğini hesapla
            var sr = bgA.GetComponentInChildren<SpriteRenderer>();
            float h = sr.sprite.bounds.size.y * bgA.localScale.y;

            // Yerlerini ayarla
            bgA.localPosition = new Vector3(0f, 0f, 0f);
            bgB.localPosition = new Vector3(0f, h, 0f);
        }
    }
}