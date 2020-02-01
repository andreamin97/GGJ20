using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FindImage : MonoBehaviour
{
    public int ID = 1;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW www = new WWW("file:///" + Data.filename);
        Debug.Log ("file:///" + Data.filename);
        while (!www.isDone)
            yield return null;
        GameObject image = GameObject.Find("RawImage");
        image.GetComponent<RawImage>().texture = www.texture;
    }

    IEnumerator SetImage ()
    {
        WWW www = new WWW("file:///" + Data.filename);
        Debug.Log("file:///" + Data.filename);
        while (!www.isDone)
            yield return null;
        GameObject image = GameObject.Find("RawImage");
        image.GetComponent<RawImage>().texture = www.texture;
    }

    public void SaveScreenshot()
    {
        FileUtil.MoveFileOrDirectory(Data.filename, "C:/GGJ20_Screeshots/" + Data.filename);
    }
}
