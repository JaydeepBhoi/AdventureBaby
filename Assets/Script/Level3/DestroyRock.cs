using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            // Invoke("destroyBody", 0.14f);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("destroyBody", 0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            // Invoke("destroyBody", 0.14f);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("destroyBody", 0.1f);
        }
    }

    void destroyBody()
    {
        Destroy(gameObject);
    }
}
