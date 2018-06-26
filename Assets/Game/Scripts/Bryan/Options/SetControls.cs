using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetControls : MonoBehaviour 
{
    [SerializeField] NavMeshAgent indyAgent;
    [SerializeField] Rigidbody indyRB;
    [SerializeField] PlayerController wasd;
    [SerializeField] PlayerControllerPAC pointAndClick;

    [SerializeField] bool debugPacBool = false;

    void Awake()
    {
        if (ControlsManager.instance != null)
        {
            if (ControlsManager.instance.isPointAndClick)
            {
                indyAgent.enabled = true;
                indyRB.useGravity = false;
                indyRB.isKinematic = true;
                wasd.enabled = false;
                pointAndClick.enabled = true;
            }
            else
            {
                indyAgent.enabled = false;
                indyRB.useGravity = true;
                indyRB.isKinematic = false;
                wasd.enabled = true;
                pointAndClick.enabled = false;
            }
        }
        // Remove the else - else if statement for production, debug checks and testing only
        else if (debugPacBool)
        {
            indyAgent.enabled = true;
            indyRB.useGravity = false;
            indyRB.isKinematic = true;
            wasd.enabled = false;
            pointAndClick.enabled = true;
        }
        else
        {
            indyAgent.enabled = false;
            indyRB.useGravity = true;
            indyRB.isKinematic = false;
            wasd.enabled = true;
            pointAndClick.enabled = false;
        }
    }
}
