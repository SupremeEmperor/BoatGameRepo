using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatController : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> combatants = new List<GameObject>();
    [SerializeField] bool activeCombat;
    [SerializeField] private Combatant activeCombatant;
    [SerializeField] private GameObject target;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject[] combatPositions;
    [SerializeField] List<GameObject> playerCombatants;
    [SerializeField] List<GameObject> enemyCombatants;
    [SerializeField] List<GameObject> turnOrder;
    [SerializeField] GameObject actionSelectUI;

    [SerializeField] string informationHolder = "InformationHolder";

    bool combatantIsActive;

    

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find(informationHolder))
        {
            playerCombatants = GameObject.Find(informationHolder).GetComponent<InformationHolder>().ActivePlayerCharacters();
            inventory = GameObject.Find(informationHolder).GetComponent<InformationHolder>().Inventory();



        }
        else
        {
            Debug.Log("InformationHolder named " + informationHolder + " not found loading Scene 0, Error Scene.");
            SceneManager.LoadScene(0);
        }
        SetUP(playerCombatants, enemyCombatants);
    }

    

    

    // Update is called once per frame
    void Update()
    {

        if (!combatantIsActive && turnOrder.Count > 0)
        {
            combatantIsActive = true;
            AllowAction();
        }
        
        
    }

    /// <summary>
    /// Checks if the players have 0 health between them all. If so calls GoToGameOver function.
    /// </summary>
    void CheckPlayerHealth()
    {
        int totalHealth = 0;
        foreach (GameObject player in playerCombatants)
        {
            totalHealth += player.GetComponent<Combatant>().GetCurrentHealth();
        }

        
        if (totalHealth == 0)
        {
            GoToGameOver();
        }
    }

    /// <summary>
    /// Takes actions needed to show Game Over.
    /// </summary>
    void GoToGameOver()
    {
        Debug.Log("No Game Over scene implemented.");
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Checks if the total enemy is at 0
    /// </summary>
    void CheckEnemyHealth()
    {
        int totalHealth = 0;
        foreach (GameObject enemy in enemyCombatants)
        {
            totalHealth += enemy.GetComponent<Combatant>().GetCurrentHealth();
        }

        if(totalHealth == 0)
        {
            EndScene();
        }
    }

    /// <summary>
    /// Takes actions to end the scene with player as victor.
    /// </summary>
    public void EndScene()
    {
        if (GameObject.Find(informationHolder) != null)
        {
            Debug.Log("EndScene not sufieciently handled");
            SceneManager.LoadSceneAsync(GameObject.Find(informationHolder).GetComponent<InformationHolder>().PreviousSceneName());
        }
        else
        {
            Debug.Log("InformationHolder named " + informationHolder + " not found loading Scene 0, Error Scene.");
            SceneManager.LoadScene(0);
        }
    }

    //Calling this allows the next combatant to take an action
    /// <summary>
    /// Calling this allows the next combatant in the turnOrder to take an action
    /// </summary>
    void AllowAction()
    {
        //Checks to sea if all the enemis are dead.
        CheckEnemyHealth();
        CheckPlayerHealth();

        float tempTime = 0;
        //if there is a combatant in the turnOrder List then it allows the one in the 0th position to take its turn else no turn is taken.
        if (turnOrder.Count > 0)
        {
            if(turnOrder[0].GetComponent<Combatant>().GetCurrentHealth() == 0)
            {
                EndTurn(tempTime);
                return;
            }
            else
            {
                tempTime = turnOrder[0].GetComponent<Combatant>().TakeTurn();
            }
        }
        else
        {
            EndTurn(tempTime);
            return;
        }
        

        if (tempTime > 0)
        {
            
            EndTurn(tempTime);
        }
        else
        {
            actionSelectUI.SetActive(true);
        }
    }

    //ends the turn in endTime seconds
    /// <summary>
    /// Ends the turn in endTime seconds.
    /// </summary>
    /// <param name="endTime">The amount of time it takes for the turn to end.</param>
    public void EndTurn(float endTime)
    {
        StopCoroutine(EndTurnIenum(0));
        StartCoroutine(EndTurnIenum(endTime));
    }

    //Coroutine called by EndTurn() where turn is actually ended
    /// <summary>
    /// Coroutine called by EndTurn() where turn is actually ended
    /// </summary>
    /// <param name="endTime">The amount of time it takes for the turn to end.</param>
    /// <returns></returns>
    IEnumerator EndTurnIenum(float endTime)
    {
        
        yield return new WaitForSeconds(endTime);
        if (!activeCombat)
        {
            turnOrder.Add(turnOrder[0]);
        }
        turnOrder.RemoveAt(0);
        actionSelectUI.SetActive(false);
        combatantIsActive = false;
    }



    //Returns the Inventory
    /// <summary>
    /// Returns the Inventory
    /// </summary>
    /// <returns>The current Inventory held by the combat conroller.</returns>
    public Inventory GetInventory()
    {
        return inventory;
    }

    //Sets up the field ussually called at the start of a fight.
    /// <summary>
    /// Sets up the field ussually called at the start of a fight.
    /// </summary>
    /// <param name="playerCombatants">A list of player combatants</param>
    /// <param name="enemyCombatants">A list of inemy combatants</param>
    public void SetUP(List<GameObject> playerCombatants, List<GameObject> enemyCombatants)
    {

        combatants.Clear();
        turnOrder.Clear();
        for (int i = 0; i < (int)(combatPositions.Length / 2); i++)
        {
            if (i < playerCombatants.Count && playerCombatants[i] != null)
            {
                playerCombatants[i].transform.position = combatPositions[i].transform.position;
                playerCombatants[i].transform.rotation = combatPositions[i].transform.rotation;
                combatants.Add(playerCombatants[i]);
            }
            
        }
        for (int i = 0; i < (int)(combatPositions.Length / 2); i++)
        {
            if (i < enemyCombatants.Count && enemyCombatants[i] != null && i + (int)(combatPositions.Length / 2) < combatPositions.Length)
            {
                enemyCombatants[i].transform.position = combatPositions[i + (int)(combatPositions.Length / 2)].transform.position;
                enemyCombatants[i].transform.rotation = combatPositions[i + (int)(combatPositions.Length / 2)].transform.rotation;
                combatants.Add(enemyCombatants[i]);
            }

        }

        if (activeCombat)
        {
            for(int i = 0; i < combatants.Count; i++)
            {
                combatants[i].GetComponent<Combatant>().ActiveCombat(activeCombat);
            }
        }
        else
        {
            for(int i = 0; i < combatants.Count; i++)
            {
                bool isSlowest = true;
                for(int j = 0; j < turnOrder.Count; j++)
                {
                    if(combatants[i].GetComponent<Combatant>().Speed() > turnOrder[j].GetComponent<Combatant>().Speed())
                    {
                        isSlowest = false;
                        turnOrder.Insert(j, combatants[i]);
                        break;
                    }
                    
                }
                if (isSlowest)
                {
                    turnOrder.Add(combatants[i]);
                }
            }
        }
    }


    //Requests a turn for the passed gameobject
    /// <summary>
    /// Requests a turn for the passed gameobject. Only used in Active Combat.
    /// </summary>
    /// <param name="requester">The GameObject with a Combatant script attached that requests a turn.</param>
    public void RequestTurn(GameObject requester)
    {
        if (activeCombat)
        {
            turnOrder.Add(requester);
        }
    }

    

    //returns the current target ignoring target with 0 currentHealth
    /// <summary>
    /// Returns the current target or if the target has 0 currentHealth the next target on its team.
    /// </summary>
    /// <returns></returns>
    public GameObject GetTarget()
    {
        if (target.GetComponent<Combatant>().GetCurrentHealth() == 0)
        {
            foreach (GameObject pt in playerCombatants)
            {
                if (pt == target)
                {
                    foreach (GameObject st in playerCombatants)
                    {
                        if (st != target && st.GetComponent<Combatant>().GetCurrentHealth() != 0)
                        {
                            target = st;
                            return target;
                        }
                    }
                }
            }

            foreach (GameObject pt in enemyCombatants)
            {
                if (pt == target)
                {
                    foreach (GameObject st in enemyCombatants)
                    {
                        if (st != target && st.GetComponent<Combatant>().GetCurrentHealth() != 0)
                        {
                            target = st;
                            return target;
                        }
                    }
                }
            }
        }
        return target;
    }

    //Gets the current target
    /// <summary>
    /// Returns the current target even if they have 0 currentHealth
    /// </summary>
    /// <returns></returns>
    public GameObject GetReviveTarget()
    {
        return target;
    }

    //Sets the current target
    /// <summary>
    /// Sets the current target to newTarget.
    /// </summary>
    /// <param name="newTarget"></param>
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }




    //Returns combatant at the position selected. if their is no combatant at that position returns null.
    /// <summary>
    /// Returns GameObject of the combatant at the position selected. if their is no combatant at that position returns null.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject GetCombatant(int position)
    {
        if(position < combatants.Count)
        {
            return combatants[position];
        }

        return null;
    }

    //Returns player combatant at the position selected. if their is no player combatant at that position returns null.
    /// <summary>
    /// Returns GameObject of the combatant at the position selected. if their is no combatant at that position returns null.
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject GetPlayerCombatant(int position)
    {
        if (position < playerCombatants.Count)
        {
            return combatants[position];
        }

        return null;
    }

    //Returns the GameObject of the combatant that is currently trying to take an action
    /// <summary>
    /// Returns the combatant that is currently trying to take an action
    /// </summary>
    /// <returns></returns>
    public GameObject GetActiveCombatant()
    {
        if(turnOrder.Count > 0)
        {
            return turnOrder[0];
        }
        return null;
    }

    //returns a list of all combatants
    /// <summary>
    /// returns a list of GameObjects of all the combatants
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetCombatants()
    {
        return combatants;
    }

    //returns a list of all enemy combatants
    /// <summary>
    /// returns a list of GameObjects of all the enemy combatants
    /// </summary>
    /// <returns></returns>
    public List<GameObject> EnemyCombatants()
    {
        return enemyCombatants;
    }

    //returns a list of player combatants
    /// <summary>
    /// returns a list of GameObjects of all the player combatants
    /// </summary>
    /// <returns></returns>
    public List<GameObject> PlayerCombatants()
    {
        return playerCombatants;
    }

}
