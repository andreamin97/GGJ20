using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{

    public GameObject drawPrefab;
    TrailRenderer trailRenderer;
    GameObject trail;
    Plane planeObj;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            trail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            if(planeObj.Raycast(mouseRay, out _dis))
            {
                startPos = mouseRay.GetPoint(_dis);
            }
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            if(planeObj.Raycast(mouseRay, out _dis))
            {
                trail.transform.position = mouseRay.GetPoint(_dis);
            }
        }
    }

    public void ChangeColorToRed()
    {
        trailRenderer = drawPrefab.GetComponent<TrailRenderer>();
        trailRenderer.startColor = Color.red;
        trailRenderer.endColor = Color.red;
    }

    public void ChangeColorToBlue()
    {
        trailRenderer = drawPrefab.GetComponent<TrailRenderer>();
        trailRenderer.startColor = Color.blue;
        trailRenderer.endColor = Color.blue;
    }

    public void ChangeColorToWhite()
    {
        trailRenderer = drawPrefab.GetComponent<TrailRenderer>();
        trailRenderer.startColor = Color.white;
        trailRenderer.endColor = Color.white;
    }
}
