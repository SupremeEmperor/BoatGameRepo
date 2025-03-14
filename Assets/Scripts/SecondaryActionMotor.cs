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
    

    internal void Action(float v)
    {
        if(v != 0 && Time.time - timeOfLastAction > actionDelayTime)
        {

            if (heldObject != null)
            {
                heldObject.GetComponent<Grabbable>().GetAction().TakeAction(targetReticle.transform);
               
            }
            else
            {
                Grab();
            }
            timeOfLastAction = Time.time;
        } 
        
    }

    private void Grab()
    {
        heldObject = targetReticle.GetComponent<TargetReticleFindGrabbable>().GetGrabbable();
        if(heldObject != null)
        {
            heldObject.transform.position = targetReticle.transform.position;
            heldObject.transform.parent = targetReticle.transform;
            heldObject.GetComponent<Collider>().isTrigger = true;
        }
        
    }

    internal void Release(float v)
    {
        if(heldObject != null && v != 0)
        {
            heldObject.transform.parent = null;
            heldObject = null;
        }
    }
}
