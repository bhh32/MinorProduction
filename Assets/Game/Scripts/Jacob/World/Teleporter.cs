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
    [SerializeField] GameObject mainGameCam;
	
    [Header("Teleportation Delay"), SerializeField] float teleportDelay;
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
                    StartCoroutine(TeleportDelay(teleportDelay, jungleEntranceMovePoint));
					cameraFade.SetActive(true);
					break;
                case "Cave Entrance":
                    StartCoroutine(TeleportDelay(teleportDelay, caveEntranceMovePoint));
					cameraFade.SetActive(true);
					break;
                case "Cave Exit":
                    StartCoroutine(TeleportDelay(teleportDelay, caveExitMovePoint));
                    cameraFade.SetActive(true);
					break;
                case "Clearing Entrance":
                    StartCoroutine(TeleportDelay(teleportDelay, clearingEntranceMovePoint));
                    cameraFade.SetActive(true);
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
                        var newSophia = GameObject.FindGameObjectWithTag("Temple Sophia").GetComponent<CharacterTalkText>();
                        var newSternhart = GameObject.FindGameObjectWithTag("Temple Sternhart").GetComponent<CharacterTalkText>();

                        if (DialogSystemManager.instance.sophia != newSophia)
                            DialogSystemManager.instance.sophia = newSophia;
                        if (DialogSystemManager.instance.sternhart != newSternhart)
                            DialogSystemManager.instance.sternhart = newSternhart;
                        
                        StartCoroutine(TeleportDelay(teleportDelay, insideTempleMovePoint));
                        cameraFade.SetActive(true);
                        clearingCam.SetActive(false);
                        insideCam.SetActive(true);                        
                    }
                    break;
                case "Clearing WarpTo Location":
                    //StartCoroutine(CameraSwapDelay(teleportDelay, clearingCam, insideCam));
                    cameraFade.SetActive(true);
                    StartCoroutine(TeleportDelay(teleportDelay, clearingMovePoint));
                    mainGameCam.SetActive(false);
                    insideCam.SetActive(false);
                    clearingCam.SetActive(true);
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
