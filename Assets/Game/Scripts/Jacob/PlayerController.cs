﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    //Creating Instance for the player controller
    #region singleton
    public static PlayerController instance;

    //setting instance
    void Awake()
    {
        instance = this;
    }
    #endregion

    public float walkspeed;
    Vector3 moveDirection;

    public bool canTeleport = true;
	
	void Update ()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * walkspeed * Time.deltaTime;
        float verticalMovement = Input.GetAxisRaw("Vertical") * walkspeed * Time.deltaTime;

        moveDirection = new Vector3(horizontalMovement, 0.0f, verticalMovement );
    }

    void FixedUpdate()
    {
        Rotate();
        Move();
    }

    void Move()
    {
        transform.Translate(moveDirection, Space.World);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}
