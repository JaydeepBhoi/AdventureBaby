using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinValue = 1;
    void Start()
    {

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        //if (gameObject.CompareTag("CoinTag"))
        //{
        //    Debug.Log("GAYU");
        //    Destroy(gameObject);
        //}

        if (trig.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            CoinCounter.instance.changeScore(coinValue);

          // Debug.Log("Counter" + coinValue);
        }
    }
}
