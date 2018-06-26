using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerPAC : MonoBehaviour
{
    [SerializeField] IndyAnimController animation;

    //Creating Instance for the player controller
    #region singleton
    public static PlayerControllerPAC instance;

    //setting instance
    void Awake()
    {
        instance = this;
    }
    #endregion

    //Player NavMesh
    [SerializeField] NavMeshAgent agent;
    //Players Rigidbody
    Rigidbody rb;

    public bool canTeleport = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Always updating to get the players current velocity
        Vector3 v3Velocity = rb.velocity;
        //checks to see if the players has stopped moving
        if (v3Velocity.x < 0.1f && v3Velocity.y < 0.1f && v3Velocity.z < 0.1f)
        {
            //if the player has stopped moving, update the animation controller
            animation.WalkAnim();
        }
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && UIActionManager.instance.canWalk)
    //    {
    //        //Gets Mouse position relitive to the world from the camera
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, 100))
    //            WalkToUI(hit.point);
    //    }
    //    else if (UIActionManager.instance.canWalk)
    //    {
    //        WalkToUI(transform.position);
    //    }
    //}

    // For use with Walk-To in the UI
    public void WalkToUI(Vector3 Destination)
    {
        agent.SetDestination(Destination);
        animation.WalkAnim();
    }
}