using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Text imageName;
    //public GameObject pictureObj;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW www = new WWW("file:///GGJ20_Data/" + Data.filename);

        while(!www.isDone)
			yield return null;
		GameObject image = GameObject.Find ("RawImage");
		image.GetComponent<RawImage>().texture = www.texture;
        imageName.text = Data.filename;
    }

    public void SaveScreenshot()
    {
        //FileUtil.MoveFileOrDirectory(Data.filename, "C:/GGJ20_Screeshots/"+Data.filename);
    }
}

