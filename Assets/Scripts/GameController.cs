using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Timer = 20f;
    public GameObject timerUI;
    public GameObject canvasObj;
    Text timerText;
    Canvas canvas;

    void Start()
    {
        timerText = timerUI.GetComponent<Text>();
    }
    void Update() 
    {
        Timer -= Time.deltaTime;
        timerText.text = Timer.ToString("f2");

        if(Timer <= 0f)
        {
            TakeScreenshot();
            SceneManager.LoadScene("Post-Game");
        }   
    }        
    public void TakeScreenshot()
    {
        canvas = canvasObj.GetComponent<Canvas>();
        canvas.enabled = false;

        string filename = Time.time.ToString("f6") + ".png";
        ScreenCapture.CaptureScreenshot(filename, 1);
        Data.filename = filename;
        Debug.Log(filename);
    }
}
