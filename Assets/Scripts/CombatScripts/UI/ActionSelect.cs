using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelect : MonoBehaviour
{
    [SerializeField] GameObject baseActions;
    [SerializeField] GameObject combatActionUI;
    [SerializeField] GameObject itemSelectUI;
    [SerializeField] GameObject targetSelect;

    /// <summary>
    /// Returns the BaseActions GameObject
    /// </summary>
    /// <returns></returns>
    public GameObject BaseActions()
    {
        return baseActions;
    }

    /// <summary>
    /// Returns the CombatActionUI GameObject
    /// </summary>
    /// <returns></returns>
    public GameObject CombatActionUI()
    {
        return combatActionUI;
    }

    /// <summary>
    /// Returns the ItemSelectUI GameObject
    /// </summary>
    /// <returns></returns>
    public GameObject ItemSelectUI()
    {
        return itemSelectUI;
    }

    /// <summary>
    /// Returns the TargetSelect GameObject
    /// </summary>
    /// <returns></returns>
    public GameObject TargetSelect()
    {
        return targetSelect;
    }
}
