using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjects : MonoBehaviour 
{
    [SerializeField] GameObject originalObj;
    [SerializeField] GameObject objToChangeTo;

    public void SwapObjects()
    {
        Debug.Log("Original Obj: " + originalObj.name);
        Debug.Log("Changed Obj: " + objToChangeTo.name);
        objToChangeTo.SetActive(true);
        originalObj.SetActive(false);
    }
}
