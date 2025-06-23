using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseActionsScript : MonoBehaviour
{
    [SerializeField] private GameObject previousUI;
    [SerializeField] private GameObject thisUI;
    [SerializeField] private GameObject combatActionUI;
    [SerializeField] private GameObject itemUI;
    [SerializeField] private CombatController combatController;

    

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    /// <summary>
    /// Called when the action Button is pressed.
    /// </summary>
    public void ActionButton()
    {
        combatActionUI.SetActive(true);
        if(combatActionUI.GetComponent<CombatActionUI>() != null)
        {
            combatActionUI.GetComponent<CombatActionUI>().SetCombatant(combatController.GetActiveCombatant().GetComponent<Combatant>());
        }
        thisUI.SetActive(false);
    }


    /// <summary>
    /// Called when the Item Button is pressed
    /// </summary>
    public void ItemButton()
    {
        itemUI.SetActive(true);
        if (itemUI.GetComponent<CombatItemUI>() != null)
        {
            itemUI.GetComponent<CombatItemUI>().SetUp();
        }
        thisUI.SetActive(false);
    }
}
