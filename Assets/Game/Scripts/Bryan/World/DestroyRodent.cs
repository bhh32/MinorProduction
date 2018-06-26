using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRodent : MonoBehaviour 
{
    [SerializeField] GameObject rodentCutscene;
    [SerializeField] GameObject rodentToolTip;

    GameObject rodent;

    void TriggerRodentCutscene()
    {
        RodentAI.instance.OnWhipped -= TriggerRodentCutscene;
        Destroy(rodent.gameObject, 0.5f);

        rodentCutscene.SetActive(true);
        Destroy(rodentToolTip);

        Destroy(gameObject);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jungle Rodent"))
        {
            rodent = other.gameObject;

            RodentAI.instance.OnWhipped += TriggerRodentCutscene;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == rodent)
        {
            RodentAI.instance.OnWhipped -= TriggerRodentCutscene;
            rodent = null;
        }
    }
}
