using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseInventory_Anim : MonoBehaviour 
{
    [SerializeField] Toggle	inventoryToggle;
    [SerializeField] SpriteState toggleState;
    [SerializeField] Animator anim;

    [SerializeField] Sprite toggleDefault;
    [SerializeField] Sprite toggleDefaultHighlight;
    [SerializeField] Sprite toggleOpen;
    [SerializeField] Sprite toggleOpenHighlight;

    void FixedUpdate()
    {
        toggleState = inventoryToggle.spriteState;

        if (inventoryToggle.isOn)
        {
            inventoryToggle.image.sprite = toggleDefault;
            toggleState.highlightedSprite = toggleDefaultHighlight;
        }
        else
        {
            inventoryToggle.image.sprite = toggleOpen;
            toggleState.highlightedSprite = toggleOpenHighlight;
        }

        inventoryToggle.spriteState = toggleState;
    }

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
