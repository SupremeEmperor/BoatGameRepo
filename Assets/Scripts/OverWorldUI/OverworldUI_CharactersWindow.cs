using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldUI_CharactersWindow : MonoBehaviour
{
    [SerializeField] GameObject characterInformationBox;
    [SerializeField] GameObject content;
    [SerializeField] OverworldUI_CharacterInformation_ExpandedInformation expandedInformation;
    InformationHolder informationHolder;
    List<GameObject> activePlayers;

    private void Awake()
    {
        informationHolder = GameObject.Find("InformationHolder").GetComponent<InformationHolder>();

        activePlayers = informationHolder.ActivePlayerCharacters();

        expandedInformation.SetUp(activePlayers[0].GetComponent<Combatant>());

        PlaceBlocks();

    }

    public void PlaceBlocks()
    {
        foreach (GameObject character in activePlayers)
        {

            character.SetActive(true);
            GameObject block = GameObject.Instantiate(characterInformationBox, content.transform);
            block.GetComponent<CharacterMenuCharacterBox>().SetCombatant(character.GetComponent<Combatant>());
            character.SetActive(false);

        }
    }

    public void ChangeSelectedCombatant(Combatant combatant)
    {
        expandedInformation.SetUp(combatant);
    }
}
