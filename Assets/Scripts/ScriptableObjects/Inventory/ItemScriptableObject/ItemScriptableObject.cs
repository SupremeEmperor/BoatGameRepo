using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] protected string itemName;
    [SerializeField] protected Animation anim;
    [SerializeField] protected int time;
    [SerializeField] protected Sprite sprite;

    /// <summary>
    /// Uses the item on target.
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public virtual int UseItem(Combatant target)
    {
        return 0;
    }

    /// <summary>
    /// Returns name of the item
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return itemName;
    }

    public Sprite Sprite()
    {
        return sprite;
    }
}
