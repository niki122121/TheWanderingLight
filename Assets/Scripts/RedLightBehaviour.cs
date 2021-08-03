using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightBehaviour : LightBehaviour
{

    protected override void Behaviour(GameObject player)
    {
        base.Behaviour(player);
        player.GetComponent<PlayerController>().Jump();
        GameObject.Find("Uduino").GetComponent<LedController>().GetLightRed();
    }

    protected override int GetType()
    {
        return 2;
    }
}
