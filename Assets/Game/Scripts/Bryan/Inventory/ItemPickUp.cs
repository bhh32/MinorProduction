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
                    UIActionManager.instance.DoAction_Pickup(item);
                    Destroy(gameObject);
                }
            }
        }
    }
}
