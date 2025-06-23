using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetSelectButton : Button
{
    GameObject target;
    GameObject buttonCaller;
    GameObject buttonHolder;
    [SerializeField] TextMeshProUGUI nameText;

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            nameText.text = target.GetComponent<Combatant>().InfoToString();
        }
            
    }

    /// <summary>
    /// Called when the button is made.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="buttonCaller"></param>
    /// <param name="buttonHolder"></param>
    public void SetUp(GameObject target, GameObject buttonCaller, GameObject buttonHolder)
    {
        this.target = target;
        this.buttonCaller = buttonCaller;
        this.buttonHolder = buttonHolder;
    }

    /// <summary>
    /// Called when the button is pressed.
    /// </summary>
    public override void PressButton()
    {
        buttonHolder.SetActive(true);
        GameObject.Find("CombatController").GetComponent<CombatController>().SetTarget(target);
        buttonCaller.GetComponent<Button>().FinishButton();
        GameObject.Find("ActionSelect").GetComponent<ActionSelect>().TargetSelect().SetActive(false);
    }
}
