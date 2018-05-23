using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RodentAI : MonoBehaviour {

    //--------------------------------------------------------------//
    //Known bugs:
    //-Unless the Rodent hits the "currentPoint" at the exact same time as the teleporter
    // the rodent will continue to try and go back to the waypoint(which will be placed at the teleport 
    // entrence.
    //--------------------------------------------------------------//

    //Player
    public GameObject indiana;
    //How close indi has to be before the rodent runs away
    public float runDistance;
    //How far away indi is currently
    float currentDistance;
    //NavMeshAgent storage
    NavMeshAgent agent;

    //Where the rodent will run to
    public Transform[] waypoints;
    //Where the rodent is currently
    public int currentPoint = 0;

	
	void Start () {
        //grabs the NavMesh for the rodent
        agent = GetComponent<NavMeshAgent>();
	}
	

	void Update () {
        //Checks the distance between the player(Indi) and the rodent
        currentDistance = Vector3.Distance(transform.position, indiana.transform.position);
        //Checks if Indi is too close
        if (currentDistance <= runDistance)
        {
            //Tells the rodent to go to the next point
            MoveToPoint();
        }
	}

    void MoveToPoint()
    {
        //first if statement tells the rodent where to go
        if (transform.position != waypoints[currentPoint].transform.position)
        {
            agent.SetDestination(waypoints[currentPoint].position);
        }
        //second if statement checks if the rodent is at the point yet (the problem lies here, the 
        // requirement to move on is too demanding)
        if (transform.position == waypoints[currentPoint].transform.position && transform.position.y <= 1)
        {
            currentPoint += 1;
        }
        //last if statement checks if the rodent is at the last waypoint and to go back to the first one on
        // its next movenemt
        if (currentPoint >= waypoints.Length)
        {
            currentPoint = 0;
        }
    }
}
