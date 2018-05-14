using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // 0.275f will give roughly 10min day and 10min night periods
    [SerializeField] float dayNightCycleLength; 
    [SerializeField] GameObject sunOrbitAxis;

    void Update()
    {
        UpdateSunPos();
    }

    void UpdateSunPos()
    {
        transform.RotateAround(sunOrbitAxis.transform.position, Vector3.right, dayNightCycleLength * Time.deltaTime);
    }
}
