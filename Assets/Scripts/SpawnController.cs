using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField] private Transform initialSpawn;
    private static Vector3 spawnPos;
    public static bool isLeft;

    private void Start()
    {
        transform.position = (spawnPos == Vector3.zero) ? initialSpawn.position : spawnPos;
    }

    public static void SetSpawn(Vector3 newSpawn)
    {
        spawnPos = newSpawn;
    }

}
