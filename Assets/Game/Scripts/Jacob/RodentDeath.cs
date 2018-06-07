using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RodentDeath : MonoBehaviour 
{
    //This array will hold all the objects that will be creating the cutscene (They should all be
    // set to NOT ACTIVE when the scene starts.
    public GameObject[] cutsceneObjects;

    //This is where the normal camera will be stored.
    public GameObject mainCamera;

    //checks for a trigger
    void OnTriggerEnter(Collider other)
    {
        //makes sure it is the rodent that triggers the box.
        if (other.CompareTag("Jungle Rodent") && RodentAI.instance.WasWhipped)
        {
            //Destroyes the Rodent.
            Destroy(other.gameObject);
            //Sets the main camera to INACTIVE so it will not overtake the cutscene camera
            mainCamera.SetActive(false);
            //sets all the objects used in the cutscene to ACTIVE.
            for (int i = 0; i < cutsceneObjects.Length; i++)
            {
                cutsceneObjects[i].SetActive(true);
            }
            //Destroy(gameObject);
        }
    }
}
