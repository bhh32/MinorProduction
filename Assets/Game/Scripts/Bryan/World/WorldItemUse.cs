using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldItemUse : MonoBehaviour
{
    bool didClick;
    public void Update()
    {

        didClick = Input.GetMouseButtonDown(0);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.gameObject == gameObject && didClick)
            {
                if (UIActionManager.instance.canUse)
                {
                    if (InventoryUseItem.instance.currentItem != null && UIActionManager.instance.canUse)
                    {
                        InventoryUseItem.instance.Use(gameObject);

                        UIActionManager.instance.canUse = false;
                    }
                }
                else if (UIActionManager.instance.canLookAt && didClick)
                {
                    UIActionManager.instance.DoAction_LookAt(null, didClick);
                }
            }
        }
    }  
}
