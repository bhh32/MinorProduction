using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharTalkCineCont : MonoBehaviour 
{
    [SerializeField] Animator anim;

    void OnEnable()
    {
        if (!anim.enabled)
            anim.enabled = true;

        if (anim.GetBool("isTalking"))
            anim.SetBool("isTalking", false);
        else
            anim.SetBool("isTalking", true);
    }
}
