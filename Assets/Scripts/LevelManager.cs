using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] images;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = Instantiate (images[Random.Range(0, images.Length)], spawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
