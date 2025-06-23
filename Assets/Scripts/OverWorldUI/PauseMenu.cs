using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            
            if(menu.activeSelf == false)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            } else if (menu.activeSelf == true)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
