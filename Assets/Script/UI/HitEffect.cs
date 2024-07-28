using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void CheckAnimation()
    {
        StartCoroutine(CheckAnimationDone());
    }

    IEnumerator CheckAnimationDone()
    {
        yield return new WaitForSeconds(1f);  
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
