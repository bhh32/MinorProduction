using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryAssignedItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Inventory Sprites")]
    public Item assignedItem = null;

    [SerializeField] Sprite emptySlotSprite;
    [SerializeField] Sprite emptySlotHighlightedSprite;
    [SerializeField] Sprite itemDefaultSprite;
    [SerializeField] Sprite itemHighlightedSprite;

    [Header("Cursor Textures")]
    [SerializeField] Texture2D whipCursor;

    [SerializeField, Header("Player Character")]
    CharacterTalkText indianaJones;

    bool didClick = false;

    bool wasUsed = false;

    public void UpdateSprites(Item newItem)
    {
        if (newItem == null)
            assignedItem = null;
        else
            assignedItem = newItem;

        Button thisSlot = GetComponent<Button>();

        if (assignedItem != null)
        {
            if (!assignedItem.isOpen)
            {
                itemDefaultSprite = assignedItem.icon;
                itemHighlightedSprite = assignedItem.highlightedIcon;
            }
            else
            {
                itemDefaultSprite = assignedItem.openedIcon;
                itemHighlightedSprite = assignedItem.openedHiglightedIcon;
            }

            thisSlot.GetComponent<Image>().sprite = itemDefaultSprite;
        }
        else
        {
            thisSlot.GetComponent<Image>().sprite = emptySlotSprite;
        }
    }

    #region IPointerEnterHandler implementation

    public void OnPointerEnter(PointerEventData eventData)
    {
        Image thisSlot = GetComponent<Image>();

        if (thisSlot.sprite == itemDefaultSprite)
            thisSlot.sprite = itemHighlightedSprite;
        else
            thisSlot.sprite = emptySlotHighlightedSprite;
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        Image thisSlot = GetComponent<Image>();
       
        if (thisSlot.sprite == itemHighlightedSprite || thisSlot.sprite == itemDefaultSprite)
            thisSlot.sprite = itemDefaultSprite;
        else
            thisSlot.sprite = emptySlotSprite;
    }

    #endregion

    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        // Set didClick flag to true
        didClick = true;
        // Get the current Image on this inventory slot button
        Image thisSlot = GetComponent<Image>();
        // Get the instance of the UIActionManager
        UIActionManager actions = UIActionManager.instance;

        // Check if we're going to use an item and if we've selected an item from the inventory
        // to actually use.
        if (actions.canUse && assignedItem != null)
        {
            // Check the name of the item we are going to use and do the appropriate action
            // for that item.
            switch (assignedItem.name)
            {
                case "Whip":
                    Cursor.SetCursor(whipCursor, Vector2.zero, CursorMode.Auto);
                    InventoryUseItem.instance.currentItem = assignedItem;
                    break;
                case "Kerosene Lamp":
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    if (assignedItem.isOpen)
                    {
                        InventoryUseItem.instance.currentItem = assignedItem;
                        wasUsed = true;
                    }
                    else
                    {
                        UpdateSprites(assignedItem);
                        indianaJones.TextUpdate("I think I need to open it first.");
                        indianaJones.isTextEnabled = true;
                    }
                    break;
                default:
                    Debug.LogError("Something in switching the cursor went wrong!" + assignedItem);
                    break;
            }

            // Set the assignedItem to null as we've either used it or put it back into the inventory
            assignedItem = null;

            // Set the itemDefaultSprite and itemHighlightedSprite to null, as 
            // we no longer have an item.
            itemDefaultSprite = null;
            itemHighlightedSprite = null;

            if (wasUsed)
                UpdateSprites(null);
        }
        else if (actions.canLookAt)
        {
            if (assignedItem != null)
            {
                actions.DoAction_LookAt(assignedItem, didClick);
            }
            else
            {
                if (InventoryUseItem.instance.currentItem != null)
                {
                    if (!assignedItem.isOpen)
                    {
                        InventoryUIManager.instance.OnInventoryUpdate(InventoryUseItem.instance.currentItem);
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    }
                    else
                        UpdateSprites(assignedItem);
                }
                else
                {
                    indianaJones.TextUpdate("There's nothing to look at!");
                    indianaJones.isTextEnabled = true;
                }
            }
        }
        else if (actions.canOpen)
        {
            if (assignedItem != null)
            {
                actions.DoAction_Open(assignedItem);
                UpdateSprites(assignedItem);
            }
        }
        else if (actions.canClose)
        {
            if (assignedItem != null)
            {
                actions.DoAction_Close(assignedItem);
                UpdateSprites(assignedItem);
            }
        }
    }

    #endregion
}
