using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticleMotor : MonoBehaviour
{

    //private CharacterController controller;
    [SerializeField] Rigidbody rb;
    private Vector3 downVelocity;
    private bool isGrounded;

    [SerializeField] float speed = 5f;
    [SerializeField] float accelerationMultiplier = 2f;
    float offSpeed;

    [SerializeField] float speedChangeDelay = 1f;
    float lastSpeedChange = 0;

    [SerializeField] GameObject character;
    //public Camera myCamera;

    private float currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        offSpeed = speed * accelerationMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 reticleInput, float accelerate)
    {

        Vector3 reticleMoveDirection = GetMoveDirection(reticleInput);

        //Debug.Log(input.x + "   " + input.y);

        reticleMoveDirection = reticleMoveDirection.normalized;

        rb.velocity = reticleMoveDirection * speed;

        ChangeSpeed(accelerate);

        

    }

    private void ChangeSpeed(float accelerate)
    {
        if(Time.time - lastSpeedChange > speedChangeDelay && accelerate > 0)
        {
            lastSpeedChange = Time.time;
            float temp = offSpeed;
            offSpeed = speed;
            speed = temp;
        }

        if(accelerate == 0)
        {
            lastSpeedChange = 0;
        }
    }

    private static Vector3 GetMoveDirection(Vector2 input)
    {
        return new Vector3(input.x, 0, input.y);
    }
}
