using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIActionManager : MonoBehaviour 
{
    #region Singleton

    public static UIActionManager instance;

    void Awake()
    {
        instance = this;
        actionSelectionCanvas.SetActive(false);
        canWalk = true;
    }

    #endregion

    #region Variables
    [Header("UI Actions")]
	[SerializeField] GameObject actionSelectionCanvas;
    [SerializeField] GameObject actionSelectionButtons;
    [SerializeField] bool isActionSelected;
    public bool canLookAt { get; private set;}
    public bool canWalk;
    public bool canUse;
    public bool canPickUp { get; private set; }
    public bool canOpen;
    public bool canClose { get; private set; }
    public bool canPush { get; private set; }
    public bool canPull { get; private set; }
    public bool canTalkTo { get; private set; }

    //[SerializeField] Text speechText;
    [SerializeField] CharacterTalkText charTalkText;
     public bool isTalking = false;
    [SerializeField] IndyAnimController indyAnim;
    [SerializeField] GameObject currentSelectedCharacter;

    [Header("Animal Head Object Change Script")]
    [SerializeField] ChangeObjects animalHeads;

    [Header("Snake Prop")]
    [SerializeField] GameObject snakeProp;
	
    #endregion

	void Update () 
	{
        // If the dialog system isn't on AND canWalk is true...
        if (!isTalking && canWalk)
        {
            // ... get the mouse position...
            Vector3 clickPosition = Input.mousePosition;

            // ... check if the right mouse button was clicked...
            if (Input.GetMouseButtonUp(1))
            {
                // Check what position the button was clicked and position the actionSelectionButtons at that position
                if (actionSelectionButtons.transform.position != clickPosition)
                    actionSelectionButtons.transform.position = clickPosition;

                // Check to see if the actionSelectionCanvas is active...
                if (!actionSelectionCanvas.activeSelf)
                {
                    // ... if it's not, activate it and set canWalk to false
                    actionSelectionCanvas.SetActive(true);
                    canWalk = false;
                }
                // ... otherwise, set the actionSelectionCanvas inactive, and set canWalk to true.
                else
                {
                    actionSelectionCanvas.SetActive(false);
                    canWalk = true;
                }
            }

            // Check to see if an action was selected and if the actionSelectionCanvas is active...
            if (isActionSelected && actionSelectionCanvas.activeSelf) 
                isActionSelected = false; // ... if both are true, set the action selection to false.

            // Finally, do the walk action.
            DoAction_Walk();
        }

        #region Default Walk
        // If the actionSelectionCanvas is off, and All of the action bools are false...
        if (!actionSelectionCanvas.activeInHierarchy && AreAllBools(false))
            canWalk = true; // Set canWalk = true...
        // If the actionSelectionCanvas is off, and ONE of the action bools is true AND the right mouse button is clicked...
        else if (!actionSelectionCanvas.activeInHierarchy && !AreAllBools(false) && Input.GetMouseButtonUp(1))
        {
            // Set all the action bools to false
            SetAllBools(false);
            // And open the actionSelectionCanvas
            actionSelectionCanvas.SetActive(true);
        }
        #endregion
	}

    void LateUpdate()
    {
        // Check to see if the left mouse button was clicked...
        if (Input.GetMouseButtonUp(0))
        {
            // ... if it was turn off the action selection canvas...
            actionSelectionCanvas.SetActive(false);

            // ... then, check if all of the action bools are false...
            if (AreAllBools(false))
                canWalk = true; // ... if they are set canWalk to true.
        }
    }

    #region Walk Action Methods

    // Set the current action to walk
	public void SetAction_Walk()
	{
        // Reset the inventory item
        ResetInventoryItem();

        // Set all the action bools to false
        SetAllBools(false);
        // Set the cursor back to the default cursor
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        // Set canWalk to true
		canWalk = true;

        // Set that an action was selected.
		isActionSelected = true;
	}

    // Do the walk action
	public void DoAction_Walk()
	{
        // If the pointer is over a UI element return out of this method
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        // Check if canWalk is true and the left mouse button was clicked
        if (canWalk && Input.GetMouseButtonDown(0))
		{
            // Send a ray from the camera to the mouse position
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// Create a RaycastHit
            RaycastHit hit;

            // Walk to the ray hit point
            if (Physics.Raycast(ray, out hit, 100f))
            {	
                PlayerControllerPAC.instance.WalkToUI(hit.point);
            }

            // Set canWalk to false
            canWalk = false;
		}
	}

    #endregion

    #region PickUp Action Methods

    // Set current action to pickup an object
	public void SetAction_PickUp()
	{
        // Reset the inventory item
        ResetInventoryItem();

        // Set all the action bools to false
        SetAllBools(false);
        // Set canPickUp to true
        canPickUp = true;
        // Set that an action was selected
        isActionSelected = true;
	}

    public void DoAction_Pickup(Item itemToPickup)
    {
        // Check if you can pick something up
        if (canPickUp)
        {
            // Call the Inventory Update delegate
            InventoryUIManager.instance.OnInventoryUpdate(itemToPickup);
            // Set canPickUp to false
            canPickUp = false;
        }
    }

    #endregion

    #region LookAt Action Methods

	public void SetAction_LookAt()
	{
        // Reset the inventory item
        ResetInventoryItem();

        // Set all of the action bools to false
        SetAllBools(false);
        // Set canLookAt to true
		canLookAt = true;
        // Set that an action has been selected
		isActionSelected = true;
	}

    // Used for looking at items in the world
    public void DoAction_LookAt()
	{
        // Check if we can look at something
		if (canLookAt)
		{
            // Check if the left mouse button was clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Set a ray from the camera to the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit; // Create a RaycastHit for ray information

                if (Physics.Raycast(ray, out hit, 100f))
                {
                    // Check what was hit and do the appropriate action based on the information
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
                        case "Jeep":
                            charTalkText.TextUpdate("It's our jeep!");
                            charTalkText.isTextEnabled = true;
                            break;
                        case "Torch":
                            charTalkText.TextUpdate("It's a lit torch, don't touch it!");
                            charTalkText.isTextEnabled = true;
                            break;
                        case "Sophia":
                            charTalkText.TextUpdate("It's Sophia.");
                            charTalkText.isTextEnabled = true;
                            break;
                        case "Sternhart":
                            charTalkText.TextUpdate("It's Dr. Sternhart.");
                            charTalkText.isTextEnabled = true;
                            break;
                        case "Parrot":
                            charTalkText.TextUpdate("It's a parrot.");
                            charTalkText.isTextEnabled = true;
                            break;
                        default:
                            charTalkText.TextUpdate("You looked at something you weren't supposed to! Perv!");
                            charTalkText.isTextEnabled = true;
                            break;
                      }
                  }
              }
              
              // Set canLookAt to false  
              canLookAt = false;
		  }
	}

    // Used for looking at items in the inventory and in the world that have no usable items attached to them
    public void DoAction_LookAt(Item clickedItem, bool didClick)
    {
        // Check if the player can look at something, there is no item clicked, and if the player did click
        if (canLookAt && clickedItem == null && didClick)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If it's a world item
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Do the appropriate action based on the object
                switch (hit.collider.gameObject.name)
                {
                    case "Jungle Rodent":
                        charTalkText.TextUpdate("It's an oversized rodent!");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Snake Tree":
                        charTalkText.TextUpdate("Ugh! I hate snakes!");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Cleared Tree":
                        charTalkText.TextUpdate("I might could make a bridge.");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Kerosene Lamp":
                        charTalkText.TextUpdate("It's a kerosene lamp! Seems to have a little bit of kerosene left.");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Spiral Design":
                        charTalkText.TextUpdate("It's a sprial design. I need something to eat the tarnish to pick it up.");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Jeep":
                        charTalkText.TextUpdate("It's our jeep!");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Torch":
                        charTalkText.TextUpdate("It's a lit torch, don't touch it!");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Sophia":
                        charTalkText.TextUpdate("It's Sophia.");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Sternhart":
                        charTalkText.TextUpdate("It's Dr. Sternhart.");
                        charTalkText.isTextEnabled = true;
                        break;
                    case "Parrot":
                        charTalkText.TextUpdate("It's a parrot.");
                        charTalkText.isTextEnabled = true;
                        break;
                    default:
                        charTalkText.TextUpdate("You looked at something you weren't supposed to! Perv!");
                        charTalkText.isTextEnabled = true;
                        break;
                }
            }
        }
        // If it's an inventory item
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
                case "Spiral Design":
                    charTalkText.TextUpdate("It looks like an elephant trunk!");
                    charTalkText.isTextEnabled = true;
                    break;
                case "Plato's Lost Dialog":
                    charTalkText.TextUpdate("It's a section of Plato's Lost Dialog.");
                    charTalkText.isTextEnabled = true;
                    break;
                default:
                    break;
            }
        }

        // Set canLookAt to false
        canLookAt = false;
     }

    #endregion

    #region Use Action Methods

	public void SetAction_Use()
	{
        SetAllBools(false);
		canUse = true;
		isActionSelected = true;
	}

    public void DoAction_Use(GameObject thingObjUsedOn)
	{
        if (canUse)
        {
            if (InventoryUseItem.instance.currentItem != null)
            {
                InventoryUseItem.instance.Use(thingObjUsedOn);
                canUse = false;
            }
        }
	}

    // Specific to use the snake tree when the rodent has been eaten
    public void UseSnakeTree()
    {
        if (!snakeProp.activeSelf)
        {
            UIActionManager.instance.canWalk = false;
            // charTalkText.gameObject.SetActive(false);
            charTalkText.GetComponent<NavMeshAgent>().Warp(new Vector3(24.07f, 18.91f, -7.95f));
            // Trigger Cut Scene
        }
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
        SetAllBools(false);
        canPush = true;
        isActionSelected = true;
    }

    public void DoAction_Push()
    {
        charTalkText.TextUpdate("I can't push that!");
        charTalkText.isTextEnabled = true;
        canPush = false;
    }

    #endregion

    #region Pull Methods

    public void SetAction_Pull()
    {
        SetAllBools(false);

        canPull = true;
        isActionSelected = true;
    }

    public void DoAction_Pull(GameObject clickedObj)
    {
        if (clickedObj.name == "Animal Head w/Spiral Down")
        {
            indyAnim.PullAnim();
            animalHeads.SwapObjects();
        }
        else
        {
            charTalkText.TextUpdate("I can't pull that!");
            charTalkText.isTextEnabled = true;
            canPull = false;
        }
    }

    #endregion

    #region TalkTo Methods

    public void SetAction_TalkTo()
    {
        SetAllBools(false);
        canTalkTo = true;
        isActionSelected = true;
    }

    public void DoAction_TalkTo(GameObject clickedCharacter)
    {
        switch (clickedCharacter.name)
        {
            case "Sternhart":
                DialogSystemManager.instance.DisableOtherUI();
                break;
            case "Parrot":
                DialogSystemManager.instance.UpdateToParrotChoices();
                DialogSystemManager.instance.DisableOtherUI();
                break;
            case "Sophia":
                if (DialogSystemManager.instance.isSecondComplete)
                {
                    DialogSystemManager.instance.UpdateToThirdPuzzleChoices();
                    DialogSystemManager.instance.DisableOtherUI();
                }
                else
                {
                    DialogSystemManager.instance.UpdateToDefaultSophiaChoices();
                    DialogSystemManager.instance.DisableOtherUI();

                }                    
                break;
            default:
                Debug.LogError("Something went wrong with talking!");
                break;
        }

        canTalkTo = false;
    }

    #endregion

    #region Helper Methods

    // Sets all of the action bools to the newValue
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

    // Returns true if all of the action bools are the same as the boolQuestion
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

        int count = 0;

        foreach (bool bools in allBools)
        {
            if (bools != boolQuestion)
                return false;
        }

        return true;
    }

    // Resets the inventory item to the inventory and the currentItem to null
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
