using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Player
{
    // yatay girise gore geminin gorselini degistirir ve z ekseninde hafif eger.
    // bunu "Body" child'ina ekle ve SpriteRenderer + 3 sprite'i Inspector'dan ata.

    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerVisuals : MonoBehaviour
    {
        [Header("Sprites")]
        public Sprite straightSprite;    // duz
        public Sprite leftSprite;        // sola yatis gorseli
        public Sprite rightSprite;       // saga yatis gorseli

        [Header("Tilt (egme)")]
        public float tiltAngle = 15f;    // maksimum egim (derece)
        public float tiltLerp = 10f;     // hedef aciyi yakalama hizi
        public float deadZone = 0.15f;   // cok kucuk girisleri yok say

        SpriteRenderer _sr;

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
            if (straightSprite != null)
            {
                _sr.sprite = straightSprite;
            }
        }

        private void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");  // klavyeden yatay giris (-1..1)

            // sprite secimi (kucuk titresimleri deadZone ile yok say)
            if (h > deadZone && rightSprite != null)
            {
                _sr.sprite = rightSprite;
            }
            else if (h < -deadZone && leftSprite != null)
            {
                _sr.sprite = leftSprite;
            }
            else if (straightSprite != null)
            {
                _sr.sprite = straightSprite;
            }

            // gorsel egim (z acisi): saga basinca eksi, sola basinca arti
            float targetZ = Mathf.Clamp(-h, -1f, 1f) * tiltAngle;
            var targetRot = Quaternion.Euler(0f, 0f, targetZ);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRot, Time.deltaTime * tiltLerp);

        }


    }
}

