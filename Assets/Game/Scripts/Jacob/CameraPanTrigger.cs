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

    protected float panTimer = 1.0f;
    protected float timer;
    public float followSharpness = 0.1f;

    Vector3 offset;

    // Use this for initialization
    void Awake () {
        ////setting the Vector3
        //for(int i = 0; i < camLocations.Length; i++)
        //{
        //    panPos[i] = camLocations[i].transform.position;
        //}

        timer = panTimer;
        offset = transform.position - player.transform.position;
    }
	
    void Update()
    {
        timer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        Debug.Log(currentLocal);
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(player.transform.position);
        if (playerScreenPos.x >= Screen.width - 50f && canShift && timer <= 0)
        {
            MoveCamFwd();
            timer = panTimer;
        }

        else if (playerScreenPos.x <= 50f && canShift && timer <= 0)
        {
            MoveCamBack();
            timer = panTimer;
        }

        Debug.Log("Camera Moving: " + GetComponent<CameraPan>().isMoving);
        Debug.Log("Can Shift: " + canShift);
        //Debug.Log("PanTime: " + timer);

        if (!GetComponent<CameraPan>().isMoving)
        {
            canShift = true;
        }
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

    void MoveCamFwd()
    {
        currentLocal += 1;
        if (currentLocal >= camLocations.Length)
        {
            currentLocal = camLocations.Length;
        }

        //CameraPan.instance.panCam(camLocations[currentLocal].transform.position);
        float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * 30f);

        transform.position = Vector3.Lerp(transform.position,
                                          player.transform.position + offset,
                                          blend);

        canShift = false;
    }

    void MoveCamBack()
    {
        currentLocal -= 1;
        if (currentLocal <= 0)
        {
            currentLocal = 0;
        }

        //CameraPan.instance.panCam(camLocations[currentLocal].transform.position);
        float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * 30f);

        transform.position = Vector3.Lerp(transform.position,
                                          player.transform.position + offset,
                                          blend);

        canShift = false;
    }
}
