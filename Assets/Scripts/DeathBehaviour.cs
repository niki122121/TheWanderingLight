using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{

    [SerializeField] private float timeToReset;

    private void Start()
    {
        Invoke("ResetLevel", timeToReset);
    }

    private void ResetLevel()
    {
        GameObject.FindWithTag("LevelChanger").GetComponent<LevelChanger>().WhiteFadeToThisLevel(); // Cambiar por singleton.
    }

}
