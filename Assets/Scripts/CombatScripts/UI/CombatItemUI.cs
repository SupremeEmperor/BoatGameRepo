using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CombatItemUI : MonoBehaviour
{
    private Combatant thisCombatant;
    private Inventory inventory;
    [SerializeField] private float buttonXPosition;
    [SerializeField] private float buttonYPosition;
    [SerializeField] private float spaceMultiplier;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject previousUI;

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            previousUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// Instantiates a button in content for each item in the combatController's inventory.
    /// </summary>
    public void SetUp()
    {
        while (buttons.Count > 0)
        {
            GameObject.Destroy(buttons[0]);
            buttons.RemoveAt(0);
        }

        inventory = GameObject.Find("CombatController").GetComponent<CombatController>().GetInventory();

        for (int i = 0; i < inventory.GetList().Count; i++)
        {
            GameObject tempButton = GameObject.Instantiate(buttonPrefab, content.transform);
            tempButton.transform.Translate(new Vector3(buttonXPosition, buttonYPosition - (i * spaceMultiplier), 0));
            tempButton.GetComponent<ItemButton>().SetUp(inventory.GetList()[i]);
            buttons.Add(tempButton);
        }
        


        
    }
}