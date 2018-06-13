using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndyAnimController : MonoBehaviour 
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;

    public void WalkAnim()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            anim.SetBool("isWalking", true);
        }
        if (Input.GetAxis("Vertical") != 0f)
        {
            anim.SetBool("isWalking", true);
        }

        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
        {
            anim.SetBool("isWalking", false);
        }
    }
}
