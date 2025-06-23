using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionButton : Button
{
    [SerializeField] CombatAction combatAction;
    Combatant combatant;
    [SerializeField] Combatant target;
    [SerializeField] TextMeshProUGUI nameText;

    /// <summary>
    /// Called when this button is made so it can have the apropriate information.
    /// </summary>
    /// <param name="ca">The combat Action this button will call</param>
    /// <param name="c">The combatant who is using the action</param>
    public void SetUp(CombatAction ca, Combatant c)
    {
        combatAction = ca;
        combatant = c;
        nameText.text = combatAction.GetName();
    }

    /// <summary>
    /// Called when the button is pressed.
    /// </summary>
    public override void PressButton()
    {

        GameObject temp = GameObject.Find("ActionSelect").GetComponent<ActionSelect>().TargetSelect();
        temp.SetActive(true);
        temp.GetComponent<TargetSelect>().SetUP(this.gameObject, GameObject.Find("CombatActionUI"));
        GameObject.Find("CombatActionUI").SetActive(false);
        
    }


    /// <summary>
    /// Called when the logic of the button is done.
    /// </summary>
    public override void FinishButton()
    {
        float temp = combatAction.TakeAction(GameObject.Find("CombatController").GetComponent<CombatController>().GetTarget().gameObject,
            combatant.gameObject);
        GameObject.Find("CombatController").GetComponent<CombatController>().EndTurn(temp);
        GameObject.Find("ActionSelect").GetComponent<ActionSelect>().CombatActionUI().SetActive(false);
    }
}
