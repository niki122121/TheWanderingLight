using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class LedController : MonoBehaviour
{
    public Color mainColor;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 5)
            SetDefault();
    }

    public void GetLightWhite()
    {
        UduinoManager.Instance.sendCommand("setObjL", 180, 255, 255, 255);
    }

    public void GetLightBlue()
    {
        UduinoManager.Instance.sendCommand("setObjL", 180, 0, 88, 255);
    }

    public void GetLightRed()
    {
        UduinoManager.Instance.sendCommand("setObjL", 180, 0, 255, 0);
    }

    public void GetDarkness()
    {

        UduinoManager.Instance.sendCommand("setObjD", 10);
    }

    public void SetDefault()
    {
        UduinoManager.Instance.sendCommand("default");
    }

}

/*if (Input.GetKeyDown("left"))
            currentPixel--;
        else if (Input.GetKeyDown("right"))
            currentPixel++;

        if (currentPixel < 0)
            currentPixel = 59;
        else if (currentPixel > 59)
            currentPixel = 0;

        if (currentPixel != prevPixel)
        {
            UduinoManager.Instance.sendCommand("turnOff", prevPixel);
            UduinoManager.Instance.sendCommand("turnOn", currentPixel, (int)Mathf.FloorToInt(mainColor.r) * 255, 
                                                                       (int)Mathf.FloorToInt(mainColor.g) * 255, 
                                                                       (int)Mathf.FloorToInt(mainColor.b) * 255);

            prevPixel = currentPixel;
        }*/
