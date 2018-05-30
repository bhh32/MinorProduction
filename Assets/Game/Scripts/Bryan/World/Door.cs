using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Door", menuName = "World Items/Door")]
public class Door : Item 
{
    new public static string name = "Door";

    public override void GameObjUpdate(GameObject newOrigGameObj, GameObject newModGameObj, GameObject parent)
    {
        originalGameObject = newOrigGameObj;
        modifiedGameObject = newModGameObj;
        Vector3 openDoorPos = new Vector3(parent.transform.position.x - 1f, parent.transform.position.y, parent.transform.position.z);
        GameObject newClosedDoor = Instantiate(originalGameObject, parent.transform.position, Quaternion.identity) as GameObject;
        GameObject newOpenDoor = Instantiate(modifiedGameObject, openDoorPos, Quaternion.Euler(0f, 90f, 0f)) as GameObject;

        newClosedDoor.name = "Closed Door";
        newOpenDoor.name = "Open Door";

        newClosedDoor.SetActive(true);
        newOpenDoor.SetActive(false);
    }
}
