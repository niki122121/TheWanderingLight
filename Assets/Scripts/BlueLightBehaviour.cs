using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLightBehaviour : LightBehaviour
{
    [SerializeField] private float timeAccelerating;
    protected override void Behaviour(GameObject player)
    {
        base.Behaviour(player);
        player.GetComponent<PlayerController>().Accelerate(timeAccelerating);
        GameObject.Find("Uduino").GetComponent<LedController>().GetLightBlue();
    }

    protected override int GetType()
    {
        return 3;
    }
}
