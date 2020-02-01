using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScreenshot : MonoBehaviour
{
    private static SaveScreenshot instance;
    private Camera myCamera;
    private bool takeScreenshotOnNextFrame;
    void Awake()
    {
        instance = this;

        myCamera = gameObject.GetComponent<Camera>();
    }

    void OnPostRender()
    {
        if(takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;

            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshot.png", byteArray);
            Debug.Log("Saved Screenshot");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
        
    }
    public void TakeScreenshot()
    {
        /*myCamera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        takeScreenshotOnNextFrame = true;*/
        string filename = Time.time.ToString("f6") + ".png";
        ScreenCapture.CaptureScreenshot(filename, 1);
    }
}
