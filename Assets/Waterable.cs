using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterable : MonoBehaviour
{
    [SerializeField] float deathTime;
    [SerializeField] int waterMax = 10;
    [SerializeField] int currentWater = 5;
    [SerializeField] float waterDecreaseTime = 1f;
    float timeStart = 0f;
    bool noMoreWater = false;

    // Start is called before the first frame update
    public void Water(int waterAdd)
    {
        currentWater += waterAdd;
    }

    private void Update()
    {
        if (noMoreWater)
        {
            return;
        }
        if(currentWater <= 0 || currentWater > waterMax)
        {
            Die();
        }

        if(Time.time - timeStart > waterDecreaseTime)
        {
            --currentWater;
            timeStart = Time.time;
        }
    }

    void Die()
    {
        Destroy(this.gameObject, deathTime);
    }

    public void NoMoreWater()
    {
        noMoreWater = true;
    }
}
