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
    public bool canOpen;
    public bool canClose { get; private set; }
    public bool canPush { get; private set; }
    public bool canPull { get; private set; }
    public bool canTalkTo { get; private set; }

    //[SerializeField] Text speechText;
    [SerializeField] CharacterTalkText charTalkText;
	
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

        if (isActionSelected && actionSelectionCanvas.activeSelf)
		{
			isActionSelected = false;
        }

        DoAction_Walk();
	}

    void LateUpdate()
    {
        if(Input.GetMouseButtonUp(0))
        {
            actionSelectionCanvas.SetActive(false);
        }
    }

    #region Walk Action Methods
    // Set the current action to walk
	public void SetAction_Walk()
	{
        ResetInventoryItem();

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

			if(Physics.Raycast(ray, out hit, 100f))
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
        ResetInventoryItem();

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
        ResetInventoryItem();

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
                            charTalkText.TextUpdate("It's an oversized rodent!");
                            charTalkText.isTextEnabled = true;
                            break;
                        case "Kerosene Lamp":
                            charTalkText.TextUpdate("It's a kerosene lamp! Seems to have a little bit of kerosene left.");
                            charTalkText.isTextEnabled = true;
                            break;
                        default:
                            charTalkText.TextUpdate("You looked at something you weren't supposed to! Perv!");
                            charTalkText.isTextEnabled = true;
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
                switch (hit.collider.gameObject.name)
                {
                    case "Jungle Rodent":
                        {
                            charTalkText.TextUpdate("It's an oversized rodent!");
                            charTalkText.isTextEnabled = true;
                        }
                        break;
                    case "Kerosene Lamp":
                        charTalkText.TextUpdate("It's a kerosene lamp! Seems to have a little bit of kerosene left.");
                        charTalkText.isTextEnabled = true;
                        break;
                    default:
                        charTalkText.TextUpdate("You looked at something you weren't supposed to! Perv!");
                        charTalkText.isTextEnabled = true;
                        break;
                }
            }
        }
        else if (canLookAt && clickedItem != null && didClick)
        {
            switch (clickedItem.name)
            {
                case "Whip":
                    charTalkText.TextUpdate("It's my whip!");
                    charTalkText.isTextEnabled = true;
                    break;
                case "Kerosene Lamp":
                    if (clickedItem.isOpen)
                    {
                        charTalkText.TextUpdate("It's an open kerosene lamp! Careful not to spill the kerosene!");
                        charTalkText.isTextEnabled = true;
                    }
                    else
                    {
                        charTalkText.TextUpdate("It's a kerosene lamp! Seem to have a little bit of kerosene left.");
                        charTalkText.isTextEnabled = true;
                    }
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

    public void DoAction_Use(GameObject thingObjUsedOn)
	{
        if (canUse)
        {
            if (InventoryUseItem.instance.currentItem != null)
            {
                InventoryUseItem.instance.Use(thingObjUsedOn);
            }
        }
        else
            Debug.Log("canUse is false!");
	}

    #endregion

    #region Open Methods

    public void SetAction_Open()
    {
        SetAllBools(false);
        canOpen = true;
        isActionSelected = true;
    }

    public void DoAction_Open(Item assignedItem)
    {
        if (canOpen && assignedItem.isOpenable)
        {            
            if (!assignedItem.isOpen)
                assignedItem.isOpen = true;
            else
            {
                charTalkText.TextUpdate("It's already open!");
                charTalkText.isTextEnabled = true;            
            }
        }
        else if (!assignedItem.isOpenable)
        {
            charTalkText.TextUpdate("I can't open that!");
            charTalkText.isTextEnabled = true;
        }

        canOpen = false;
    }

    #endregion

    #region Close Methods

    public void SetAction_Close()
    {
        SetAllBools(false);
        canClose = true;
        isActionSelected = true;
    }

    public void DoAction_Close(Item assignedItem)
    {
        if (canClose && assignedItem.isOpenable)
        {            
            if (assignedItem.isOpen)
                assignedItem.isOpen = false;
            else
            {
                charTalkText.TextUpdate("It's already closed!");
                charTalkText.isTextEnabled = true;
            }
        }
        else if (!assignedItem.isOpenable)
        {
            charTalkText.TextUpdate("I can't close that!");
            charTalkText.isTextEnabled = true;
        }

        canClose = false;
    }

    #endregion

    #region Push Methods

    public void SetAction_Push()
    {

    }

    public void DoAction_Push()
    {

    }

    #endregion

    #region Pull Methods

    public void SetAction_Pull()
    {
        SetAllBools(false);

        canPull = true;
        isActionSelected = true;
    }

    public void DoAction_Pull()
    {

    }

    #endregion

    #region TalkTo Methods

    public void SetAction_TalkTo()
    {
        SetAllBools(false);
        canTalkTo = true;
        isActionSelected = true;
    }

    public void DoAction_TalkTo()
    {
        // TODO: Start Dialog System

        canTalkTo = false;
    }

    #endregion

    #region Helper Methods

    void SetAllBools(bool newValue)
    {
        canUse = newValue;
        canLookAt = newValue;
        canPickUp = newValue;
        canWalk = newValue;
        canOpen = newValue;
        canClose = newValue;
        canPull = newValue;
        canPush = newValue;
        canTalkTo = newValue;
    }

    public bool AreAllBools(bool boolQuestion)
    {
        List<bool> allBools = new List<bool>();

        allBools.Add(canUse);
        allBools.Add(canLookAt);
        allBools.Add(canWalk);
        allBools.Add(canPickUp);
        allBools.Add(canOpen);
        allBools.Add(canClose);
        allBools.Add(canPull);
        allBools.Add(canPush);
        allBools.Add(canTalkTo);

        foreach (bool bools in allBools)
        {
            if (bools != boolQuestion)
                return false;
        }

        return true;
    }

    void ResetInventoryItem()
    {
        if (InventoryUseItem.instance.currentItem != null)
        {
            InventoryUIManager.instance.OnInventoryUpdate(InventoryUseItem.instance.currentItem);
            InventoryUseItem.instance.currentItem = null;
        }
    }

    #endregion
}
