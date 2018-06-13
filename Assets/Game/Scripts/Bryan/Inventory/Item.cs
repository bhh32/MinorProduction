using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Name of Item")]
    new public string name = "Item";

    [Header("Inventory Sprites")]
    public Sprite icon = null;
    public Sprite highlightedIcon = null;
    [Tooltip("Only use if item is able to be opened.")] 
    public Sprite openedIcon = null;
    [Tooltip("Only use if item is able to be opened.")] 
    public Sprite openedHiglightedIcon = null;

    [Header("World GameObjects")]
    [Tooltip("Only use if modifiable in the world.")]
    public GameObject originalGameObject;
    [Tooltip("Only use if modifiable in the world.")]
    public GameObject modifiedGameObject;

    [Header("Action Flags")]
    public bool isOpen = false;
    public bool isOpenable = false;
    public bool isPullable = false;
    public bool hasBeenPulled = false;
    public bool isPushable = false;
    public bool hasBeenPushed = false;
    public bool isUsable = false;
    public bool hasBeenUsed = false;

    public virtual void GameObjUpdate(GameObject newOrigGameObj, GameObject newModGameObj, GameObject parent)
    {}
}
