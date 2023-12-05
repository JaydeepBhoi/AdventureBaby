using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class back : MonoBehaviour
{
    Vector3 backPosition;
    Camera cam;
    public Vector2 p;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(4, 0);
        Physics2D.IgnoreLayerCollision(4, 1);
        Physics2D.IgnoreLayerCollision(4, 2);
        Physics2D.IgnoreLayerCollision(4, 5);
        Physics2D.IgnoreLayerCollision(4, 8);
        Physics2D.IgnoreLayerCollision(4, 20);
        Physics2D.IgnoreLayerCollision(4, 10);
        Physics2D.IgnoreLayerCollision(4, 11);
        Physics2D.IgnoreLayerCollision(4, 21);
        Physics2D.IgnoreLayerCollision(4, 14);
        Physics2D.IgnoreLayerCollision(4, 22);
        Physics2D.IgnoreLayerCollision(4, 21);
        Physics2D.IgnoreLayerCollision(4, 24);
        Physics2D.IgnoreLayerCollision(4, 25);
        Physics2D.IgnoreLayerCollision(4, 26);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {

        
           // collision.gameObject.transform.position = backPosition;
        }


        if (collision.gameObject.CompareTag("runEnemy"))
        {

            Debug.Log("Touchfdfdfdfdfd");

        }
    }




    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //backPosition = transform.position;

    //    if (collision.gameObject.CompareTag("runEnemy"))
    //    {

    //        Debug.Log("Touchfdfdfdfdfd");
            
    //    }
    //}
    
}
