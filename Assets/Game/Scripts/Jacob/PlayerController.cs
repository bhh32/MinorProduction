using System.Collections;
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
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = (horizontalMovement * transform.right
            + verticalMovement * transform.forward);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {

        transform.Translate(moveDirection.x * walkspeed * Time.deltaTime, 0f, 
            moveDirection.z * walkspeed * Time.deltaTime);
    }
}
