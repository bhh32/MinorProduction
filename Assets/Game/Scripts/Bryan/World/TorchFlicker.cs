using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFlicker : MonoBehaviour 
{
    [SerializeField] Light fireLight;
    [SerializeField] float minFlicker;
    [SerializeField] float maxFlicker;
    [SerializeField] float flickerSpeed;

    void Awake()
    {
        fireLight = GetComponent<Light>();
        StartCoroutine("Flicker");
    }

    IEnumerator Flicker()
    {
        while (true)
        {    
            float randomFlicker = Random.Range(minFlicker, maxFlicker);

            fireLight.intensity = randomFlicker;

            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
