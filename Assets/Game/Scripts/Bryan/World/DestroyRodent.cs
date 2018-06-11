using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRodent : MonoBehaviour 
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject cutSceneCam;
    [SerializeField] Animator cutSceneAnimation;
    [SerializeField] GameObject rodentToolTip;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jungle Rodent") && RodentAI.instance.WasWhipped)
        {
            Destroy(other.gameObject, 1f);
            cutSceneCam.SetActive(true);
            mainCamera.SetActive(false);


            cutSceneAnimation.SetBool("canPlay", true);

            Destroy(other.gameObject);
            Destroy(rodentToolTip);
            Destroy(gameObject);
        }
    }
}
