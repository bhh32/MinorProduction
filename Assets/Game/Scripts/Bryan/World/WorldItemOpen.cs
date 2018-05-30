using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorldItemOpen : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Item currentItem;

    [SerializeField] GameObject originalObj;
    [SerializeField] GameObject modifiedObj;
    UIActionManager action;

    void Awake()
    {
        currentItem.GameObjUpdate(originalObj, modifiedObj, gameObject);
    }

    public void Open()
    {        
        action.DoAction_Open(currentItem, gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Open();
    }
}
