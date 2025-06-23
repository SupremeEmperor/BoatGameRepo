using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    
    private CharacterController controller;
    private Vector3 BoatVelocity;
    private bool isGrounded;
    bool jump = false; 

    public float speed = 5f;
    public float rotationSpeed = .2f;
    public float gravity = -9.8f;
    public Camera myCamera;
    public Transform characterVisual;
    public Transform orientation;

    [SerializeField] float jumpVelocity = 1;
    [SerializeField] float jumpTime = 2;
    float timeOfJump;

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
        if(Time.time - timeOfJump > jumpTime)
        {
            jump = false;
        }
    }


    public void Jump(float jumpNow)
    {
        //Debug.Log("Jump called; isGrounded: " + isGrounded + " jumpNow: " + jumpNow + " jump: " + jump);
        if (isGrounded && jumpNow != 0 && !jump)
        {
            jump = true;
            timeOfJump = Time.time;

        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = GetMoveDirection(input);

        //Debug.Log(input.x + "   " + input.y);

        

        moveDirection = moveDirection.normalized;

        controller.Move(speed * Time.deltaTime * moveDirection);
        
        if (jump)
        {
            BoatVelocity.y = jumpVelocity;
        }
        else
        {
            BoatVelocity.y += gravity * Time.deltaTime;
        }
        
        if (isGrounded && BoatVelocity.y < 0)
            BoatVelocity.y = -2;

        controller.Move(BoatVelocity * Time.deltaTime);

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            characterVisual.rotation = Quaternion.RotateTowards(characterVisual.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    private Vector3 GetMoveDirection(Vector2 input)
    {
        Vector3 forward = orientation.forward;
        Vector3 right = orientation.right;

        Vector3 fowardRelativeInput = input.y * forward;
        Vector3 rightRelativeInput = input.x * right;

        return fowardRelativeInput + rightRelativeInput;
    }
}
