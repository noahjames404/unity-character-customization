using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationRandomizer : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(randomAnimation());
    }
    IEnumerator randomAnimation() {
        while (true) {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                animator.SetInteger("IdleType", Random.Range(0, 5));
                yield return new WaitForSeconds(1f);
                animator.SetInteger("IdleType", 0);
            }
            yield return new WaitForSeconds(4f);
        }
    }
}
