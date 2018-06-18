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
    [SerializeField] GameObject insideTempleMovePoint;
    [SerializeField] GameObject clearingMovePoint;

	[SerializeField] NavMeshAgent indyAgent;
    [SerializeField] GameObject clearingCam;
    [SerializeField] GameObject insideCam;

    [SerializeField] GameObject cameraFade;

    // Checking for collision with object to be teleported
	void OnTriggerEnter(Collider other)
    {
        // If the other collider's tag is Indy and he can teleport...
		if (other.CompareTag ("Indy") && PlayerController.instance.canTeleport) 
		{
			// Ensure there isn't a teleport loop...
			PlayerController.instance.canTeleport = false;
            indyAgent = other.GetComponent<NavMeshAgent>();
			

			switch(teleportLocation.name)
			{
				case "Jungle Entrance":
                    indyAgent.Warp(teleportLocation.transform.position);
					indyAgent.SetDestination(jungleEntranceMovePoint.transform.position);
                    cameraFade.SetActive(true);
					break;
				case "Cave Entrance":
                    indyAgent.Warp(teleportLocation.transform.position);
					indyAgent.SetDestination(caveEntranceMovePoint.transform.position);
                    cameraFade.SetActive(true);
					break;
				case "Cave Exit":
                    indyAgent.Warp(teleportLocation.transform.position);
					indyAgent.SetDestination(caveExitMovePoint.transform.position);
					break;
				case "Clearing Entrance":
                    indyAgent.Warp(teleportLocation.transform.position);
					indyAgent.SetDestination(clearingEntranceMovePoint.transform.position);
					break;
                case "Cave Left":
                case "Cave Right":
                    indyAgent.Warp(teleportLocation.transform.position);
                    indyAgent.SetDestination(caveRoundABoutMovePoint.transform.position);
                    break;
                case "Cave Far Right":
                    indyAgent.Warp(teleportLocation.transform.position);
                    indyAgent.SetDestination(caveFarRightMovePoint.transform.position);
                    break;
                case "Inside Temple WarpTo Location":
                    if (DialogSystemManager.instance.isSecondComplete)
                    {
                        insideCam.SetActive(true);
                        clearingCam.SetActive(false);
                        indyAgent.Warp(teleportLocation.transform.position);
                    }
                    break;
                case "Clearing WarpTo Location":
                    clearingCam.SetActive(true);
                    insideCam.SetActive(false);
                    indyAgent.Warp(teleportLocation.transform.position);
                    break;
				default:
					Debug.LogError("Something went wrong with teleporting!" + gameObject.name);
					break;
			}
		}
    }
}
