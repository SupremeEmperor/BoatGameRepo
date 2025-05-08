using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Actions/PlantAction")]
public class PlantAction : Action
{
    [Space]
    [Tooltip("The plant this action will spawn")]
    [SerializeField] protected GameObject plantObject;

    public override float TakeAction(Transform reticlePosition)
    {
        GameObject tempPlant = GameObject.Instantiate(plantObject, reticlePosition.transform);

        /** 
         *Sets the position of the spawned object to the position of the targetReticle then subtracts one from y
         **/
        tempPlant.transform.position = tempPlant.transform.parent.position + new Vector3(0, -1, 0);

        /**
         * Removes the targetReticle as the parent
         **/
        if(passedAnimator != null)
        {
            passedAnimator.SetTrigger(animationCall);
        }
        tempPlant.transform.parent = null;
        return totalActionTime;
    }
}
