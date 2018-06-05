using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldItemToolTip : MonoBehaviour 
{
    [SerializeField] TMP_Text toolTip;

    Vector3 offset;

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
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.CompareTag("Jungle Rodent"))
                toolTip.enabled = true;
            else
                toolTip.enabled = false;
        }

        toolTip.transform.position = new Vector3(transform.position.x, transform.position.y - offset.y, transform.position.z);
	}
}
