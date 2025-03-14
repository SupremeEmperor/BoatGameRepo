using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEndStageVegetable : PlantStage
{
    [SerializeField] GameObject vegetable;
    [SerializeField] GameObject vegetableSpawn;
    bool alreadySpawned = false;

    void Update()
    {
        if (!alreadySpawned)
        {
            GameObject temp = GameObject.Instantiate(vegetable, vegetableSpawn.transform);
            temp.transform.parent = null;
            alreadySpawned = true;
        }
        
    }


}
