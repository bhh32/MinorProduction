using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour 
{
    #region Delegate
    public delegate void UpdateInventorySlot(Item item);
    public UpdateInventorySlot OnInventoryUpdate;
    #endregion

    #region Variables
    public List<Button> inventorySlots = new List<Button>();
    [SerializeField] List<Image> inventoryImages = new List<Image>();
    [SerializeField] Sprite defaultSprite;

    [Header("Iventory Toggle")]
    [SerializeField] Toggle inventoryToggle;
    #endregion

    #region Singleton
    public static InventoryUIManager instance;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < inventorySlots.Count; ++i)
        {
            if (!inventoryImages.Contains(inventorySlots[i].GetComponent<Image>()))
                inventoryImages.Add(inventorySlots[i].GetComponent<Image>());
        }

        OnInventoryUpdate += UpdateSprite;
    }
    #endregion

    void UpdateSprite(Item item)
    {
        foreach (Image image in inventoryImages)
        {
            if (image.sprite == defaultSprite || image.sprite == null)
            {
                var inventorySlot = image.GetComponent<InventoryAssignedItem>();

                inventorySlot.assignedItem = item;
                inventorySlot.UpdateSprites(inventorySlot.assignedItem);

                break;
            }
            else if (image.sprite == item.icon || image.sprite == item.openedIcon)
                break;
        }
    }
}
