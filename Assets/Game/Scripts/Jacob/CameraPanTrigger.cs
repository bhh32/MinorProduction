using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanTrigger : MonoBehaviour {

    //---------------------------------------------------------------//
    //Put this script on the object that will trigger the camera pan
    //---------------------------------------------------------------//

    
    //The gameObject where the camera will pan to
    public GameObject whereToGo;
    //the gameObjects Vector3
    Vector3 panPos;

	// Use this for initialization
	void Start () {
        //setting the Vector3
        panPos = whereToGo.transform.position;
	}
	
	void OnTriggerEnter(Collider c)
    {
        //Checking if the triggering object is the player
        if (c.gameObject.tag == "Player")
        {
            //Calling the camera pan script and giving it a place to go
            CameraPan.instance.panCam(whereToGo.transform.position);
        }
    }
}
