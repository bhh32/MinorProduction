using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    Debug.Log(hit.collider.gameObject.name);
                    switch (item.name)
                    {
                        case "Spiral Design":
                            if (item.isUsable)
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
                            break;
                        case "Kerosene Lamp":
                            if (item.isUsable)
                            {
                                UIActionManager.instance.DoAction_Pickup(item);
                                Destroy(gameObject);
                            }
                            else
                            {
                                // Do Sternhart Animation to interrupt indy from picking up the lamp.
                                Debug.Log("Sternhart comes out to stop Indy from taking lamp.");
                            }
                            break;
                        default:
                            
                            break;
                    }
                }
            }
        }
    }
}
