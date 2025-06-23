using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Items/Potion")]
public class PotionScriptableObject : ItemScriptableObject
{
    [SerializeField] int healAmount;

    /// <summary>
    /// Uses item on target
    /// </summary>
    /// <param name="com"></param>
    /// <returns></returns>
    public override int UseItem(Combatant com)
    {
        
        com.Heal(healAmount); ;
        return time;
    }
}
