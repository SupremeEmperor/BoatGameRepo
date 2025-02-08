using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 BoatVelocity;
    private bool isGrounded;

    private float currentSpeed = 0;

    public float speedMinimum = 5f;
    public float speedMaximum = 10f;
    public float speedIncreaseMultiplier = 1.1f;
    public float speedDecreaseMultiplier = 1.1f;
    public float speedRateOfChange = .2f;
    private float lastSpeedChange = 0;
    public float rotationSpeed = .5f;
    public float gravity = -9.8f;
    public Camera myCamera;
    public Transform boatVisual;
    public Transform testRotation;

    private float currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {      
        if(input.x != 0)
        {
            
            boatVisual.Rotate(0, input.x * Time.deltaTime * rotationSpeed * currentSpeed, 0);
        }

        testRotation.Rotate(0, input.x,0);


        if (Time.time > lastSpeedChange + speedRateOfChange)
        {
            if (input.y > 0)
            {
                if (currentSpeed == 0)
                {
                    currentSpeed = speedMinimum;
                }
                else
                {
                    currentSpeed = currentSpeed * speedIncreaseMultiplier;

                    if (currentSpeed > speedMaximum)
                    {
                        currentSpeed = speedMaximum;
                    }
                }
            }else if(input.y < 0)
            {
                currentSpeed = currentSpeed / 2;
                if (currentSpeed < speedMinimum)
                {
                    currentSpeed = 0;
                }

            }
            else
            {
                currentSpeed = currentSpeed / speedDecreaseMultiplier;

                if (currentSpeed < speedMinimum)
                {
                    currentSpeed = 0;
                }
            }

            lastSpeedChange = Time.time;
        }
        Debug.Log(currentSpeed);

        controller.Move(transform.TransformDirection(boatVisual.forward) * currentSpeed * Time.deltaTime);
        BoatVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && BoatVelocity.y < 0)
            BoatVelocity.y = -2;
        controller.Move(BoatVelocity * Time.deltaTime);

        
    }

}
