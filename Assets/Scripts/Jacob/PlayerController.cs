using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    //Player NavMesh
    private NavMeshAgent agent;

    //Gets NavMesh
	void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
	
	
	void Update () {
        if (Input.GetMouseButtonDown(0)){

            //Gets Mouse position relitive to the world from the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
	}
}
