using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseInventory_Anim : MonoBehaviour 
{
    [SerializeField] Toggle	inventoryToggle;
    [SerializeField] Animator anim;

    [SerializeField] Sprite toggleDefault;
    [SerializeField] Sprite toggleDefaultHighlight;
    [SerializeField] Sprite toggleOpen;
    [SerializeField] Sprite toggleOpenHighlight;

    public void OpenClose()
    {
        var spriteState = inventoryToggle.spriteState;

        if (inventoryToggle.isOn)
        {
            anim.SetBool("isOpening", false);
            anim.SetBool("isClosing", true);
            inventoryToggle.image.sprite = toggleOpen;
            spriteState.highlightedSprite = toggleOpenHighlight;
        }
        else
        {
            anim.SetBool("isOpening", true);
            anim.SetBool("isClosing", false);
            inventoryToggle.image.sprite = toggleDefault;
            spriteState.highlightedSprite = toggleDefaultHighlight;
        }
    }
}
