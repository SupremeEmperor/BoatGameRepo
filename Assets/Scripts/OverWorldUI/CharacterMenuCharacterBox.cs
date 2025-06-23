using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CharacterMenuCharacterBox : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI nameHolder;
    [SerializeField] TextMeshProUGUI lvlHolder;
    [SerializeField] TextMeshProUGUI hpHolder;
    [SerializeField] TextMeshProUGUI mpHolder;
    [SerializeField] Combatant combatant;
    [SerializeField] bool test;

    private void Update()
    {
        if (test && combatant != null)
        {
            SetCombatant(combatant);
            test = false;
        }
    }

    public void SetCombatant(Combatant combatant)
    {
        this.combatant = combatant;

        ChangeAll(combatant.GetSprite(), combatant.GetName(), combatant.GetLevel(), combatant.GetCurrentHealth(), combatant.GetMaxHealth(), combatant.GetCurrentMana(), combatant.GetMaxMana());
        
    }

    public void ChangeAll(Sprite newImage, string newName, int lvl, int hpcurr,int hpmax, int mpcurr, int mpmax)
    {
        ChangeSprite(newImage);
        ChangeLvl(lvl);
        ChangeName(newName);
        ChangeHealth(hpcurr, hpmax);
        ChangeMana(mpcurr, mpmax);
    }

    public void ChangeSprite(Sprite newImage)
    {
        image.sprite = newImage;
    }

    public void ChangeName(string newName)
    {
        nameHolder.text = "Name: " + newName;
    }

    public void ChangeLvl(int lvl)
    {
        lvlHolder.text = "Lvl: " + lvl;
    }

    public void ChangeHealth(int cur, int max)
    {
        hpHolder.text = "HP: " + cur + "/" + max;
    }

    public void ChangeMana(int cur, int max)
    {
        if(max <= 0)
        {
            mpHolder.text = "";
            return;
        }
        mpHolder.text = "MP: " + cur + "/" + max;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("CharactersWindow").GetComponent<OverworldUI_CharactersWindow>().ChangeSelectedCombatant(combatant);
    }
}
