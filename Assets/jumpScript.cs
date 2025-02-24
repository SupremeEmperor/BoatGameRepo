using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
   
    public float jumpForce = 10f;
    public CharacterController controller;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Move(new Vector3(0, jumpForce, 0));
            
        }
    }
}

