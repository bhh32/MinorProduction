using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RodentAI : MonoBehaviour {

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
        agent = GetComponent<NavMeshAgent>();
	}
	

	void Update () {
        currentDistance = Vector3.Distance(transform.position, indiana.transform.position);
        if (currentDistance <= runDistance)
        {
            MoveToPoint();
        }
	}

    void MoveToPoint()
    {
        if (transform.position != waypoints[currentPoint].transform.position)
        {
            agent.SetDestination(waypoints[currentPoint].position);
        }
        
        if (transform.position == waypoints[currentPoint].transform.position && transform.position.y <= 1)
        {
            currentPoint += 1;
        }

        if (currentPoint >= waypoints.Length)
        {
            currentPoint = 0;
        }
    }
}
