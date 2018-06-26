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
        if (ControlsManager.instance != null || debugPacBool)
        {
            if (ControlsManager.instance.isPointAndClick || debugPacBool)
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
}
