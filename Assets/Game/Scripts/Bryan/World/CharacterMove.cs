using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour 
{
    public Transform player;
    public Camera mainCamera;
    public GameObject camMovePoint;

    void Update()
    {
        Vector3 playerScreenPos = mainCamera.WorldToScreenPoint(player.position);
        if (playerScreenPos.x >= Screen.width - 5f)
            mainCamera.transform.position = camMovePoint.transform.position;
    }
}
