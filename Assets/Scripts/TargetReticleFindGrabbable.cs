using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticleFindGrabbable : MonoBehaviour
{
    GameObject grabbable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Grabbable>() != null)
        {
            grabbable = other.gameObject;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == grabbable)
        {
            grabbable = null;
        }
    }

    public GameObject GetGrabbable()
    {
        return grabbable;
    }
}
