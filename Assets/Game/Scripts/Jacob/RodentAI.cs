using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RodentAI : MonoBehaviour
{
    //Player
    public GameObject indiana;
    
    [Tooltip("How close Indy can get to the Jungle Rodent")]
    public float runDistance;
    
    // The current distance between the rodent and Indy.
    float currentDistance;

    // The jungle rodent's NavMeshAgent.
    NavMeshAgent agent;

    // The available waypoints the rodent can run to.
    public GameObject[] waypoints;

    // The current destination of the rodent;
    GameObject currentWaypoint;

    GameObject lastWaypoint;

    // Flag for if the rodent can run or not.
    [SerializeField] bool canRun = true;

    // Allows for teleportation without the rodent getting in a teleport loop.
    private bool canTeleport;
    public bool CanTeleport
    {
        get { return canTeleport; }
        set { canTeleport = value; }
    }

	void Start ()
    {
        // Allow the rodent to be able to run straight away.
        canTeleport = true;

        //Sets the variable to the rodent's NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Sets a point for the rodent to go to right away.
        FindNewPoint();
        lastWaypoint = currentWaypoint;
	}
	
	void Update ()
    {
        // Checks the distance between the Indy and the rodent
        currentDistance = Vector3.Distance(transform.position, indiana.transform.position);

        // Allows the rodent to run if it can and Indy is close enough
        if (currentDistance < runDistance && canRun)
        {
            /* Set the flag to false so that it doesn't continally find a new waypoint to go to
               while Indy is less than the runDistance */
            canRun = false;

            // Look for a new waypoint to go to.
            FindNewPoint();
        }

        // If Indy is out of range reset the flag to true.
        if (currentDistance > runDistance)
            canRun = true;
	}

    void FindNewPoint()
    {

        if (currentWaypoint == waypoints[0])
            SetNewDest(waypoints[1].transform.position);

        else if (currentWaypoint == waypoints[1])
            SetNewDest(waypoints[2].transform.position);

        else if (currentWaypoint == waypoints[2])
            SetNewDest(waypoints[3].transform.position);

        else if (currentWaypoint == waypoints[3])
            SetNewDest(waypoints[4].transform.position);

        else if (currentWaypoint == waypoints[4])
            SetNewDest(waypoints[5].transform.position);

        else if (currentWaypoint == waypoints[5])
            SetNewDest(waypoints[0].transform.position);


        // Use a for loop to loop through the waypoints...
        //for(int i = 0; i < waypoints.Length; ++i)
        //{
        //    // ... if the current waypoint is waypoint[i]...
        //    if (waypoints[i] == currentWaypoint)
        //    {
        //        // ... make a temp int variable to hold the index above this one...
        //        int pointIdx = i + 1;

        //        // ... if that index is too big, loop back to index 0...
        //        if (pointIdx == waypoints.Length - 1)
        //            pointIdx = 0;

        //        // ... set the currentWaypoint to the new waypoint and break out of the loop.
        //        currentWaypoint = waypoints[pointIdx];
        //        break;
        //    }
        //    else if (waypoints[i] == lastWaypoint)
        //    {
        //        int pointIdx = i - 1;

        //        if (pointIdx < 0)
        //            pointIdx = waypoints.Length - 1;

        //        currentWaypoint = waypoints[pointIdx];
        //    }
        //    // ... otherwise, set the currentWaypoint to waypoints[i] and break out of the loop.
        //    else
        //    {
        //        currentWaypoint = waypoints[i];
        //        break;
        //    }
        //}

        lastWaypoint = currentWaypoint;

        // Set the new destination to the new current waypoint.
        SetNewDest(currentWaypoint.transform.position);
    }

    // Helper Method to set a new destination.
    public void SetNewDest(Vector3 newDest)
    {
        agent.SetDestination(newDest);
    }
}
