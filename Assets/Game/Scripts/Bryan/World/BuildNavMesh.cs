using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class BuildNavMesh : MonoBehaviour 
{
    
    void Awake()
    {
        NavMeshBuilder.BuildNavMesh();
    }
}
