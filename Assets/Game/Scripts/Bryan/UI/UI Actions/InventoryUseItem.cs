using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUseItem : MonoBehaviour 
{
    #region Singleton
    public static InventoryUseItem instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Item currentItem;
    [SerializeField] CharacterTalkText indyTalkText;

    [SerializeField] GameObject animalHead;
    [SerializeField] GameObject animalHeadWithSpiral;

    public void Use(GameObject clickedObj)
    {
        if (currentItem != null)
        {
            switch (currentItem.name)
            {
                case "Whip":
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    InventoryUIManager.instance.OnInventoryUpdate(currentItem);

                    if (clickedObj.CompareTag("Jungle Rodent"))
                    {   
                        //TODO: Play Indy whip animation
                        SoundManager.instance.PlayIndyAudio(SoundManager.instance.whipSound);
                        //SoundManager.instance.PlaySuccessAudio(SoundManager.instance.successMusic);
                        RodentAI.instance.WasWhipped = true;
                    }
                    else
                    {
                        indyTalkText.TextUpdate("I can't use that with that");
                        indyTalkText.isTextEnabled = true;
                    }

                    currentItem = null;
                    break;
                case "Spiral Design":
                    if (clickedObj.CompareTag("Animal Head"))
                    {
                        animalHead.SetActive(false);
                        animalHeadWithSpiral.SetActive(true);
                        indyTalkText.TextUpdate("Hey it worked!");
                        indyTalkText.isTextEnabled = true;
                    }
                    else
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                        UIActionManager.instance.DoAction_Pickup(currentItem);
                        currentItem = null;
                    }
                    break;
                case "Kerosene Lamp":
                    if (currentItem.isOpen)
                    {
                        if (clickedObj.CompareTag("Spiral Design"))
                        {
                            currentItem.hasBeenUsed = true;
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            //currentItem = null;
                            clickedObj.GetComponent<ItemPickUp>().Item.isUsable = true;
                            SoundManager.instance.PlaySuccessAudio(SoundManager.instance.successMusic);
                            // Do the pour animation
                            indyTalkText.TextUpdate("Look! The kerosene ate away the tarnish!");
                            indyTalkText.isTextEnabled = true;
                        }
                        else
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            InventoryUIManager.instance.OnInventoryUpdate(currentItem);
                            currentItem = null;
                            indyTalkText.TextUpdate("I can't use that with that");
                            indyTalkText.isTextEnabled = true;
                        }
                    }
                    else
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                        InventoryUIManager.instance.OnInventoryUpdate(currentItem);
                        currentItem = null;
                        if (clickedObj.CompareTag("Spiral Design"))
                        {
                            indyTalkText.TextUpdate("I need to open it first!");
                            indyTalkText.isTextEnabled = true;
                        }
                        else
                        {
                            indyTalkText.TextUpdate("I can't use this with that.");
                            indyTalkText.isTextEnabled = true;
                        }
                    }
                    break;
                default:
                    indyTalkText.TextUpdate("I can't use that!");
                    indyTalkText.isTextEnabled = true;
                    InventoryUIManager.instance.OnInventoryUpdate(currentItem);
                    currentItem = null;
                    break;
            }
        }
        else
        {
            indyTalkText.TextUpdate("I didn't choose an item to use!");
            indyTalkText.isTextEnabled = true;;
        }
    }

    public void SetCurrentItem(Item newItem)
    {
        currentItem = newItem;
    }
}
