using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXTime : MonoBehaviour
{

    [SerializeField] private float timeUntilDestroy;

    void Start()
    {
        Invoke("DestroySelf", timeUntilDestroy);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

}
