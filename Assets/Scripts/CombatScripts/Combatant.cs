using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    [SerializeField] private string combatantName;
    [Space]
    [SerializeField] private Sprite sprite;
    [Space]
    [SerializeField] private int level;
    [Space]
    [SerializeField] private int maxHealth;
    [Space]
    [SerializeField] private int currentHealth;
    [Space]
    [SerializeField] private int maxMana;
    [Space]
    [SerializeField] private int currentMana;
    [Space]
    [SerializeField] private int speed;
    [Space]
    [SerializeField] private int accuracy;
    [Space]
    [SerializeField] private int evasion;
    [Space]
    [SerializeField] private int physicalPower;
    [Space]
    [SerializeField] private int magicalPower;
    [Space]
    [SerializeField] private List<int> damageResistances;
    [Space]
    [SerializeField] private float physicalBuff;
    [Space]
    [SerializeField] private List<CombatAction> combatActions = new List<CombatAction>();
    private bool activeCombat = false;
    
    public void SetStats()
    {

    }

    private void Update()
    {
        if (activeCombat)
        {
            
        }
        
    }

    ///<summary>
    ///When called sets the combatant to Active Combat mode if passed true.
    ///Turns off Active Combat mode if passed false.
    ///</summary>
    public void ActiveCombat(bool ac)
    {
        activeCombat = ac;
    }

    ///<summary>Tells the combatant to take their turn. Returns false if the combatant is a player.</summary>
    public virtual float TakeTurn()
    {
        return -1f;
    }

    ///<summary>Deal a given amount of damage ignoring all defences.</summary>
    public int dealDamage(int damageAmount)
    {
        if (damageAmount > 0)
        {
            ChangeHealth(-damageAmount);
            return damageAmount;
        }
        return 0;
    }

    ///<summary>
    ///Target a specific Defense with an amount of damage
    ///</summary>
    public int DealDamage(int damageAmount, DamageTypes damageType)
    {

        if (damageResistances.Count != 0 && (int)damageType < damageResistances.Count)
        {
            if(damageAmount > damageResistances[(int) damageType])
            {
                int damageTaken = damageAmount - damageResistances[(int) damageType];
                ChangeHealth(-damageTaken);
                return damageTaken;
            }
            return 0;
        }
        if (damageAmount > 0)
        {
            ChangeHealth(-damageAmount);
            return damageAmount;
        }
        return 0;
    }

    ///<summary>Heals the combatant by a heal amount(HA)</summary>
    public int Heal(int HA)
    {
        if (GetCurrentHealth() == 0)
        {
            return 0;
        }
        ChangeHealth(HA);
        return HA;
    }

    /// <summary>
    /// revives the combatant at a certen percent of health
    /// </summary>
    /// <param name="percentHeal"></param>
    public int Revive(float percentHeal)
    {
        if(currentHealth == 0)
        {
            currentHealth = (int)(percentHeal * maxHealth);
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            return currentHealth;
        }

        return 0;
    }

    /// <summary>
    /// changes the current health by the amount given
    /// </summary>
    /// <param name="changeAmount"></param>
    private void ChangeHealth(int changeAmount)
    {
        currentHealth += changeAmount;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /// <summary>
    /// returns the combatants name
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return combatantName;
    }

    /// <summary>
    /// returns the max health of the Combatant
    /// </summary>
    /// <returns></returns>
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    /// <summary>
    /// returns the current health of the comatant;
    /// </summary>
    /// <returns></returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    /// <summary>
    /// returns the max mana of the Combatant
    /// </summary>
    /// <returns></returns>
    public int GetMaxMana()
    {
        return maxMana;
    }

    /// <summary>
    /// returns the current mana of the comatant;
    /// </summary>
    /// <returns></returns>
    public int GetCurrentMana()
    {
        return currentMana;
    }

    /// <summary>
    /// returns the physicalPower of the combatant
    /// </summary>
    /// <returns></returns>
    public int GetPhysicalPower()
    {
        return physicalPower;
    }
    

    /// <summary>
    /// returns the magicalPower of the combatant
    /// </summary>
    /// <returns></returns>
    public int GetMagicalPower()
    {
        return magicalPower;
    }

    /// <summary>
    /// Returns the speed of the combatant.
    /// </summary>
    /// <returns></returns>
    public int Speed()
    {
        return speed;
    }

    /// <summary>
    /// returns a list of CombatAction(s)
    /// </summary>
    /// <returns></returns>
    public List<CombatAction> GetCombatActions()
    {
        return combatActions;
    }

    /// <summary>
    /// Returns the combatant info as an easily readable string.
    /// </summary>
    /// <returns></returns>
    public virtual string InfoToString()
    {
        return combatantName + " '" + level + "' " + currentHealth + "/" + maxHealth; ;
    }

    /// <summary>
    /// returns the level of the combatant.
    /// </summary>
    /// <returns></returns>
    public int GetLevel()
    {
        return level;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
    {
        return sprite;
    }

}
