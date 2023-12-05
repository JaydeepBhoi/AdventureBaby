using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public static Disable instance = null;
    public bool enemyActive;
    void Start()
    {
        enemyActive = false;
        Physics2D.IgnoreLayerCollision(21, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
       
   
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("NewDisable"))
        {
            enemyActive = true;
            collision.gameObject.GetComponent<runenemy>().enabled = true;
            Physics2D.IgnoreLayerCollision(26, 9,false);
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 12;

        }

        if (collision.gameObject.CompareTag("runEnemy2"))
        {
            enemyActive = true;
            collision.gameObject.GetComponent<runenemy>().enabled = true;
            Physics2D.IgnoreLayerCollision(25, 9, false);
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 12;

        }

        if (collision.gameObject.CompareTag("runEnemy1"))
        {
            enemyActive = true;
            collision.gameObject.GetComponent<runenemy>().enabled = true;
            Physics2D.IgnoreLayerCollision(26, 9, false);
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 12;

        }


    }
}
