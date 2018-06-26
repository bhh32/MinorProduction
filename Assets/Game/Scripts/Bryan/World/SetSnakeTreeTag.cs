using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSnakeTreeTag : MonoBehaviour 
{
    [SerializeField] GameObject snakeTree;

    void Awake()
    {
        if (snakeTree.name == "Snake Tree")
            snakeTree.name = "Cleared Tree";
    }
}
