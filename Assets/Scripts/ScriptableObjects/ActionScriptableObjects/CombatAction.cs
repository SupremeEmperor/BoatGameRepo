using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatAction", menuName = "CombatActions/Generic/GenericAction")]
public class CombatAction : ScriptableObject
{
    [Tooltip("The Name of the Action")]
    [SerializeField] protected string actionName;
    [Tooltip("The Number of actions that will take place. (This is ussually one)")]
    [SerializeField] protected int numberOfActions;
    [Space]
    [Tooltip("The animation the attack will use")]
    [SerializeField] protected Animation animation;
    [Space]
    [Tooltip("How long the attack takes in total")]
    [SerializeField] protected float totalActionTime;
    [Space]
    [Tooltip("The amount of time it takes for each action to take affect. /ln (The effect of an action may happen part way through the action)")]
    [SerializeField] protected float[] actionTimes;



    /// <summary>
    /// Takes an action by user against target. 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public virtual float TakeAction(GameObject target, GameObject user)
    {
        return totalActionTime;
    }

    /// <summary>
    /// Returns the name of the combat action.
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return actionName;
    }


}
