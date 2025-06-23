using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Generic")]
public class Inventory : ScriptableObject
{
    [SerializeField] List<InventorySlot> items;

    /// <summary>
    /// Returns the list of InventorySlots in the inventory.
    /// </summary>
    /// <returns></returns>
    public List<InventorySlot> GetList()
    {
        List<InventorySlot> temp = new List<InventorySlot>();
        foreach(InventorySlot islot in items)
        {
            if (islot.Quantity() > 0)
                temp.Add(islot);
        }
        return temp;
    }
    
    /// <summary>
    /// Uses the item passed if possible
    /// </summary>
    /// <param name="iso"></param>
    /// <returns>False if the item could not be used.</returns>
    public bool UseItem(ItemScriptableObject iso)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemName() == iso.GetName())
            {
                items[i].Decrement();
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Adds a number of items to the Inventory.
    /// </summary>
    /// <param name="iso"></param>
    /// <param name="amnt"></param>
    public void AddItem(ItemScriptableObject iso, int amnt)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemName() == iso.GetName())
            {
                items[i].ChangeQuantity(amnt);
                return;
            }
        }
        InventorySlot tempIS = ScriptableObject.CreateInstance<InventorySlot>();
        tempIS.Create(iso,amnt);
        items.Add(tempIS);
    }

    /// <summary>
    /// Returns the number of items of type iso
    /// </summary>
    /// <param name="iso"></param>
    /// <returns></returns>
    public int ItemAmount(ItemScriptableObject iso)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemName() == iso.GetName())
            {
                return items[i].Quantity();
            }
        }
        return 0;
    }

    /// <summary>
    /// returns true if iso is on the list
    /// </summary>
    /// <param name="iso"></param>
    /// <returns></returns>
    public bool CheckForItem(ItemScriptableObject iso)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemName() == iso.GetName() && items[i].Quantity() != 0)
            {
                return true;
            }
        }
        return false;
    }

    public void ChangePosition(List<InventorySlot> newPositions)
    {
        foreach (InventorySlot slot in items)
        {
            if (!newPositions.Contains(slot))
            {
                newPositions.Add(slot);
            }
        }
        items = newPositions;
    }
}
