using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brightnessManager : MonoBehaviour
{
    [SerializeField] Light lightObj;
    public void changeBrightness(float n)
    {
        lightObj.intensity = 2*n;
    }
}
