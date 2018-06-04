using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanTrigger : MonoBehaviour {

    //---------------------------------------------------------------//
    //Put this script on the object that will trigger the camera pan
    //---------------------------------------------------------------//

    //(if(indi.transform.position.x >= (Screen.width / 2f) + 2f))
    //          move to next pos to the left

    //The gameObject where the camera will pan to
    public GameObject[] camLocations;
    //the gameObjects Vector3
    //Vector3[] panPos;

    int currentLocal = 0;

    [SerializeField] GameObject player;

    public bool canShift = true;

	// Use this for initialization
	void Start () {
        ////setting the Vector3
        //for(int i = 0; i < camLocations.Length; i++)
        //{
        //    panPos[i] = camLocations[i].transform.position;
        //}
	}
	
    void FixedUpdate()
    {
        Debug.Log(currentLocal);
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        if (playerScreenPos.x >= Screen.width - 30f && canShift)
        {
            currentLocal += 1;
            if(currentLocal > camLocations.Length)
            {
                currentLocal = camLocations.Length -1;
            }
            CameraPan.instance.panCam(camLocations[currentLocal].transform.position);

            canShift = false;
        }

        else if (playerScreenPos.x <= 30f && canShift)
        {
            currentLocal -= 1;
            if(currentLocal < 0)
            {
                currentLocal = 0;
            }
            CameraPan.instance.panCam(camLocations[currentLocal].transform.position);

            canShift = false;
        }

        Debug.Log("Camera Moving: " + GetComponent<CameraPan>().isMoving);
        Debug.Log("Can Shift: " + canShift);

        if (!GetComponent<CameraPan>().isMoving)
            canShift = true;
    }

	//void OnTriggerEnter(Collider c)
 //   {
 //       //Checking if the triggering object is the player
 //       if (c.gameObject.tag == "Player")
 //       {
 //           //Calling the camera pan script and giving it a place to go
 //           CameraPan.instance.panCam(whereToGo.transform.position);
 //       }
 //   }
}
