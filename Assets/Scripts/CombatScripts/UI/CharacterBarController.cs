using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CharacterBarController : MonoBehaviour
{
    [SerializeField] int position;
    GameObject character;
    //[SerializeField] GameObject combatController;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image healthImage;

    
    // Update is called once per frame
    void Update()
    {
        character = GameObject.Find("CombatController").GetComponent<CombatController>().GetPlayerCombatant(position);
        if (character != null)
        {
            nameText.text = character.GetComponent<Combatant>().GetName();
        }
        else
        {
            nameText.text = "Not Here";
            this.gameObject.SetActive(false);
        }
        UpdateHealthBar();
    }

    /// <summary>
    /// Updates the Health Bar.
    /// </summary>
    private void UpdateHealthBar()
    {
        if (character == null)
        {
            healthImage.fillAmount = 0;
            return;
        }
        healthImage.fillAmount = (float)character.GetComponent<Combatant>().GetCurrentHealth() / (float)character.GetComponent<Combatant>().GetMaxHealth();
    }
}
