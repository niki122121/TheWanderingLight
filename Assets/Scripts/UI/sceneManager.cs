using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void changeScene(int n)
    {
       SceneManager.LoadScene(n);
    }
}
