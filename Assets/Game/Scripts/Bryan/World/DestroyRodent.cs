using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRodent : MonoBehaviour 
{
    [SerializeField] GameObject rodentCutscene;
    [SerializeField] GameObject rodentToolTip;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Jungle Rodent") && RodentAI.instance.WasWhipped)
        {
            Destroy(other.gameObject, 1f);
            rodentCutscene.SetActive(true);
            Destroy(rodentToolTip);
            Destroy(gameObject);
        }
    }
}
