using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportLocation;

    // Varaible to hold the position of the teleport GameObject.
    private Vector3 locationV3;


	void Start ()
    {
        // Get the position of the teleport GameObject.
        locationV3 = teleportLocation.transform.position;
	}

    // Checking for collision with object to be teleported
	void OnTriggerEnter(Collider other)
    {
        // If the other collider's tag is Player... 
        if (other.CompareTag("Player"))
        {
            // Check to see if the player can teleport...
            if (PlayerController.instance.canTeleport)
            {
                // ... if it can, set its position to the teleport position...
                other.transform.position = locationV3;

                // ... and set its destination to its now current position.
                PlayerController.instance.WalkToUI(other.transform.position);
            }
        }
        // If the collider's tag is Jungle Rodent...
        else if (other.CompareTag("Jungle Rodent"))
        {
            // Check to see if the rodent can teleport...
            if (other.GetComponent<RodentAI>().CanTeleport)
            {
                // ... if it can, set its position to the teleport position...
                other.transform.position = locationV3;

                // ... and set its destination to its now current position.
                other.GetComponent<RodentAI>().SetNewDest(locationV3);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // Check to see if the other collider is the player...
        if (other.CompareTag("Player"))
        {
            // ... if it is, check to see if its teleport flag is true...
            if (PlayerController.instance.canTeleport)
                // ... if it is, set it to false (stops teleport loops).
                PlayerController.instance.canTeleport = false;
            else
                // ... if it isn't, set it to true (so that we're able to teleport again).
                PlayerController.instance.canTeleport = true;
        }
        // Check to see if the other collider is the jungle rodent...
        else if (other.CompareTag("Jungle Rodent"))
        {
            // Get if it can teleport...
            bool canTeleport = other.GetComponent<RodentAI>().CanTeleport;

            // ... if it can, set the flag to false (stops teleport loops).
            if (canTeleport)
                other.GetComponent<RodentAI>().CanTeleport = false;
            else
                // if it can't, set the flag to true (so that it's able to teleport again).
                other.GetComponent<RodentAI>().CanTeleport = true;
        }
    }
}
