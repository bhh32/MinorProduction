using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RodentAnimCont : MonoBehaviour 
{
    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent agent;

    void Update()
    {
        if (agent.remainingDistance > .1f)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
    }
}
