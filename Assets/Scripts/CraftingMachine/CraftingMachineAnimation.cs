using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NOOD;

namespace Game
{
    public class CraftingMachineAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void StartCraftAnimation()
        {
            animator.SetBool("Craft", true);

            NoodyCustomCode.StartDelayFunction(() => {animator.SetBool("Craft", false);}, 0.1f);
        }

        public float GetCurrentAnimationTime()
        {
            return animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }

}
