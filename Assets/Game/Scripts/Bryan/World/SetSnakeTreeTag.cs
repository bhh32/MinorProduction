using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSnakeTreeTag : MonoBehaviour 
{
    [SerializeField] GameObject snakeProp;
    [SerializeField] GameObject snakeTree;

    void Update()
    {
        if (!snakeProp.activeInHierarchy)
        {
            if (snakeTree.name == "Snake Tree")
            {
                snakeTree.name = "Cleared Tree";
                gameObject.SetActive(false);
            }
        }
    }
}
