using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingCanvas : MonoBehaviour
{
    public bool isOnCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse is hovering over");
        isOnCanvas = true;
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer hovering.");
        isOnCanvas = false;
    }

}
