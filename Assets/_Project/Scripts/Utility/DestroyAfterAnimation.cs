using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceHustle.Utility
{
    public class DestroyAfterAnimation : MonoBehaviour
    {
        private void Start()
        {
            Animator anim = GetComponent<Animator>();

            if (anim == null || anim.runtimeAnimatorController == null || anim.runtimeAnimatorController.animationClips == null || anim.runtimeAnimatorController.animationClips.Length == 0)
            {
                Destroy(gameObject, 1f);
                return;
            }

            float length = anim.runtimeAnimatorController.animationClips[0].length;
            Destroy(gameObject, length);
        }
    }
}


