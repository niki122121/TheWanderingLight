using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundSound : MonoBehaviour
{
    [SerializeField] private AudioSource audio1;
    [SerializeField] private AudioSource audio2;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 ||
            SceneManager.GetActiveScene().buildIndex == 1 ||
            SceneManager.GetActiveScene().buildIndex == 2 ||
            SceneManager.GetActiveScene().buildIndex == 4 ||
            SceneManager.GetActiveScene().buildIndex == 5)
        {
            audio2.volume = 0.412f;
        }
        else
        {
            audio2.volume = 0;
        }
    }
}
