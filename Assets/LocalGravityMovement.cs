using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGravityMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float dashSpeedMultiplier = 2;

    [SerializeField] Transform GravityPoint;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] bool playerControled;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControled)
        {
            ProcessMovement();
            ProcessGravity();
        }
        

    }

    void ProcessMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool dash = Input.GetButton("Cancel");
        float speedMultiplier = 1;

        Vector3 previousDownVelocity = -transform.up.normalized * (Vector3.Dot(myRigidbody.velocity, -transform.up));

        Vector3 newVelocity = (transform.forward * vertical) + (transform.right * horizontal);

        if (newVelocity.magnitude > 0)
        {
            newVelocity = newVelocity / newVelocity.magnitude;
        }

        if (dash)
        {
            speedMultiplier = dashSpeedMultiplier;
        }

        newVelocity = newVelocity * speedMultiplier * speed;

        newVelocity = newVelocity + previousDownVelocity;

        myRigidbody.velocity = newVelocity;

    }

    void ProcessGravity()
    {
        Vector3 diff = transform.position - GravityPoint.position;
        myRigidbody.AddForce(-diff.normalized * gravity * myRigidbody.mass);

        AutoOrient(-diff);
    }

    void AutoOrient(Vector3 down)
    {
        Quaternion orientationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, orientationDirection, rotationSpeed * Time.deltaTime);
    }
}
