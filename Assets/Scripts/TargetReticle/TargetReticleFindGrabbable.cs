using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticleFindGrabbable : MonoBehaviour
{
    GameObject grabbable;
    GameObject interactable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Grabbable>() != null)
        {
            grabbable = other.gameObject;
        }

        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            interactable = other.gameObject;
            Debug.Log("TargetReticle found Interactable");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == grabbable)
        {
            grabbable = null;
        }

        if (other.gameObject == interactable)
        {
            interactable = null;
        }
    }

    public GameObject GetGrabbable()
    {
        return grabbable;
    }

    public GameObject GetInteractable()
    {
        return interactable;
    }
}
