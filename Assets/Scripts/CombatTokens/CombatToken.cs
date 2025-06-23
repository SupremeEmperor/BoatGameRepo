using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatToken : ScriptableObject
{
    [SerializeField] string tokenName;

    [SerializeField] string tokenDiscription;

    //To Do: set up a token image

    [SerializeField] Sprite sprite;

    int tokenAmount;

    bool locked = false;

    CombatController combatController;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject cc = GameObject.Find("CombatController");
        if(cc.GetComponent<CombatController>() != null)
        {
            combatController = cc.GetComponent<CombatController>();
        }
    }

    public void CleanSpawn()
    {
        tokenAmount = 0;
        locked = false;
    }

    public virtual void UseToken()
    {

    }

    public int GetTokenAmount()
    {
        return tokenAmount;
    }

    public void DecrementTokenAmount()
    {
        tokenAmount--;
    }

    public void DecrementTokenAmount(int dereaseAmount)
    {
        tokenAmount = tokenAmount - dereaseAmount;
    }

    public void IncrementTokenAmount()
    {
        tokenAmount++;
    }

    public void IncrementTokenAmount(int incrementAmount)
    {
        tokenAmount = tokenAmount + incrementAmount;
    }

    public bool CompareName(CombatToken otherToken)
    {
        if(name == otherToken.GetName())
        {
            return true;
        }
        return false;
    }

    public string GetName()
    {
        return tokenName;
    }

    public void Lock()
    {
        locked = true;
    }

    public void Unlock()
    {
        locked = false;
    }

    public bool CheckIfLocked()
    {
        return locked;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
}
