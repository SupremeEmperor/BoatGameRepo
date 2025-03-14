using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStage : MonoBehaviour
{
    [SerializeField] float stageLifeSpan = 1;
    [SerializeField] float endTime = 0;
    [SerializeField] bool noMoreWater;
    float endTimeStart = 0;
    bool isEnding = false;
    GameObject nextStage;

    private void Start()
    {
        Debug.Log("plant stage start");
        if (noMoreWater)
        {
            if(gameObject.transform.parent.GetComponent<Waterable>() != null)
            {
                gameObject.transform.parent.GetComponent<Waterable>().NoMoreWater();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isEnding && Time.time - endTimeStart > endTime)
        {
            nextStage.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public float GetStageLifeSpan()
    {
        return stageLifeSpan;
    }

    public void OnStageEnd(GameObject nextStage)
    {
        //Any ending action

        isEnding = true;
        endTimeStart = Time.time;
        this.nextStage = nextStage;
    }
}
