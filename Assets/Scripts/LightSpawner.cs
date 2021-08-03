using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    [SerializeField] private GameObject whiteLightPrefab;
    [SerializeField] private GameObject darkLightPrefab;
    [SerializeField] private GameObject greenLightPrefab;
    [SerializeField] private GameObject blueLightPrefab;

    [SerializeField] private float timeToSpawn;

    private int type;

    public void SetType(int _type)
    {
        type = _type;
    }

    private void Start()
    {
        Invoke("SpawnLight", timeToSpawn);
    }

    private void SpawnLight()
    {
        if (type == 0)
            Instantiate(whiteLightPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        else if (type == 1)
            Instantiate(darkLightPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        else if (type == 2)
            Instantiate(greenLightPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        else if (type == 3)
            Instantiate(blueLightPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        Destroy(gameObject);
    }

}
