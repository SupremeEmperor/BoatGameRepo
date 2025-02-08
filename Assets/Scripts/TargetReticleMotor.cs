using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticleMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 downVelocity;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f;

    public GameObject character;
    //public Camera myCamera;

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

    public void ProcessMove(Vector2 reticleInput, Vector2 characterInput)
    {
        Vector3 characterMoveDirection = GetMoveDirection(characterInput);

        controller.Move(character.GetComponent<CharacterMotor>().speed * Time.deltaTime * characterMoveDirection);

        //Debug.Log(characterMoveDirection);

        Vector3 reticleMoveDirection = GetMoveDirection(reticleInput);

        //Debug.Log(input.x + "   " + input.y);

        reticleMoveDirection = reticleMoveDirection.normalized;

        controller.Move(speed * Time.deltaTime * reticleMoveDirection);
        downVelocity.y += gravity;
        if (isGrounded && downVelocity.y < 0)
            downVelocity.y = -2;
        controller.Move(downVelocity * Time.deltaTime);

        

    }

    private static Vector3 GetMoveDirection(Vector2 input)
    {
        return new Vector3(input.x, 0, input.y);
    }
}
