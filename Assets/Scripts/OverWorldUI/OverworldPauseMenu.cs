using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPauseMenu : MonoBehaviour
{
    [SerializeField] GameObject charactersWindow;
    [SerializeField] GameObject inventoryWindow;
    [SerializeField] GameObject currentWindow;
    
    private void ChangeWindow(GameObject nextWindow)
    {
        currentWindow.SetActive(false);
        nextWindow.SetActive(true);
        currentWindow = nextWindow;
    }

    public void PressCharactersButton()
    {
        ChangeWindow(charactersWindow);
    }

    public void PressInventoryButton()
    {
        ChangeWindow(inventoryWindow);
    }
}
