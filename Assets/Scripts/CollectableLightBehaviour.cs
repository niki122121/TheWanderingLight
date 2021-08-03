using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableLightBehaviour : LightBehaviour
{

    [SerializeField] private float gainIntensity;

    protected override void Behaviour(GameObject player)
    {
        base.Behaviour(player);
        player.GetComponent<LightController>().GainLight(gainIntensity);
        if (gainIntensity >= 0)
            GameObject.Find("Uduino").GetComponent<LedController>().GetLightWhite();
        else
            GameObject.Find("Uduino").GetComponent<LedController>().GetDarkness();
    }

    protected override int GetType()
    {
        return (gainIntensity >= 0) ? 0 : 1;
    }

}