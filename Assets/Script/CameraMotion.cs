using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public float paralalEfact;
    public GameObject cam;
    private float length, startPos;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        float distance = (cam.transform.position.x * paralalEfact);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
