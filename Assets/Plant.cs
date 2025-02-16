using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] List<GameObject> stages;
    int currentStage = 0;
    float timeOfLastStageChange = 0;
    float timeStageLasts = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        if(stages.Count != 0)
        {
            timeOfLastStageChange = Time.time;
            //Get the time the stage lasts from the stage
            timeStageLasts = stages[currentStage].GetComponent<PlantStage>().GetStageLifeSpan();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeOfLastStageChange > timeStageLasts)
        {
            UpdateCurrentStage();
            timeOfLastStageChange = Time.time;
        }
    }

    private void UpdateCurrentStage()
    {
        if (currentStage >= stages.Count - 1)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            
            stages[currentStage].GetComponent<PlantStage>().OnStageEnd(stages[currentStage + 1]);
            currentStage += 1;
            timeStageLasts = stages[currentStage].GetComponent<PlantStage>().GetStageLifeSpan();
        }
        
    }
}
