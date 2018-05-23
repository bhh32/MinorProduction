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
            anim.SetBool("isOpening", false);
            anim.SetBool("isClosing", true);
        }
        else
        {
            anim.SetBool("isOpening", true);
            anim.SetBool("isClosing", false);
        }
    }
}
