using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamPan : MonoBehaviour {

    [SerializeField] GameObject player;

    Vector3 offset;
    public float followSharpness = 0.1f;

	void Awake()
    {
        offset = transform.position - player.transform.position;
    }
	void FixedUpdate()
	{
		player = GameObject.FindWithTag ("Indy");
	}
	// Update is called once per frame
	void LateUpdate () {
        float blend = 1f - Mathf.Pow(1f - followSharpness, Time.deltaTime * 30f);

        transform.position = Vector3.Lerp(transform.position, 
                                          player.transform.position + offset,
                                          blend);
	}
}
