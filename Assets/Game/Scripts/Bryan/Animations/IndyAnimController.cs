using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IndyAnimController : MonoBehaviour 
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] NavMeshAgent agent;

    void Update()
    {
        Debug.Log(agent.remainingDistance);
    }
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

        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f && agent.remainingDistance <= .5f)
        {
            anim.SetBool("isWalking", false);
        }

        if (agent.remainingDistance > 0f)
        {
            anim.SetBool("isWalking", true);
        }
    }

    public void PullAnim()
    {
        anim.SetBool("isPulling", true);
        anim.SetBool("isPulling", false);
    }
}
