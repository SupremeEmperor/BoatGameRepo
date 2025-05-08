using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject BaseCanvas;
    [SerializeField] GameObject PauseCanvas;

    float currentTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        currentTimeScale = Time.timeScale;
        Time.timeScale = 0;
        BaseCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = currentTimeScale;
        BaseCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
    }
}
