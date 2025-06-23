using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverworldUI_CharacterInformation_ExpandedInformation : MonoBehaviour
{
    [SerializeField] GameObject textField;
    Combatant combatant;

    public void SetUp(Combatant combatant)
    {

        this.combatant = combatant;

        for (int i = (transform.childCount - 1); i >= 0 ; i--)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        SpawnTextField("Physical Power: " + combatant.GetPhysicalPower());
        SpawnTextField("Magic Power: " + combatant.GetMagicalPower());
        SpawnTextField("Speed: " + combatant.Speed());

        //Do stuff with combat actions
        
    }

    private void SpawnTextField(string text)
    {
        GameObject tmp = GameObject.Instantiate(textField, transform);
        tmp.GetComponent<TextMeshProUGUI>().text = text;
    }

    public Combatant GetCombatant()
    {
        return combatant;
    }

}
