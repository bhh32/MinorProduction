using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    //-----------------------------------------------------------//
    //Put this script on the camera that will be panning
    //-----------------------------------------------------------//


    //Creating Instance for the camera controller
    #region singleton
    public static CameraPan instance;

    //setting instance
    void Awake()
    {
        instance = this;
    }
    #endregion

    //speed at which the camera will pan
    public float panRange = 0.7f;

    bool isPanning = false;
    public bool isMoving = false;
	
	public void panCam(Vector3 newPos)
    {
        //Makes sure the camera is not currently panning
        if (isPanning == false)
        {
            isPanning = true;
            //Debug.Log("I am lerping!");
            //calls the update to move the camera
            isMoving = true;
            StartCoroutine(PanTimer(newPos));
         }
    }


    //The Coroutine that moves the camera
    IEnumerator PanTimer(Vector3 newPos)
    {
        float timer = 0f;
        float journeyLength = Vector3.Distance(newPos, transform.position);
        while(Vector3.Distance(newPos,transform.position) >= .5f)
        {
            timer++;
            float distanceCovered = Mathf.Abs((Time.time - timer)) * panRange;
            float fracJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, newPos, panRange);
            yield return null;
        }

        isMoving = false;
    }
}
