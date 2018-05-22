using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseInventory_Anim : MonoBehaviour 
{
    [SerializeField] Toggle	inventoryToggle;
    [SerializeField] Animator anim;

    public void OpenClose()
    {
        if (inventoryToggle.isOn)
        {
            inventoryToggle.isOn = false;
            anim.SetBool("isOpening", false);
            anim.SetBool("isClosing", true);
        }
        else
        {
            inventoryToggle.isOn = true;
            anim.SetBool("isOpening", true);
            anim.SetBool("isClosing", false);
        }
    }
}
