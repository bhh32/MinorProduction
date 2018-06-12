using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldItemUse : MonoBehaviour
{
    // Flag to hold if the player clicked the Left Mouse Button
    bool didClick;

    // The current Item that is trying to be used with this object
    Item currentItem;

    // The UIActionManager instance
    UIActionManager action;

    void Start()
    {
        // Set the variable to the instance
        action = UIActionManager.instance;
    }

    public void Update()
    {
        // Set if the player clicked the left mouse button or not
        didClick = Input.GetMouseButtonDown(0);

        // Cast a ray from the camera to the current mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Create a variable to hold the ray hit
        RaycastHit hit;

        // Check if the ray hit anything and if it did run the logic
        if (Physics.Raycast(ray, out hit, 100f))
        {
            // Check if this object is what was hit AND if didClick is true
            if (hit.collider.gameObject == gameObject && didClick)
            {   
                // If so check to see if the current action is use...
                if (action.canUse)
                {
                    // ... if it is check to see if an inventory item has been chosen to use
                    if (InventoryUseItem.instance.currentItem != null)
                    {
                        // ... if it has been use the item on this gameobject and set canUse to false
                        action.DoAction_Use(gameObject);

                        action.canUse = false;
                    }
                }
                // Check if the current action is LookAt...
                else if (action.canLookAt)
                    // ... if it is, Look at this gameObject
                    action.DoAction_LookAt(null, didClick);
                // Check if the current action is Push...
                else if (action.canPush)
                    // ... if it is Push this object if you can...
                    action.DoAction_Push();
                // Check if the current action is Pull...
                else if (action.canPull)
                    // ... if it is Pull this object if you can...
                    action.DoAction_Pull();
                // Check if the current action is Open...
                else if (action.canOpen)
                    // ... if it is Open the object if you can...
                    action.DoAction_Open(currentItem);
                else if (action.canClose)
                    action.DoAction_Close(currentItem);
                else if (action.canTalkTo)
                    action.DoAction_TalkTo(hit.collider.gameObject);
            }
        }
    }  
}
