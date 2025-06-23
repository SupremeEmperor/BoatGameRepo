using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePotion : MonoBehaviour
{
    [SerializeField] ItemScriptableObject potion;

    public void PressButton()
    {
        GameObject.Find("CombatController").GetComponent<CombatController>().GetInventory().AddItem(potion, 1);
    }
}
