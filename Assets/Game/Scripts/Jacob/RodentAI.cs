using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RodentAI : MonoBehaviour
{

    #region singleton
    public static RodentAI instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

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

    // The waypoint where the rodent will run to when whipped in the correct spot.
    public GameObject whipWaypoint;

    // The current destination of the rodent;
    public GameObject currentWaypoint;

    // Was the rodent whipped?
    private bool wasWhipped = false;

    public bool WasWhipped
    {
        get { return wasWhipped; }
        set { wasWhipped = value; }
    }

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
        currentWaypoint = waypoints[0];

        SetNewDest(currentWaypoint.transform.position);
	}
	
	void Update ()
    {
        // Checks the distance between the Indy and the rodent
        currentDistance = Vector3.Distance(transform.position, indiana.transform.position);

        // Allows the rodent to run if it can and Indy is close enough
        if (currentDistance < runDistance && canRun || canRun && wasWhipped)
        {
            /* Set the flag to false so that it doesn't continally find a new waypoint to go to
               while Indy is less than the runDistance */
            canRun = false;
            wasWhipped = false;
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
            currentWaypoint = waypoints[1];

        else if (currentWaypoint == waypoints[1])
            currentWaypoint = waypoints[2];

        else if (currentWaypoint == waypoints[2])
            currentWaypoint = waypoints[0];

        // Set the new destination to the new current waypoint.
        SetNewDest(currentWaypoint.transform.position);
    }

    // Helper Method to set a new destination.
    public void SetNewDest(Vector3 newDest)
    {
        agent.SetDestination(newDest);
    }
}
