using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

internal class ItemButton : Button
{
    [SerializeField] ItemScriptableObject item;
    Combatant combatant;
    [SerializeField] Combatant target;
    [SerializeField] TextMeshProUGUI nameText;
    Inventory inventory;

    /// <summary>
    /// Sets up the button with the item in InventorySlot ca
    /// </summary>
    /// <param name="ca"></param>
    public void SetUp(InventorySlot ca)
    {
        item = ca.Item();
        nameText.text = item.GetName() + " (" + ca.Quantity() + ")";
        inventory = GameObject.Find("CombatController").GetComponent<CombatController>().GetInventory();
    }

    /// <summary>
    /// Called when the button is pressed.
    /// </summary>
    public override void PressButton()
    {
        if (inventory.CheckForItem(item))
        {
            GameObject temp = GameObject.Find("ActionSelect").GetComponent<ActionSelect>().TargetSelect();
            temp.SetActive(true);
            temp.GetComponent<TargetSelect>().SetUP(this.gameObject, GameObject.Find("ItemSelectUI"));
            GameObject.Find("ItemSelectUI").SetActive(false);
        }

        
    }

    /// <summary>
    /// Called when the item should be used.
    /// </summary>
    public override void FinishButton()
    {
        inventory.UseItem(item);
        float temp = item.UseItem(GameObject.Find("CombatController").GetComponent<CombatController>().GetTarget().GetComponent<Combatant>());
        GameObject.Find("CombatController").GetComponent<CombatController>().EndTurn(temp);
        //Should bprobably tell the active combatant to play an animation.

        GameObject.Find("ItemSelectUI").SetActive(false);
    }
}