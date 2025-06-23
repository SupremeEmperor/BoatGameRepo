using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenHolder : MonoBehaviour
{
    List<CombatToken> tokenHolder;
    List<CombatToken> lockedTokenHolder;
    
    public void AddToken(CombatToken token)
    {
        foreach(CombatToken t in tokenHolder)
        {
            if (t.CompareName(token))
            {
                t.IncrementTokenAmount();
                return;
            }
        }
        token.CleanSpawn();
        tokenHolder.Add(token);
    }

    public void AddToken(CombatToken token, int amnt)
    {
        foreach (CombatToken t in tokenHolder)
        {
            if (t.CompareName(token))
            {
                t.IncrementTokenAmount(amnt);
                return;
            }
        }
        token.CleanSpawn();
        token.IncrementTokenAmount(amnt - 1);
        tokenHolder.Add(token);
    }

    public void RemoveToken(CombatToken token)
    {
        foreach (CombatToken t in tokenHolder)
        {
            if (t.CompareName(token))
            {
                t.DecrementTokenAmount();
                return;
            }
        }
    }

    public void RemoveToken(CombatToken token, int amnt)
    {
        foreach (CombatToken t in tokenHolder)
        {
            if (t.CompareName(token))
            {
                t.DecrementTokenAmount(amnt);
                return;
            }
        }
    }

    public List<CombatToken> GetList()
    {
        return tokenHolder;
    }
}
