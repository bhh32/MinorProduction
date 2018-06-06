using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleporter : MonoBehaviour
{
	[SerializeField] GameObject teleportLocation;
	[SerializeField] GameObject jungleEntranceMovePoint;
	[SerializeField] GameObject caveEntranceMovePoint;

	[SerializeField] GameObject indyPrefab;

    // Checking for collision with object to be teleported
	void OnTriggerEnter(Collider other)
    {
		Debug.Log (other.tag);
        // If the other collider's tag is Player...
		if (other.CompareTag("Indy"))
        {
			
            // Check to see if the player can teleport...
            if (PlayerController.instance.canTeleport)
            {
                // ... set the ability to teleport to false so you dont transport instantly...
                
				other.GetComponent<Rigidbody> ().detectCollisions = false;
                // ... if it can, set its position to the teleport position...
				Vector3 newPos = new Vector3(teleportLocation.transform.position.x, teleportLocation.transform.position.y, teleportLocation.transform.position.z);
				//other.transform.position = newPos;

				Destroy (other.gameObject);
				GameObject indy = Instantiate (indyPrefab, newPos, Quaternion.Euler(1f, 180f, 1f)) as GameObject;
				indy.tag = "Indy";
				indy.GetComponent<PlayerController> ().canTeleport = false;
				indy.GetComponent<AudioSource> ().playOnAwake = false;
				indy.GetComponent<AudioSource> ().enabled = true;
				indy.GetComponent<Animator> ().enabled = true;
				indy.GetComponent<NavMeshAgent> ().enabled = true;
				indy.GetComponent<CharacterTalkText> ().enabled = true;
				indy.GetComponent<PlayerController> ().enabled = true;                
            }
        }

    }

	void OnTriggerStay(Collider other)
	{
		if (gameObject.name == "Cave Entrance" && !PlayerController.instance.canTeleport)
			PlayerController.instance.WalkToUI (caveEntranceMovePoint.transform.position);
		else if (gameObject.name == "Jungle Entrance" && !PlayerController.instance.canTeleport)
			PlayerController.instance.WalkToUI (jungleEntranceMovePoint.transform.position);
	}

    private void OnTriggerExit(Collider other)
    {
        // Check to see if the other collider is the player...
        if (other.CompareTag("Player"))
        {
            // ... if it is, check to see if its teleport flag is true...
//            if (PlayerController.instance.canTeleport)
//                // ... if it is, set it to false (stops teleport loops).
//                PlayerController.instance.canTeleport = false;
//            else
                // ... if it isn't, set it to true (so that we're able to teleport again).
                PlayerController.instance.canTeleport = true;
        }
    }
}
