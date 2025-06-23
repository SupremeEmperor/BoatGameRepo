using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCombatant : Combatant
{
    [SerializeField] bool testMode;
    [SerializeField] ActionTypes actionTendancy;
    [SerializeField] List<CombatAction> buffActions;
    [SerializeField] List<CombatAction> debuffActions;
    [SerializeField] List<CombatAction> attackActions;
    int[] randomizer = { 0, 0, 0, 1, 1, 2 };

    //Tells the combatant to take their turn. Returns false if the combatant is a player.
    /// <summary>
    /// Tells the combatant to take their turn. Returns the amount of time the turn will take.
    /// </summary>
    /// <returns></returns>
    public override float TakeTurn()
    {
        if (testMode)
        {
            return -1f;
        }
        return ChooseAction();
    }

    /// <summary>
    /// Returns pertinant combatant info as a string.
    /// </summary>
    /// <returns></returns>
    public override string InfoToString()
    {
        return "Enemy: " + GetName() + " '" + GetLevel() + "' " + GetCurrentHealth() + "/" + GetMaxHealth(); ;
    }

    /// <summary>
    /// Chooses a target.
    /// </summary>
    /// <param name="buffTarget">if true it will try to buff an ally</param>
    void ChooseTarget(bool buffTarget)
    {
        //Probably need better code for selecting targets
        CombatController combatController = GameObject.Find("CombatController").GetComponent<CombatController>();
        List<GameObject> posibleTargets;
        if (buffTarget)
        {
            posibleTargets = combatController.EnemyCombatants();

            //Check if any target has 20% or less health
            for(int i = 0; i < posibleTargets.Count; i++)
            {
                if (((float)posibleTargets[i].GetComponent<Combatant>().GetCurrentHealth()/
                    (float)posibleTargets[i].GetComponent<Combatant>().GetMaxHealth()) >= .2
                    && (float)posibleTargets[i].GetComponent<Combatant>().GetCurrentHealth() != 0)
                {
                    combatController.SetTarget(posibleTargets[i]);
                    return;
                }
            }
            combatController.SetTarget(this.gameObject);
            return;
        } else
        {
            posibleTargets = combatController.PlayerCombatants();
            int select = Random.Range(0, posibleTargets.Count);
            if (select == posibleTargets.Count)
            {
                select--;
            }
            combatController.SetTarget(posibleTargets[select]);
        }
    }

    /// <summary>
    /// Decides wich action it should take.
    /// </summary>
    /// <returns>Returns the amount of time it will take to use the action</returns>
    public float ChooseAction()
    {
        int select = Random.Range(0, randomizer.Length);
        CombatAction combatAction = attackActions[0];
        

        if (actionTendancy + randomizer[select] <= ActionTypes.Buff)
        {
            if(buffActions.Count > 0)
            {
                ChooseTarget(true);
                combatAction = buffActions[0];
                buffActions.Add(buffActions[0]);
                buffActions.RemoveAt(0);
            }
        }
        else if (actionTendancy + randomizer[select] <= ActionTypes.Debuff)
        {
            if (debuffActions.Count > 0)
            {
                ChooseTarget(false);
                combatAction = debuffActions[0];
                debuffActions.Add(debuffActions[0]);
                debuffActions.RemoveAt(0);
            }
        }
        else
        {
            
                ChooseTarget(false);
                combatAction = attackActions[0];
                attackActions.Add(attackActions[0]);
                attackActions.RemoveAt(0);
            
        }
        
        CombatController combatController = GameObject.Find("CombatController").GetComponent<CombatController>();

        
        return combatAction.TakeAction(combatController.GetTarget().gameObject, combatController.GetActiveCombatant());
    }

}
