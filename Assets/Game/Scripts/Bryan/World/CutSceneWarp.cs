using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutSceneWarp : MonoBehaviour 
{
    [SerializeField] NavMeshAgent realIndy;
    [SerializeField] Transform warpPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Indy Cut Scene Model"))
            realIndy.Warp(warpPosition.position);
    }
}
