using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldItemToolTip : MonoBehaviour 
{
    [SerializeField] TMP_Text toolTip;

    Vector3 offset;
    RaycastHit hit;

    void Awake()
    {
        toolTip.enabled = false;
    }

    void Start()
    {
        offset = transform.position - toolTip.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            switch (hit.collider.name)
            {
                
                case "Jungle Rodent":
                case "Kerosene Lamp":
                case "env_exterior_snaketree_lowpoly":
                case "SnakeProp":
                    toolTip.enabled = true;
                    break;
                default:
                    if(toolTip != null)
                        toolTip.enabled = false;
                    break;
            }

            if (hit.collider.gameObject != null)
            {
                if(toolTip != null)
                    toolTip.transform.position = new Vector3(transform.position.x, transform.position.y - offset.y, transform.position.z);
            }
        }
    }
}
