using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelect : MonoBehaviour
{
    [SerializeField] GameObject targetSelectButton;
    [SerializeField] GameObject content;
    [SerializeField] float buttonXPosition;
    [SerializeField] float buttonYPosition;
    [SerializeField] float spaceMultiplier;
    GameObject buttonHolder;
    GameObject combatController;
    List<GameObject> buttons = new List<GameObject>();
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            this.gameObject.SetActive(false);
            buttonHolder.SetActive(true);
        }
    }

    /// <summary>
    /// Called when a new target needs to be selected.
    /// </summary>
    /// <param name="buttonCaller"></param>
    /// <param name="buttonHolder"></param>
    public void SetUP(GameObject buttonCaller, GameObject buttonHolder)
    {
        this.buttonHolder = buttonHolder;
        combatController = GameObject.Find("CombatController");
        List<GameObject> combatants = combatController.GetComponent<CombatController>().GetCombatants();

        while (buttons.Count > 0)
        {
            GameObject.Destroy(buttons[0]);
            buttons.RemoveAt(0);
        }

        for (int i = 0; i < combatants.Count; i++)
        {
            GameObject tempButton = GameObject.Instantiate(targetSelectButton, content.transform);
            tempButton.transform.Translate(new Vector3(buttonXPosition, buttonYPosition - (i * spaceMultiplier), 0));
            tempButton.GetComponent<TargetSelectButton>().SetUp(combatants[i], buttonCaller, buttonHolder);
            buttons.Add(tempButton);
        }

    }
}
