using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SophiaAnimController : MonoBehaviour 
{
    // Sophia's Animator
    [SerializeField] Animator anim;
    // Sophia's NavMeshAgent
    [SerializeField] NavMeshAgent agent;
		
	void Update () 
    {
        // Check the remaining distance to the destination to see if it's greater than the stopping distance
        // Set the animation paramater to true if it's greater and false if it's less.
        if (agent.remainingDistance > agent.radius + 2.5f)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
	}
}
