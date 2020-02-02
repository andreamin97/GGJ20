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
    [HideInInspector] public int ID = 0;

    public Camera SnapshotCamera;
    int resWidth = 256;
    int resHeight = 256;

    void Start()
    {
        timerText = timerUI.GetComponent<Text>();
        ID = PlayerPrefs.GetInt("ID", ID);

        if (SnapshotCamera.targetTexture == null)
        {
            SnapshotCamera.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = SnapshotCamera.targetTexture.width;
            resHeight = SnapshotCamera.targetTexture.height;
        }
        SnapshotCamera.gameObject.SetActive(false);

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
        /*canvas = canvasObj.GetComponent<Canvas>();
        canvas.enabled = false;

        string filename = ID + ".png";
        ScreenCapture.CaptureScreenshot(filename, 1);
        Data.filename = filename;
        Debug.Log(filename);
        ID++;
        PlayerPrefs.SetInt("ID", ID);*/
        
        SnapshotCamera.gameObject.SetActive(true);
        Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        SnapshotCamera.Render();
        RenderTexture.active = SnapshotCamera.targetTexture;
        snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        byte[] bytes = snapshot.EncodeToPNG();

        string filename = ID + ".png";
        Data.filename = filename;
        ID++;
        PlayerPrefs.SetInt("ID", ID);

        System.IO.File.WriteAllBytes(filename, bytes);

        SnapshotCamera.gameObject.SetActive(false);

    }
}
