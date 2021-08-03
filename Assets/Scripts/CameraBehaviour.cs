using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    [Header("Camera variables")]
    [SerializeField] private Transform initialTarget;
    private static Vector3 targetPos;

    private void Start()
    {
        transform.position = (targetPos == Vector3.zero) ? initialTarget.position : targetPos;
    }

    private void Update()
    {
        if (targetPos != Vector3.zero)
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
    }

    public static void SetTarget(Vector3 newTarget)
    {
        targetPos = newTarget;
    }

}
