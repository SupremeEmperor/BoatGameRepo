using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryActionMotor : MonoBehaviour
{
    [SerializeField] float actionDelayTime = 0.5f;
    float timeOfLastAction = 0;
    [SerializeField] GameObject plant;
    [SerializeField] GameObject targetReticle;
    

    internal void Action(float v)
    {
        if(v != 0 && Time.time - timeOfLastAction > actionDelayTime)
        {
            GameObject tempPlant = GameObject.Instantiate(plant, targetReticle.transform);

            /** 
             *Sets the position of the spawned object to the position of the targetReticle then subtracts one from y
             **/
            tempPlant.transform.position = tempPlant.transform.parent.position + new Vector3(0,-1,0);

            /**
             * Removes the targetReticle as the parent
             **/
            tempPlant.transform.parent = null;
            timeOfLastAction = Time.time;
        } 
        
    }
}
