using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InformationTab : MonoBehaviour
{
    [SerializeField] bool setUp;
    [SerializeField] Animator animator;
    [SerializeField] float liveTime = 1;
    float startTime;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float timeBetweenAttempts;
    string tempString;
    float tempTime;
    bool attemptAgain;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time - liveTime;
        animator.SetBool("RiseUp", true);
        attemptAgain = false;
    }


    public void SetUp(string text)
    {
        if (!animator.GetBool("RiseUp"))
        {
            Debug.Log("Hoi");
            animator.SetBool("RiseUp", true);
            tempString = text;
            tempTime = liveTime;
            attemptAgain = true;
            startTime = Time.time;
            return;
        }
        this.text.text = text;
        animator.SetBool("RiseUp", false);
        startTime = Time.time;
    }


    public void SetUp(string text, float liveTime)
    {
        if (!animator.GetBool("RiseUp"))
        {
            Debug.Log("Hoi");
            animator.SetBool("RiseUp", true);
            tempString = text;
            tempTime = liveTime;
            attemptAgain = true;
            startTime = Time.time;
            return;
        }
        this.text.text = text;
        this.liveTime = liveTime;
        animator.SetBool("RiseUp", false);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= liveTime)
        {
            animator.SetBool("RiseUp", true);
        }
        if(attemptAgain && Time.time - startTime >= timeBetweenAttempts)
        {
            attemptAgain = false;
            SetUp(tempString,tempTime);
        }
        if (setUp)
        {
            SetUp("Hello");
            setUp = false;
        }
    }
}
