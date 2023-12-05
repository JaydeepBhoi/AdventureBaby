using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartEnemy : MonoBehaviour
{

    public static StartEnemy instance;
    public bool startEnemy=false;

  //  GameObject turtle;   // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
      //  turtle.CompareTag("Turtle");

       
    }

    // Update is called once per frame
    void Update()
    {
        

        

       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("stone"))
        //{
        //    Debug.Log("check________Colision");

        //    collision.gameObject.GetComponent<StoneEnemy>().enabled = true;
        //  //  StoneEnemy.insance.stoneStop = false;
        //    // Start is called before th
        //}

        if (collision.gameObject.CompareTag("BatEnemy"))
        {
            Debug.Log("check________Colision");

            collision.gameObject.GetComponent<BatEnemy>().enabled = true;

            // Start is called before th
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Turtle"))
        {
            Debug.Log("check________");

            collision.gameObject.GetComponent<Enemy>().enabled=true;
           
            // Start is called before th
        }


        if (collision.gameObject.CompareTag("stone"))
        {
            Debug.Log("check________Colision");

            collision.gameObject.GetComponent<StoneEnemy>().enabled = true;

            // Start is called before th
        }

        if (collision.gameObject.CompareTag("BatEnemy"))
        {
            Debug.Log("check________Colision");
         //   collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            collision.gameObject.GetComponent<BatEnemy>().enabled = true;
            collision.gameObject.SetActive(true);
            // Start is called before th
        }


    }
}
