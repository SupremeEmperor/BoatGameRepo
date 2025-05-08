using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryActionMotor : MonoBehaviour
{
    [SerializeField] float actionDelayTime = 0.5f;
    float timeOfLastAction = 0;
    [SerializeField] GameObject heldObject;
    [SerializeField] GameObject targetReticle;
    bool wasTrigger;
    bool wasKinematic;
    

    internal void Action(float v)
    {
        if(v != 0 && Time.time - timeOfLastAction > actionDelayTime)
        {

            if (heldObject != null)
            {
                UseAction();
            }
            else
            {
                Grab();
            }
            timeOfLastAction = Time.time;
        } 
        
    }

    private void UseAction()
    {
       
        if (heldObject.GetComponent<Grabbable>().IsSingleUse())
        {
            heldObject.transform.parent = null;
        }
        if (heldObject.GetComponent<Grabbable>().GetAction() != null)
        {
            if (heldObject.GetComponent<Grabbable>().GetAnimator() != null)
            {
                heldObject.GetComponent<Grabbable>().GetAction().TakeAction(targetReticle.transform,
                    heldObject.GetComponent<Grabbable>().GetAnimator()); 
            } else
                heldObject.GetComponent<Grabbable>().GetAction().TakeAction(targetReticle.transform);
        }
        
    }

    private void Grab()
    {
        heldObject = targetReticle.GetComponent<TargetReticleFindGrabbable>().GetGrabbable();
        if(heldObject != null)
        {
            if(heldObject.GetComponent<Grabbable>().GetAnimator() != null)
            {
                heldObject.GetComponent<Grabbable>().GetAnimator().SetTrigger("Grab");
            }
            heldObject.transform.position = targetReticle.transform.position;
            heldObject.transform.rotation = targetReticle.transform.rotation;
            heldObject.transform.parent = targetReticle.transform;
            if(heldObject.GetComponent<Rigidbody>() != null)
            {
                wasKinematic = heldObject.GetComponent<Rigidbody>().isKinematic;
                heldObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            wasTrigger = heldObject.GetComponent<Collider>().isTrigger;
            heldObject.GetComponent<Collider>().isTrigger = true;
        }
        
    }

    internal void Release(float v)
    {
        if(heldObject != null && v != 0)
        {
            if (heldObject.GetComponent<Grabbable>().GetAnimator() != null)
            {
                heldObject.GetComponent<Grabbable>().GetAnimator().SetTrigger("Release");
            }
            if (heldObject.GetComponent<Rigidbody>() != null)
            {
                heldObject.GetComponent<Rigidbody>().isKinematic = wasKinematic;
            }
            heldObject.GetComponent<Collider>().isTrigger = wasTrigger;
            heldObject.transform.parent = null;
            heldObject = null;
        }
    }
}
