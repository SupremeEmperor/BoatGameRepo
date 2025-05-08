using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Actions/PourWaterAction")]
public class PourWaterAction : Action
{
    [Space]
    [Tooltip("The object that will find the area the water will be poured on")]
    [SerializeField] protected GameObject waterObject;
    [Space]
    [Tooltip("The amount of trime the water will be poured for")]
    [SerializeField] float waterPourTime = .5f;
    public override float TakeAction(Transform reticlePosition)
    {
        
        GameObject tempWaterArea = GameObject.Instantiate(waterObject, reticlePosition.transform);
        tempWaterArea.GetComponent<WateringCanWaterArea>().SetLifeTime(waterPourTime);

        if(passedAnimator != null)
        {
            passedAnimator.SetTrigger(animationCall);
        }
        return base.TakeAction(reticlePosition);
    }
}
