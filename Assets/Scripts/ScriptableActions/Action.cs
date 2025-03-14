using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Action : ScriptableObject
{
    [Tooltip("The Name of the Action")]
    [SerializeField] protected string actionName;
    [Tooltip("The Number of actions that will take place. (This is ussually one)")]
    [SerializeField] protected int numberOfActions;
    [Space]
    [Tooltip("How long the action takes in total")]
    [SerializeField] protected float totalActionTime;
    
    // Start is called before the first frame update
    public virtual float TakeAction(Transform reticlePosition)
    {
        return totalActionTime;
    }
}
