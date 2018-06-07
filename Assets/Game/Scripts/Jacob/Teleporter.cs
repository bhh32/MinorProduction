using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleporter : MonoBehaviour
{
	[SerializeField] GameObject teleportLocation;
	[SerializeField] GameObject jungleEntranceMovePoint;
	[SerializeField] GameObject caveEntranceMovePoint;
	[SerializeField] GameObject caveExitMovePoint;
	[SerializeField] GameObject clearingEntranceMovePoint;
    [SerializeField] GameObject caveRoundABoutMovePoint;
    [SerializeField] GameObject caveFarRightMovePoint;

	[SerializeField] NavMeshAgent indyAgent;

    // Checking for collision with object to be teleported
	void OnTriggerEnter(Collider other)
    {
        // If the other collider's tag is Indy and he can teleport...
		if (other.CompareTag ("Indy") && PlayerController.instance.canTeleport) 
		{
			// Ensure there isn't a teleport loop...
			PlayerController.instance.canTeleport = false;

			indyAgent.Warp(teleportLocation.transform.position);

			switch(teleportLocation.name)
			{
				case "Jungle Entrance":
					indyAgent.SetDestination(jungleEntranceMovePoint.transform.position);
					break;
				case "Cave Entrance":
					indyAgent.SetDestination(caveEntranceMovePoint.transform.position);
					break;
				case "Cave Exit":
					indyAgent.SetDestination(caveExitMovePoint.transform.position);
					break;
				case "Clearing Entrance":
					indyAgent.SetDestination(clearingEntranceMovePoint.transform.position);
					break;
                case "Cave Left":
                case "Cave Right":
                    indyAgent.SetDestination(caveRoundABoutMovePoint.transform.position);
                    break;
                case "Cave Far Right":
                    indyAgent.SetDestination(caveFarRightMovePoint.transform.position);
                    break;
				default:
					Debug.LogError("Something went wrong with teleporting!" + gameObject.name);
					break;
			}
		}
    }
}
