using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventorySlot", menuName = "Inventory/Slot")]
public class InventorySlot : ScriptableObject
{
    [SerializeField] ItemScriptableObject item;
    [SerializeField] int quantity;

    /// <summary>
    /// Creates a new InventorySlot
    /// </summary>
    /// <param name="i"></param>
    /// <param name="q"></param>
    public void Create(ItemScriptableObject i, int q)
    {
        item = i;
        quantity = q;
    }

    /// <summary>
    /// Returns the quantity of items
    /// </summary>
    /// <returns></returns>
    public int Quantity()
    {
        return quantity;
    }

    /// <summary>
    /// Returns the item
    /// </summary>
    /// <returns></returns>
    public ItemScriptableObject Item()
    {
        return item;
    }

    /// <summary>
    /// Returns the item name.
    /// </summary>
    /// <returns></returns>
    public string ItemName()
    {
        return item.GetName();
    }

    /// <summary>
    /// Increments the number of items
    /// </summary>
    /// <returns></returns>
    public int Increment()
    {
        return ++quantity;
    }

    /// <summary>
    /// Decrements the number of items(Minimum 0)
    /// </summary>
    /// <returns></returns>
    public int Decrement()
    {
        --quantity;
        if (quantity < 0)
            quantity = 0;

        return quantity;
    }

    /// <summary>
    /// Changes quantity by amt amount
    /// </summary>
    /// <param name="amt"></param>
    /// <returns></returns>
    public int ChangeQuantity(int amt)
    {
        quantity += amt;
        if (quantity < 0)
            quantity = 0;
        return quantity;
    }

    /// <summary>
    /// Returns the sprite associated with the Inventory Slot
    /// </summary>
    /// <returns></returns>
    public Sprite Sprite()
    {
        return item.Sprite();
    }
}
