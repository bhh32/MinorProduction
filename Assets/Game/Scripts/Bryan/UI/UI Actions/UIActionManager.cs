using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UIActionManager : MonoBehaviour 
{
    #region Singleton

    public static UIActionManager instance;

    void Awake()
    {
        instance = this;
        actionSelectionCanvas.SetActive(false);
    }

    #endregion

    #region Variables
    [Header("UI Actions")]
	[SerializeField] GameObject actionSelectionCanvas;
    [SerializeField] GameObject actionSelectionButtons;
    [SerializeField] bool isActionSelected;
    public bool canLookAt { get; private set;}
    public bool canWalk { get; private set; }
    public bool canUse;
    public bool canPickUp { get; private set; }	
	
    #endregion

	void Update () 
	{
        Vector3 clickPosition = Input.mousePosition;
    
		if (Input.GetMouseButtonUp(1))
		{
            if(actionSelectionButtons.transform.position != clickPosition)
                actionSelectionButtons.transform.position = clickPosition;
            
            if (!actionSelectionCanvas.activeSelf)
            {
                actionSelectionCanvas.SetActive(true);
            }
            else
            {
                actionSelectionCanvas.SetActive(false);
                canWalk = true;
            }
		}

        if (isActionSelected || Input.GetMouseButtonUp(0) && actionSelectionCanvas.activeSelf)
		{
			isActionSelected = false;
			actionSelectionCanvas.SetActive(false);
		}

        DoAction_Walk();
	}

    #region Walk Action Methods
    // Set the current action to walk
	public void SetAction_Walk()
	{
        SetAllBools(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		canWalk = true;
		isActionSelected = true;
	}

    // Do the walk action
	public void DoAction_Walk()
	{
        if (canWalk && Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 100f /*insert ground layer here*/))
			{	
                PlayerController.instance.WalkToUI(hit.point);
			}

            canWalk = false;
		}
	}
    #endregion

    #region PickUp Action Methods
    // Set current action to pickup an object
	public void SetAction_PickUp()
	{
        SetAllBools(false);
        canPickUp = true;
        isActionSelected = true;
	}

    public void DoAction_Pickup(Item itemToPickup)
    {
        if (canPickUp)
        {
            InventoryUIManager.instance.OnInventoryUpdate(itemToPickup);
            canPickUp = false;
        }
    }

    #endregion

    #region LookAt Action Methods

	public void SetAction_LookAt()
	{
        SetAllBools(false);
		canLookAt = true;
		isActionSelected = true;
	}

    public void DoAction_LookAt()
	{
		if (canLookAt)
		{
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
            
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Jungle Rodent":
                            Debug.Log("It's an oversized rodent!");
                            break;
                        case "Kerosene Lamp":
                            Debug.Log("It's a kerosene lamp! Seems to have a little bit of kerosene left.");
                            break;
                        default:
                            Debug.Log("You looked at something you weren't supposed to! Perv!");
                            break;
                      }
                  }
              }

              canLookAt = false;
		  }
	}

    public void DoAction_LookAt(Item clickedItem, bool didClick)
    {
        if (canLookAt && clickedItem == null && didClick)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Jungle Rodent":
                        Debug.Log("It's an oversized rodent!");
                        break;
                    case "Kerosene Lamp":
                        Debug.Log("It's a kerosene lamp! Seems to have a little bit of kerosene left.");
                        break;
                    default:
                        Debug.Log("You looked at something you weren't supposed to! Perv!");
                        break;
                }
            }
        }
        else if (canLookAt && clickedItem != null && didClick)
        {
            switch (clickedItem.name)
            {
                case "Whip":
                    Debug.Log("It's my whip!");
                    break;
                default:
                    break;
            }
        }

        canLookAt = false;
     }

    #endregion

    #region Use Action Methods

	public void SetAction_Use()
	{
        SetAllBools(false);
		canUse = true;
		isActionSelected = true;

		//TODO: This will couple with the inventory system maybe use a delegate?
	}

	public void DoAction_Use()
	{
        if (canUse)
        {
            if (InventoryUseItem.instance.currentItem != null)
            {
                switch(InventoryUseItem.instance.currentItem.name)
                {
                    case "Whip":
                        DoAction_Pickup(InventoryUseItem.instance.currentItem);
                        break;
                    default:
                        canUse = false;
                        break;
                }
            }
        }
	}

    #endregion

    #region Helper Methods

    void SetAllBools(bool newValue)
    {
        canUse = newValue;
        canLookAt = newValue;
        canPickUp = newValue;
        canWalk = newValue;
    }

    public bool AreAllBools(bool boolQuestion)
    {
        List<bool> allBools = new List<bool>();

        allBools.Add(canUse);
        allBools.Add(canLookAt);
        allBools.Add(canWalk);
        allBools.Add(canPickUp);

        foreach (bool bools in allBools)
        {
            if (bools != boolQuestion)
                return false;
        }

        return true;
    }

    #endregion
}
