using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    private bool isChanging;

    private void Start()
    {
        isChanging = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePauseMode();
        }
    }

    public void ChangePauseMode()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void BackToMenu()
    {
        if (!isChanging)
        {
            isChanging = true;
            Time.timeScale = 1;
            SpawnController.SetSpawn(Vector3.zero);
            CameraBehaviour.SetTarget(Vector3.zero);
            GameObject.FindWithTag("LevelChanger").GetComponent<LevelChanger>().FadeToLevel(1);
        }
    }

}
