using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CombatActionUI : MonoBehaviour
{

    
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject previousUI;
    private Combatant thisCombatant;

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            previousUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Instantiates a button for each combat action the combatant has.
    /// </summary>
    /// <param name="combatant"></param>
    public void SetCombatant(Combatant combatant)
    {
        while (buttons.Count > 0)
        {
            GameObject.Destroy(buttons[0]);
            buttons.RemoveAt(0);
        }
        thisCombatant = combatant;
        List<CombatAction> combatActions = thisCombatant.GetCombatActions();

        for(int i = 0; i < combatActions.Count; i++)
        {
            GameObject tempButton = GameObject.Instantiate(buttonPrefab, content.transform);
            tempButton.GetComponent<ActionButton>().SetUp(combatActions[i], thisCombatant);
            buttons.Add(tempButton);
        }
    }
}