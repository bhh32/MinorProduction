using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneCam : MonoBehaviour 
{
    [SerializeField] GameObject cutSceneCam;
    [SerializeField] GameObject mainCamera;
    [SerializeField] Animation cutSceneAnim;
    [SerializeField] AnimationClip fightClip;
    [SerializeField] Animator cutSceneAnimCont;

    [SerializeField] float timer;

    void Awake()
    {
        cutSceneAnim.clip = fightClip;
    }

	// Update is called once per frame
	void Update ()
    {
        if (!cutSceneAnim.isPlaying)
        {
            cutSceneAnimCont.SetBool("canPlay", false);
            mainCamera.SetActive(true);
            cutSceneCam.SetActive(false);
        }
    }
}
