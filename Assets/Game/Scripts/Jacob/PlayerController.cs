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

    //Player NavMesh
    private static NavMeshAgent agent;

    public bool canTeleport = true;

    //Gets NavMesh
	void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && UIActionManager.instance.canWalk)
        {
            //Gets Mouse position relitive to the world from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100))
                WalkToUI(hit.point);
        }
        else if (UIActionManager.instance.canWalk)
        {
            WalkToUI(transform.position);
        }
    }

    // For use with Walk-To in the UI
    public void WalkToUI(Vector3 Destination)
    {
        agent.SetDestination(Destination);
    }
}
