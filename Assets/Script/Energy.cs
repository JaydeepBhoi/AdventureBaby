using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundScript.playsound("Energy_Sound");
            Destroy(gameObject);

            // Timer.instance.selectorArr[count].SetActive(true);

            if (Timer.instance.count >= 1 && Timer.instance.count < 10)
            {
                Timer.instance.selectorArr[10 - (Timer.instance.count)].SetActive(true);
                Timer.instance.count--;
                Timer.instance.curentTime = 1;
            }



        }
    }

	

   
   
}
