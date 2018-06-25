using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanFollow : MonoBehaviour {

    #region singleton
    public static HumanFollow instance;

    private void Awake()
    {
        instance = this;
    }
#endregion

    //Player
    public GameObject indiana;

    //The game objects NavMeshAgent
    NavMeshAgent agent;

    //Distance between charictor and indi
    float currentDistance;

    //The maximum distance indi can be away from this charictor
    public float maxDistance;

    //Is the charictor currently following indi
    public bool isFollowing = false;
    public bool IsFollowing
    {
        get { return isFollowing; }
        set
        {
            isFollowing = value;
        }
    }

	void Start () {
        //Sets the NavMesh
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
        //Gets the current distance between the charictor and indi
        currentDistance = Vector3.Distance(transform.position, indiana.transform.position);

        //checks to see if the charictor should follow
		if (isFollowing && currentDistance > maxDistance)
        {
            //Calls helper function
            SetNewDest(indiana.transform.position);
        }
	}

    //Helper function for setting new destinations
    public void SetNewDest(Vector3 newDest)
    {
        agent.SetDestination(newDest);
    }
}
