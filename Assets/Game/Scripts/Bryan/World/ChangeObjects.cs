using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjects : MonoBehaviour 
{
    [SerializeField] GameObject originalObj;
    [SerializeField] GameObject objToChangeTo;
    [SerializeField] TombDoorAnim tombAnim;

    public void SwapObjects()
    {
        objToChangeTo.SetActive(true);
        originalObj.SetActive(false);

        tombAnim.OnTombUpdate();
    }
}
