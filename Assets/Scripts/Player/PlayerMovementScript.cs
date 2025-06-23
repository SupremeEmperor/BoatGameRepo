using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float dashSpeedMultiplier;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateVelocity();

    }

    /// <summary>
    /// Changes the players velocity based on 
    /// </summary>
    void UpdateVelocity()
    {
        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool dash = Input.GetButton("Cancel");
        float speedMultiplier = 1;

        float previousYVelocity = rigidbody.velocity.y;

        Vector3 newVelocity = new Vector3(horizontal, 0, vertical);

        if (newVelocity.magnitude > 0)
        {
            newVelocity = newVelocity / newVelocity.magnitude;
        }

        if (dash)
        {
            speedMultiplier = dashSpeedMultiplier;
        }

        newVelocity = newVelocity * speedMultiplier * speed;

        newVelocity = newVelocity + new Vector3(0, previousYVelocity, 0);

        rigidbody.velocity = newVelocity;
    }
}
