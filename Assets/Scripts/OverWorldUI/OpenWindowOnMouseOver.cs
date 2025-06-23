using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpenWindowOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject window;
    [SerializeField] float waitTime;

    PointerEventData eventData;
    bool pointerInside;
    bool windowSpawned = false;
    GameObject spawnedWindow;
    float enterTime;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Looking at window");
        this.eventData = eventData;
        pointerInside = true;
        enterTime = Time.realtimeSinceStartup;
        
        

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Leaving window");
        pointerInside = false;
        if (windowSpawned)
        {
            windowSpawned = false;
            Destroy(spawnedWindow);
        }
    }

    private void Update()
    {
        
     
        if (pointerInside && Time.realtimeSinceStartup - enterTime >= waitTime && !windowSpawned)
        {
            Debug.Log("Time waited succesfully");
            windowSpawned = true;
            spawnedWindow = GameObject.Instantiate(window, eventData.position, new Quaternion(), GameObject.Find("Canvas").transform);
            spawnedWindow.transform.position = new Vector3(spawnedWindow.transform.position.x + spawnedWindow.GetComponent<RectTransform>().rect.height/2
                , spawnedWindow.transform.position.y + spawnedWindow.GetComponent<RectTransform>().rect.width/2
                , spawnedWindow.transform.position.z);  //spawnedWindow.GetComponent<RectTransform>().rect.width;
        }
    }

    private void OnDisable()
    {
        if (windowSpawned)
        {
            windowSpawned = false;
            Destroy(spawnedWindow);
        }
    }


}
