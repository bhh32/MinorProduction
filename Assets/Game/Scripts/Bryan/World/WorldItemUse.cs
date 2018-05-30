using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldItemUse : MonoBehaviour
{
    bool didClick;
    [SerializeField] Item currentItem;

    [SerializeField] GameObject originalGameObj;
    [SerializeField] GameObject modifiedGameObj;

    UIActionManager action;



    void Start()
    {
        action = UIActionManager.instance;
    }

    public void Update()
    {

        didClick = Input.GetMouseButtonDown(0);



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);

            if (hit.collider.gameObject == gameObject && didClick)
            {    
                if (action.canUse)
                {
                    if (InventoryUseItem.instance.currentItem != null && action.canUse)
                    {
                        action.DoAction_Use(gameObject);

                        action.canUse = false;
                    }
                }
                else if (action.canLookAt && didClick)
                    action.DoAction_LookAt(null, didClick);
                else if (action.canPush)
                    action.DoAction_Push();
                else if (action.canPull)
                    action.DoAction_Pull();
                else if (action.canOpen)
                    action.DoAction_Open(currentItem);
                
            }
        }
    }  
}
