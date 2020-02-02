using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FindImage : MonoBehaviour
{
    public Text imageNumber;
    private int number;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        number = PlayerPrefs.GetInt("ID", number);

        WWW www = new WWW("file:///" + number + ".png"/*Data.filename*/);
        Debug.Log ("file:///" + Data.filename);
        while (!www.isDone)
            yield return null;
        GameObject image = GameObject.Find("RawImage");
        image.GetComponent<RawImage>().texture = www.texture;
    }

    private void Update()
    {
        imageNumber.text = number.ToString();
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

    public void LeftButton ()
    {
        StartCoroutine(Lft());
    }

    private IEnumerator Lft ()
    {
        number -= 1;
        WWW www = new WWW("file:///" + number +".png");
        Debug.Log("file:///" + number);
        while (!www.isDone)
            yield return null;
        GameObject image = GameObject.Find("RawImage");
        image.GetComponent<RawImage>().texture = www.texture;
    }

    public void RightButton ()
    {
        StartCoroutine(Rht());
    }

    private IEnumerator Rht ()
    {
        number += 1;
        WWW www = new WWW("file:///" + number+".png");
        Debug.Log("file:///" + number);
        while (!www.isDone)
            yield return null;
        GameObject image = GameObject.Find("RawImage");
        image.GetComponent<RawImage>().texture = www.texture;
    }

    public void SaveScreenshot()
    {
        //FileUtil.MoveFileOrDirectory(Data.filename, "C:/GGJ20_Screeshots/" + Data.filename);
    }
}
