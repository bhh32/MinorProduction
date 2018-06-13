using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationTest : MonoBehaviour 
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            transform.Rotate(0f, 90f, 0f);
        else if (Input.GetKeyDown(KeyCode.D))
            transform.Rotate(0f, 180f, 0f);
    }
}
