//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class OldTele : MonoBehaviour
//{
//    //------------------ The old teleport script. --------------------//

//    // for some reason any walls will block the teleport
//    // Solution - If an GameObject relies on a NavMesh in order to figure out where to go, it can not be moved off the 
//    // NavMesh at any point. 

//    public GameObject teleportLocation;

//    // Varaible to hold the position of the teleport GameObject.
//    private Vector3 locationV3;

//	void Start ()
//    {
//        // Makes a shorthand variable for the teleport locations Vector3.
//        locationV3 = teleportLocation.transform.position;
//	}

//    // Checking for collision with object to be teleported
//	void OnTriggerEnter(Collider other)
//    {
//        // If the other collider's tag is Player... 
//        if (other.CompareTag("Indy"))
//        {
//            // Check to see if the player can teleport...
//            if (PlayerController.instance.canTeleport)
//            {
//                // ... set the NavMeshAgent to inactive so the player can move off the mesh
//                PlayerController.instance.GetComponent<NavMeshAgent>().enabled = false;

//                // ... if it can, set its position to the teleport position...
//                other.transform.position = locationV3;
//            }
//        }
//        // If the collider's tag is Jungle Rodent...
//        else if (other.CompareTag("Jungle Rodent"))
//        {
//            // Check to see if the rodent can teleport...
//            if (other.GetComponent<RodentAI>().CanTeleport)
//            {
//                // ... if it can, set its position to the teleport position...
//                other.transform.position = locationV3;

//                // ... and set its destination to its now current position.
//                other.GetComponent<RodentAI>().SetNewDest(locationV3);
//            }
//        }
//    }

//    //Resets the players NavMesh after he teleports.
//    private void OnTriggerStay(Collider other)
//    {
//        // Checks to see if it is the player colliding
//        if (other.CompareTag("Indy"))
//        {
//            // Checks if the players NavMeshAgent is set to inactive
//            if(PlayerController.instance.GetComponent<NavMeshAgent>().enabled == false)

//            PlayerController.instance.GetComponent<NavMeshAgent>().enabled = true;

//            PlayerController.instance.WalkToUI(other.transform.position);
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        // Check to see if the other collider is the player...
//        if (other.CompareTag("Player"))
//        {
//            // ... if it is, check to see if its teleport flag is true...
//            if (PlayerController.instance.canTeleport)
//                // ... if it is, set it to false (stops teleport loops).
//                PlayerController.instance.canTeleport = false;
//            else
//                // ... if it isn't, set it to true (so that we're able to teleport again).
//                PlayerController.instance.canTeleport = true;
//        }

//        // Check to see if the other collider is the jungle rodent...
//        else if (other.CompareTag("Jungle Rodent"))
//        {
//            // Get if it can teleport...
//            bool canTeleport = other.GetComponent<RodentAI>().CanTeleport;

//            // ... if it can, set the flag to false (stops teleport loops).
//            if (canTeleport)
//                other.GetComponent<RodentAI>().CanTeleport = false;
//            else
//                // if it can't, set the flag to true (so that it's able to teleport again).
//                other.GetComponent<RodentAI>().CanTeleport = true;
//        }
//    }
//}