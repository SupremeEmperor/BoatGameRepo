using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] ItemScriptableObject item;
    [SerializeField] int amount = 1;

    public ItemScriptableObject GetItem()
    {
        return item;
    }

    public int GetAmount()
    {
        return amount;
    }
}
