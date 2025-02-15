using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float health = 100;
    
    // Update is called once per frame
    public void Damage(int dmg)
    {
        //Debug.Log(dmg);
        health -= dmg;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
