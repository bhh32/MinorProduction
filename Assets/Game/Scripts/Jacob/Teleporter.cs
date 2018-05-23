using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    //----------------------------------------------------------------------------//
    //Make sure that the exit is exactly where you want the Object to teleport to.
    //Having the exit too high may mess with the AI.
    //----------------------------------------------------------------------------//


    //----------------------------------------------------------------------------//
    //List of known bugs:
    //-If the teleporter is a two way tele porter the object that was teleported
    // will be instantly teleported again.
    //----------------------------------------------------------------------------//

    //----------------------------------------------------------------------------//
    //Potental fixes:
    //-Add a timer to the teleporter so it will not be activated instantly when entered
    //----------------------------------------------------------------------------//

    //object that will be teleported
    public GameObject teleportObject;
    //location object will be teleported to (set as a second teleporter once the insta teleport
    //bug is fixed)
    public GameObject teleportLocation;

    private Vector3 locationV3;


	void Start () {
        //getting the vector3 from the game object where objects will be teleported to
        locationV3 = teleportLocation.transform.position;
	}

    // Checking for collision with object to be teleported
	void OnTriggerEnter(Collider c)
    {
        //checking if collided object is the player(this makes sure that only the player can reset
        //where they are going)
        if(c.gameObject == teleportObject && c.gameObject.tag == "Player")
        {
            //checking if collided object is able to teleport
            teleportObject.transform.position = locationV3;
            PlayerController.instance.WalkToUI(c.transform.position);
        }
        //If the player wasn't the one teleported the player controller will not be effected
        else if(c.gameObject == teleportObject)
        {
            teleportObject.transform.position = locationV3;
        }

    }
}
