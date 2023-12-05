using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCreator : MonoBehaviour
{
    GameObject go, projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Disable"))
        {
            gameObject.SetActive(false);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Disable"))
        {
            gameObject.SetActive(false);

        }
    }
}
