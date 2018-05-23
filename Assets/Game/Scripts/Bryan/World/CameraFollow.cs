using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    [SerializeField] GameObject indy;

    float offsetX;
    float offsetY;
    float offsetZ;

	void Start () 
    {
        offsetX = transform.position.x - indy.transform.position.x;
        offsetY = transform.position.y - indy.transform.position.y;
        offsetZ = transform.position.z - indy.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = new Vector3(indy.transform.position.x + offsetX, indy.transform.position.y + offsetY, indy.transform.position.z + offsetZ);
	}
}
