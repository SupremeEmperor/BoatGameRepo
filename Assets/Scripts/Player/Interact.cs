using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] TargetReticleFindGrabbable trfg;
    public void Act(float flt)
    {
        
        if (trfg.GetInteractable() != null && flt != 0)
        {
            Debug.Log("Interact.Act() is being called");

            Debug.Log(trfg.GetInteractable().GetComponent<Interactable>() );
            if (trfg.GetInteractable().GetComponent<Interactable>() != null)
                trfg.GetInteractable().GetComponent<Interactable>().Interact(gameObject);
            
        }
            
    }
}
