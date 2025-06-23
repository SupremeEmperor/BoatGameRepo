using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAction : ScriptableObject
{
    

    virtual public void TakeAction(GameObject caller, GameObject called)
    {
        Debug.Log("Take Action Called in InteractAction");
    }

}