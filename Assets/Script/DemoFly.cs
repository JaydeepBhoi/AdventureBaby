using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DemoFly : MonoBehaviour
{

    public Vector2 startPosition;
    public Vector2 endPosition ;


    public float moveSpeed = 2.0f; // Speed to reach destination
    public float frequency = 5.0f;  // Speed of sine movement
    public float magnitude = 0.25f;   // Size of sine movement

    private Vector2 pos;
    private Vector2 dir;
    private Vector2 perpendicularDir;

    public bool fly = false;
    // Use this for initialization
    void Start()
    {

        pos = transform.localPosition;
        startPosition = transform.localScale;
        endPosition = transform.localScale;
        //transform.position = startPosition;
        //pos = startPosition;

        dir = (endPosition - startPosition); // The direction and distance from startPosition to endPosition
        Debug.DrawLine(pos, pos + dir, Color.red, Mathf.Infinity); // Draw a debug line from startPosition to endPosition

        perpendicularDir = new Vector2(gameObject.transform.position.x,-gameObject.transform.position.y);
        //Debug.DrawLine (pos, pos + perpendicularDir, Color.blue, Mathf.Infinity);

    }

    // Update is called once per frame
    void Update()
    {
        //pos += dir * Time.deltaTime * moveSpeed;

        if (fly == false)
        {
            Debug.Log("Callldfldfldlfdlf == ==" +fly);
            transform.Translate(dir * moveSpeed * Time.deltaTime);

            transform.position = pos + perpendicularDir * Mathf.Sin(Time.time * frequency) * magnitude;
        }
       


       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gunshoot")
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
         
            moveSpeed = 0;
            frequency = 0;
            magnitude = 0;
            fly = true;
          //  Debug.Log("Callldfldfldlfdlf == ==" + fly);
        }
    }
}