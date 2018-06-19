using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherNature : MonoBehaviour 
{
    [SerializeField] Animator snakeFight;
    [SerializeField] CharacterTalkText indy;
    bool hasPlayed = false;
	
	// Update is called once per frame
	void Update () 
    {
        if (snakeFight.isActiveAndEnabled)
            hasPlayed = true;

        if (!snakeFight.isActiveAndEnabled && hasPlayed)
        {
            indy.TextUpdate("Good 'ole Mother Nature!");
            indy.isTextEnabled = true;
            Destroy(gameObject);
        }
	}
}
