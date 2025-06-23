using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "CombatActions/Generic/GenericAttack")]
public class AttackAction : CombatAction
{
    [Space]
    [Tooltip("What the base damage of the attack will be multiplied by.")]
    [SerializeField] protected float damageMultiplier;
    [Space]
    [Tooltip("The type of damage the attack will use.")]
    [SerializeField] protected DamageTypes damageType;
    [Space]
    [SerializeField] protected bool magic;

    /// <summary>
    /// Takes an action by user against target. 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="user"></param>
    /// <returns>The amount of time it takes for the action to complete</returns>
    override public float TakeAction(GameObject target, GameObject user)
    {
        int damageHolder;
        if(target == null || target.GetComponent<Combatant>() == null)
        {
            Debug.Log("No target given for " + this);
            return 0;
        }

        if (user == null || target.GetComponent<Combatant>() == null)
        {
            Debug.Log("No user given for " + this);
            return 0;
        }
        if (magic)
        {
            damageHolder = target.GetComponent<Combatant>().DealDamage((int)(damageMultiplier * user.GetComponent<Combatant>().GetMagicalPower()), damageType);
        }
        else
        {
            damageHolder = target.GetComponent<Combatant>().DealDamage((int)(damageMultiplier * user.GetComponent<Combatant>().GetPhysicalPower()), damageType);
        }

        GameObject tempGameObject = GameObject.Find("InformationTab");
        if (tempGameObject != null)
        {
            if(tempGameObject.GetComponent<InformationTab>() != null)
            {
                tempGameObject.GetComponent<InformationTab>().SetUp(user.GetComponent<Combatant>().GetName() + " used " + GetName() + " against " + target.GetComponent<Combatant>().GetName() + " for " + damageHolder + " damage." );
            }
        }
        return totalActionTime;
    }
}
