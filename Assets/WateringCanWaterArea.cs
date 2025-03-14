using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanWaterArea : MonoBehaviour
{
    float lifeTime = -1;
    float spawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime >= 0)
        {
            if(Time.time - spawnTime > lifeTime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void SetLifeTime(float flt)
    {
        lifeTime = flt;
    }

    private void OnTriggerEnter(Collider other)
    {
        //add water
        GameObject go = other.gameObject;
        Debug.Log(go);
        if (go.GetComponent<Waterable>() != null)
        {
            go.GetComponent<Waterable>().Water(1);
        }
        else
        {
            go = go.transform.parent.gameObject;
            Debug.Log(go);
            if (go.GetComponent<Waterable>() != null)
            {
                go.GetComponent<Waterable>().Water(1);
            }
            
        }
    }
}
