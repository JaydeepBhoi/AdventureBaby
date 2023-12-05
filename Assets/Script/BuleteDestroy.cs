using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuleteDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Turtle" || collision.gameObject.tag == "Bee" || collision.gameObject.tag == "spider" || collision.gameObject.tag == "plantEnemy" || collision.gameObject.tag == "nonPlant" || collision.gameObject.tag == "BatEnemy")
        {
            Destroy(gameObject);
           // Debug.Log("())()()()(()()()()()())()");

        }
    }


}
