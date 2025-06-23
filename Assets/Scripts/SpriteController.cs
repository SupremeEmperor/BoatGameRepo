using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] Animator animator;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool dash = Input.GetButton("Cancel");

        if (horizontal <= .1 && horizontal >= -.1 && vertical <= .1 && vertical >= -.1)
        {

        }

    }
}
