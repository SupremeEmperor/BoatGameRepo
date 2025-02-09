using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movmentTest : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }
}
