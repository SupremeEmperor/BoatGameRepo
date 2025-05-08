using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] float baseTimeScale = 1;
    float heldTimeScale;
    float duration;
    float time;
    bool isOutofTimeScale = false;

    public void Pause()
    {
        heldTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void Play()
    {
        Time.timeScale = heldTimeScale;
    }

    public void ChangeTimeScaleForTime(float timeScale, float duration)
    {
        time = Time.time;
        this.duration = duration;
        Time.timeScale = timeScale;
        isOutofTimeScale = true;
    }

    public void GoToHalfScale()
    {
        time = Time.time;
        this.duration = .5f;
        Time.timeScale = .5f;
        isOutofTimeScale = true;
    }

    private void Update()
    {
        if (isOutofTimeScale)
        {
            if(Time.time - time >= duration)
            {
                Time.timeScale = baseTimeScale;
                isOutofTimeScale = false;
            }
        }
    }
}
