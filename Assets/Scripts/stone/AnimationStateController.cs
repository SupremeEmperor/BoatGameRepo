using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("isWalking", true);
        }
        if (!Input.GetKey("w"))
        {
            anim.SetBool("isWalking", false);
        }
    }

}
