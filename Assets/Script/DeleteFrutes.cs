using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFrutes : MonoBehaviour
{
    // Start is called before the first frame update
    int lives;
    public bool livesCall;
    void Start()
    {
        livesCall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Call()
    {

        livesCall = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            if (livesCall == false)
            {
                CoinCounter.instance.livesCounter(lives);
                livesCall = true;
            }
           
        }

           

        // Timer.instance.selectorArr[count].SetActive(true);

       



    }
}
