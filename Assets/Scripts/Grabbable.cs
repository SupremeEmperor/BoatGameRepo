using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] Action action;
    [SerializeField] bool singleUse;

    public Action GetAction()
    {
        if(singleUse)
            Destroy(this.gameObject, .25f);
        return action;
    }

    public bool IsSingleUse()
    {
        return singleUse;
    }
}
