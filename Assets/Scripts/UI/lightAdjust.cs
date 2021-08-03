using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAdjust : MonoBehaviour
{
    Light lt;
    private void Start()
    {
        lt = GetComponent<Light>();
    }
    public void adjustLight(float lIntensity)
    {
        lt.intensity = lIntensity;
    }
}
