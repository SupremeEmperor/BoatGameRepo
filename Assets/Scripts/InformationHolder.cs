using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InformationHolder : MonoBehaviour
{
    public string overworldPlayerName;
    public Vector3 positionOfPlayer;

    bool playerLost = false;
    bool combatControllerFound = false;

    string currentSceneName;
    string previousSceneName;

    [SerializeField] List<GameObject> activePlayerCharacters;
    [SerializeField] Inventory inventory;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        foreach (GameObject character in activePlayerCharacters)
        {
            DontDestroyOnLoad(character);
            character.SetActive(false);
        }

        
        
    }

    

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerPositionUpdate();

        ActivePlayerCharactersUpdate();

        CurrentSceneUpdate();
    }

    /// <summary>
    /// Called during Update to find the players position if possible.
    /// Also sets the position to the last place it was if information holder goes to a scene had visited before.
    /// </summary>
    void PlayerPositionUpdate()
    {
        GameObject overworldPlayer = GameObject.Find(overworldPlayerName);
        if (overworldPlayer != null)
        {
            if (playerLost)
            {
                overworldPlayer.transform.position = positionOfPlayer;
                playerLost = false;
            }
            positionOfPlayer = overworldPlayer.transform.position;
        }
        else if (!playerLost)
        {
            playerLost = true;
        }
    }

    /// <summary>
    /// handles a list of currently active characters so they can be moved between scenes.
    /// </summary>
    void ActivePlayerCharactersUpdate()
    {
        if (GameObject.Find("CombatController") != null)
        {
            if (GameObject.Find("CombatController").GetComponent<CombatController>() != null)
            {
                foreach (GameObject character in activePlayerCharacters)
                {
                    character.SetActive(true);
                }
            }
            combatControllerFound = true;
        }else if(combatControllerFound)
        {
            {
                foreach (GameObject character in activePlayerCharacters)
                {
                    character.SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// records the name of the scene currently on and the last scene visited.
    /// </summary>
    void CurrentSceneUpdate()
    {
        if (currentSceneName != SceneManager.GetActiveScene().name)
        {
            previousSceneName = currentSceneName;
            currentSceneName = SceneManager.GetActiveScene().name;
        }
    }


    /// <summary>
    /// Returns the name of the previous scene visited
    /// </summary>
    /// <returns></returns>
    public string PreviousSceneName()
    {
        return previousSceneName;
    }

    /// <summary>
    /// Returns a list of currently active characters
    /// </summary>
    /// <returns>List<GameObject> of characters</returns>
    public List<GameObject> ActivePlayerCharacters()
    {
        return activePlayerCharacters;
    }

    /// <summary>
    /// Returns the inventory this class is holding
    /// </summary>
    /// <returns>Inventory inventory</returns>
    public Inventory Inventory()
    {
        return inventory;
    }

    

    
}
