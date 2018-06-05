using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRodent : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jungle Rodent") && RodentAI.instance.WasWhipped)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
