using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevelController : MonoBehaviour
{

    [SerializeField] private LevelChanger levelChanger;
    [SerializeField] private int nextLevelIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SetCanMove(false);
            SpawnController.SetSpawn(Vector3.zero);
            CameraBehaviour.SetTarget(Vector3.zero);
            levelChanger.FadeToLevelWithDelay(nextLevelIndex);
            SpawnController.isLeft = false;
        }
    }

}
