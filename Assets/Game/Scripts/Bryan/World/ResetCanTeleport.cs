using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCanTeleport : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Indy") && !PlayerController.instance.canTeleport)
        {
            PlayerController.instance.canTeleport = true;
        }
    }
}
