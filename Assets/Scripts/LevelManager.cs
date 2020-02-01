using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Sprite[] images;
    public GameObject drawingCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Sprite randomImage = images[Random.Range(0, images.Length)];
        drawingCanvas.GetComponent<SpriteRenderer>().sprite = randomImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
