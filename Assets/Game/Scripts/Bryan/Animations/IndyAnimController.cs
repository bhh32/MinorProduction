using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IndyAnimController : MonoBehaviour 
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] NavMeshAgent agent;

    public void WalkAnim()
    {
        if (!agent.isActiveAndEnabled)
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
        else
        {
            if (agent.remainingDistance > 0f)
                anim.SetBool("isWalking", true);
            else
                anim.SetBool("isWalking", false);
        }
    }

    public void PullAnim()
    {
        anim.SetBool("isPulling", true);
        anim.SetBool("isPulling", false);
    }
}
