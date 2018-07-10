using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour 
{
    [SerializeField] Item item;
    public Item Item
    {
        get{ return item; }
        private set{ item = value; }
    }

    [SerializeField] InventoryUIManager inventoryUIMan;
    [SerializeField] CharacterTalkText indy;

    void Awake()
    {
        if (item.isOpenable)
        {
            if (item.isOpen)
                item.isOpen = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && UIActionManager.instance.canPickUp)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    switch (item.name)
                    {
                        case "Spiral Design":
                            if (GetInventoryItem("Kerosene Lamp") != null)
                            {
                                if (GetInventoryItem("Kerosene Lamp").hasBeenUsed)
                                {
                                    // Do use animation.
                                    UIActionManager.instance.DoAction_Pickup(item);
                                    Destroy(gameObject);
                                }
                                else
                                {
                                    indy.TextUpdate("I need something to eat the tarnish to loosen it first.");
                                    indy.isTextEnabled = true;
                                }
                            }
                            else
                            {
                                indy.TextUpdate("I need something to eat the tarnish to loosen it first.");
                                indy.isTextEnabled = true;
                            }
                            break;
                        case "Kerosene Lamp":
                            if (DialogSystemManager.instance.isOccupied)
                            {
                                UIActionManager.instance.DoAction_Pickup(item);
                                Destroy(gameObject);
                            }
                            else
                            {
                                indy.TextUpdate("I can't steal it! Well... unless I need to...");
                                indy.isTextEnabled = true;
                            }
                            break;
                        default:
                            
                            break;
                    }
                }
            }
        }
    }

    #region Helper Methods

    Item GetInventoryItem(string itemToRetrieve)
    {
        Item item = null;

        foreach (Button slot in InventoryUIManager.instance.inventorySlots)
        {
            var newGottenItem = slot.GetComponent<InventoryAssignedItem>();
            if (newGottenItem.assignedItem != null)
            {
                if (newGottenItem.assignedItem.name == itemToRetrieve)
                {
                    item = newGottenItem.assignedItem;
                    break;
                }
            }
        }

        return item;
    }

    #endregion
}
