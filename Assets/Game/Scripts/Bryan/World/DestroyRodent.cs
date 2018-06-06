using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRodent : MonoBehaviour 
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject cutSceneCam;
    [SerializeField] Animator cutSceneAnimation;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jungle Rodent") && RodentAI.instance.WasWhipped)
        {      
            cutSceneCam.SetActive(true);
            mainCamera.SetActive(false);


            cutSceneAnimation.SetBool("canPlay", true);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
