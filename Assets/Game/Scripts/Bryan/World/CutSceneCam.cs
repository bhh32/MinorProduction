using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCam : MonoBehaviour 
{
    [SerializeField] GameObject cutSceneCam;
    [SerializeField] GameObject mainCamera;
    [SerializeField] Animator cutSceneAnimCont;

    public void EndCutScene()
    {
        mainCamera.SetActive(true);
        cutSceneCam.SetActive(false);

        Destroy(cutSceneAnimCont.gameObject);
    }
}
