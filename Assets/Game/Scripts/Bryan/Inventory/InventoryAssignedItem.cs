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

    bool didClick = false;

    public void UpdateSprites(Item newItem)
    {
        if (newItem == null)
            assignedItem = null;
        else
            assignedItem = newItem;

        Button thisSlot = GetComponent<Button>();

        if (assignedItem != null)
        {
            itemDefaultSprite = assignedItem.icon;
            itemHighlightedSprite = assignedItem.highlightedIcon;

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

        if (thisSlot.sprite == itemHighlightedSprite)
            thisSlot.sprite = itemDefaultSprite;
        else
            thisSlot.sprite = emptySlotSprite;
    }

    #endregion

    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        didClick = true;
        Image thisSlot = GetComponent<Image>();
        UIActionManager actions = UIActionManager.instance;

        if (actions.canUse && assignedItem != null)
        {
            switch (assignedItem.name)
            {
                case "Whip":
                    Cursor.SetCursor(whipCursor, Vector2.zero, CursorMode.Auto);
                    InventoryUseItem.instance.currentItem = assignedItem;
                    break;

                default:
                    Debug.LogError("Something in switching the cursor went wrong!" + assignedItem);
                    break;
            }

            assignedItem = null;

            itemDefaultSprite = null;
            itemHighlightedSprite = null;

            thisSlot.sprite = emptySlotSprite;
        }
        else if (actions.canLookAt)
        {
            if (assignedItem != null)
            {
                UIActionManager.instance.DoAction_LookAt(assignedItem, didClick);
            }
            else
            {
                if (InventoryUseItem.instance.currentItem != null)
                {
                    InventoryUIManager.instance.OnInventoryUpdate(InventoryUseItem.instance.currentItem);
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                }
                else
                    Debug.Log("There's nothing there!");
            }
        }
    }

    #endregion
}
