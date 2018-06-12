using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPickUp : MonoBehaviour 
{
    public delegate void UpdatePickup();
    public static UpdatePickup OnCanPickup;
    void Awake()
    {
        OnCanPickup += CanPickup;
    }

    void CanPickup()
    {
        gameObject.GetComponent<ItemPickUp>().enabled = true;
    }
}
