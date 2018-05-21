using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public GameObject teleportObject;
    public GameObject teleportLocation;

    Vector3 locationV3;

    public bool isTriggered = false;

	void Start () {
        locationV3 = teleportLocation.transform.position;
	}
	
	void OnTriggerEnter(Collider c)
    {
        isTriggered = true;
        if(c.gameObject == teleportObject)
        {
            teleportObject.transform.position = locationV3;
        }
    }
}
