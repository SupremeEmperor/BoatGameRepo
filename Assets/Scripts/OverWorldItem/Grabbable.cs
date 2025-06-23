using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] Action action;
    [SerializeField] bool singleUse;
    [SerializeField] Animator animator;
    [SerializeField] float timeUntilDestroy = 1;

    public Action GetAction()
    {
        if(singleUse)
            Destroy(this.gameObject, timeUntilDestroy);
        return action;
    }

    public bool IsSingleUse()
    {
        return singleUse;
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
