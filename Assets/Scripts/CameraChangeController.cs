using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeController : MonoBehaviour
{
    [Header("Camera change variables")]
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private bool checkY;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform newTarget = (checkY ?
                (other.transform.position.y > transform.position.y) :
                other.transform.position.x > transform.position.x) ?
                rightPos : leftPos;
            CameraBehaviour.SetTarget(newTarget.position);
            SpawnController.SetSpawn(newTarget.GetChild(0).position);
            SpawnController.isLeft = name.Substring(name.Length - 1) == "L";
        }
    }

}
