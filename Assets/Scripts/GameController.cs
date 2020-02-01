using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Timer;
    public GameObject timerUI;
    Text timerText;
    void Start()
    {
        Timer = 20.00f;
        timerText = timerUI.GetComponent<Text>();
    }
    void Update() 
    {
        Timer -= Time.deltaTime;
        timerText.text = Timer.ToString("f2");
    }        
    public void TakeScreenshot()
    {
        /*myCamera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        takeScreenshotOnNextFrame = true;*/
        string filename = Time.time.ToString("f6") + ".png";
        ScreenCapture.CaptureScreenshot(filename, 1);
    }
}
