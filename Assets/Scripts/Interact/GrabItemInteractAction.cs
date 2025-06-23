using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrabItem", menuName = "InteractAction")]
public class GrabItemInteractAction : InteractAction
{
    
    override public void TakeAction(GameObject caller, GameObject called)
    {
        if(called == null)
        {
            Debug.Log("Called is null");
            return;
        }
        if (called.GetComponent<ItemHolder>() == null || GameObject.Find("InformationHolder") == null)
        {
            return;
        }
        ItemScriptableObject item = called.GetComponent<ItemHolder>().GetItem();
        int amnt = called.GetComponent<ItemHolder>().GetAmount();
        Inventory inventory = GameObject.Find("InformationHolder").GetComponent<InformationHolder>().Inventory();
        inventory.AddItem(item, amnt);
        Destroy(called);
    }
}
