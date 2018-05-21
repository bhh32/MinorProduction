using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UIActionManager : MonoBehaviour 
{
	[SerializeField] GameObject actionSelectionCanvas;
	[SerializeField] Button[] inventorySlots;
	[SerializeField] bool isActionSelected;
	[SerializeField] bool canLookAt;
	[SerializeField] bool canWalk;
	[SerializeField] bool canUse;
	[SerializeField] bool canPickUp;

	void Awake()
	{
		actionSelectionCanvas.SetActive(false);
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonUp(1))
		{
			if (!actionSelectionCanvas.activeSelf)
			{
				actionSelectionCanvas.SetActive(true);
				if (canLookAt)
					canLookAt = false;
				if (canWalk)
					canWalk = false;
				if (canUse)
					canUse = false;
				if (canPickUp)
					canPickUp = false;
			}
			else
				actionSelectionCanvas.SetActive(false);
		}

		if (isActionSelected)
		{
			isActionSelected = false;
			actionSelectionCanvas.SetActive(false);
		}
	}

	public void SetAction_Walk()
	{
		canWalk = true;
		if (canLookAt)
			canLookAt = false;
		if (canUse)
			canUse = false;
		if (canPickUp)
			canPickUp = false;

		isActionSelected = true;

	}

	public void DoAction_Walk()
	{
		if (canWalk)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 100f /*insert ground layer here*/))
			{	// PlayerController.instance.WalkToUI(hit.point);
			}
		}
	}

	public void SetAction_PickUp(GameObject objToPickUp)
	{
		
	}

	public void SetAction_LookAt()
	{
		canLookAt = true;

		if (canWalk)
			canWalk = false;
		if (canUse)
			canUse = false;
		if (canPickUp)
			canPickUp = false;

		isActionSelected = true;
//		if (Input.GetMouseButtonDown(0))
//		{
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//
//			if (Physics.Raycast(ray, out hit, 100f))
//			{
//				switch (hit.collider.gameObject.tag)
//				{
//					case "Jungle Rodent":
//						Debug.Log("It's an oversized rodent!");
//						break;
//					case "Kerosene Lamp":
//						Debug.Log("It's a kerosene lamp! Seems to have a little bit of kerosene left.");
//						break;
//					default:
//						Debug.Log("You looked at something you weren't supposed to! Perv!");
//						break;
//				}
//			}
//		}
	}

	public void DoAction_LookAt()
	{
		if (canLookAt)
		{
		}
	}

	public void SetAction_Use()
	{
		canUse = true;

		if (canLookAt)
			canLookAt = false;
		if (canWalk)
			canWalk = false;
		if (canPickUp)
			canPickUp = false;

		isActionSelected = true;
		//TODO: This will couple with the inventory system maybe use a delegate?
	}

	public void DoAction_Use()
	{
		if (canUse)
		{
		}
	}
}
