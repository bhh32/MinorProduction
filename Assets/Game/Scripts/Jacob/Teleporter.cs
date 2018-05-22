using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    //object that will be teleported
    public GameObject teleportObject;
    //location object will be teleported to
    public GameObject teleportLocation;

    private Vector3 locationV3;
    
	void Start () {
        locationV3 = teleportLocation.transform.position;
	}
	
    // Checking for collision with object to be teleported
	void OnTriggerEnter(Collider c)
    {
        if(c.gameObject == teleportObject)
        {
            teleportObject.transform.position = locationV3;
            PlayerController.instance.WalkToUI(c.transform.position);
        }
    }
}
