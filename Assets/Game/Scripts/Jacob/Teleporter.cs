using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleporter : MonoBehaviour
{
    [Header("Teleportation Point")]
	[SerializeField] GameObject teleportLocation;

    [Header("Move After Teleport Points")]
	[SerializeField] GameObject jungleEntranceMovePoint;
	[SerializeField] GameObject caveEntranceMovePoint;
	[SerializeField] GameObject caveExitMovePoint;
	[SerializeField] GameObject clearingEntranceMovePoint;
    [SerializeField] GameObject caveRoundABoutMovePoint;
    [SerializeField] GameObject caveFarRightMovePoint;
    [SerializeField] GameObject insideTempleMovePoint;
    [SerializeField] GameObject clearingMovePoint;

    [Header("Indy NavMeshAgent")]
	[SerializeField] NavMeshAgent indyAgent;

    [Header("Cameras")]
    [SerializeField] GameObject clearingCam;
    [SerializeField] GameObject insideCam;

    [Header("Teleportation Delay"), SerializeField] float teleportDelay;

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
                    StartCoroutine(TeleportDelay(teleportDelay, jungleEntranceMovePoint));
					break;
                case "Cave Entrance":
                    StartCoroutine(TeleportDelay(teleportDelay, caveEntranceMovePoint));
					break;
                case "Cave Exit":
                    StartCoroutine(TeleportDelay(teleportDelay, caveExitMovePoint));
					break;
                case "Clearing Entrance":
                    StartCoroutine(TeleportDelay(teleportDelay, clearingEntranceMovePoint));
					break;
                case "Cave Left":
                case "Cave Right":
                    StartCoroutine(TeleportDelay(teleportDelay, caveRoundABoutMovePoint));
                    break;
                case "Cave Far Right":
                    StartCoroutine(TeleportDelay(teleportDelay, caveFarRightMovePoint));
                    break;
                case "Inside Temple WarpTo Location":
                    if (DialogSystemManager.instance.isSecondComplete)
                    {
                        StartCoroutine(CameraSwapDelay(teleportDelay, insideCam, clearingCam));
                        StartCoroutine(TeleportDelay(teleportDelay, insideTempleMovePoint));
                    }
                    break;
                case "Clearing WarpTo Location":
                    StartCoroutine(CameraSwapDelay(teleportDelay, clearingCam, insideCam));
                    StartCoroutine(TeleportDelay(teleportDelay, clearingMovePoint));
                    break;
				default:
					Debug.LogError("Something went wrong with teleporting!" + gameObject.name);
					break;
			}
		}
    }

    #region Helper Methods

    IEnumerator TeleportDelay(float delay, GameObject movePoint)
    {
        yield return new WaitForSeconds(delay);

        indyAgent.Warp(teleportLocation.transform.position);

        if(indyAgent.enabled)
            indyAgent.SetDestination(movePoint.transform.position);
    }

    IEnumerator CameraSwapDelay(float delay, GameObject newActiveCam, GameObject newDisabledCam)
    {
        yield return new WaitForSeconds(delay);

        newActiveCam.SetActive(true);
        newDisabledCam.SetActive(false);
    }

    #endregion
}
