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

    public void Use(GameObject clickedObj)
    {
        if (currentItem != null)
        {
            switch (currentItem.name)
            {
                case "Whip":
                    if (clickedObj.CompareTag("Jungle Rodent"))
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                        InventoryUIManager.instance.OnInventoryUpdate(currentItem);
                        currentItem = null;
                        Debug.Log("You used the whip with the jungle rodent!");
                        //TODO: Play Indy
                    }
                    else
                    {
                        Debug.Log("I can't use that with that");
                        currentItem = null;
                    }
                    break;
                case "Spiral Design":
                    if (clickedObj.CompareTag("Animal Head"))
                    {
                        // TODO: Change objectToUseItemWith mesh to "Animal Head w/Spiral Design"
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
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            currentItem = null;
                            Debug.Log("You used the kerosene lamp on the spiral design!");
                            // Do the pour animation
                        }
                        else
                        {
                            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                            InventoryUIManager.instance.OnInventoryUpdate(currentItem);
                            currentItem = null;
                            Debug.Log("I can't use this with that.");
                        }
                    }
                    else
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                        InventoryUIManager.instance.OnInventoryUpdate(currentItem);
                        currentItem = null;
                        if (clickedObj.CompareTag("Spiral Design"))
                            Debug.Log("It needs to be open before I use it.");
                        else
                            Debug.Log("I can't use this with that.");
                    }
                    break;
                default:
                    Debug.Log("I can't use that!");
                    InventoryUIManager.instance.OnInventoryUpdate(currentItem);
                    currentItem = null;
                    break;
            }
        }
        else
        {
            Debug.Log("You haven't selected an item to use.");
        }
    }

    public void SetCurrentItem(Item newItem)
    {
        currentItem = newItem;
    }
}
