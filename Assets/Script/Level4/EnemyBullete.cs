using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullete : MonoBehaviour
{
    private int livesCountVal;
    public bool startEnemy;
    public bool stopEnemy;
    public int secondCount = 0;

    public bool call, coinCall, plntEnemy;
    int coins = 3, counter;
    private Animator anim;

    private bool touchEnemy, TurtleEnemy, bullete;
    public static EnemyBullete insance;

    public int healthEffectVar, health;


    void Start()
    {

        if (insance == null)
        {
            insance = this;
        }
        startEnemy = false;
        stopEnemy = true;
        call = false;
        coinCall = false;
        touchEnemy = false;
        bullete = false;
        plntEnemy = false;

        health = 1;

    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log("%%%%%%%%%%%%%%%%%%%%Call Bulete %%%%%%%%%%%%%%%%%%%%" + Gun.instance.gunActive);


    }







    private void OnCollisionEnter2D(Collision2D collision)
    {




        if (collision.gameObject.CompareTag("Player"))
        {

            if (Gun.instance.gunActive == true)
            {

                if (health == 1)
                {

                    SoundScript.playsound("TurtleJump_2");
                    //SoundScript.playsound("Die_Sound");
                    Invoke("gunCall", 0.5f);
                    coinCall = true;
                  
                    healthEffectVar = 10;
                    //  InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                    GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);


                    // Debug.Log("############### Helth ####################### "+health );

                }
                else if (health == 2)
                {
                    //  Debug.Log("****************** Helth ********************" + health);
                   
                    Gun.instance.gunActive = false;
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                    GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

                    Player.instance.anim.GetComponent<Animator>().enabled = false;

                    Player.instance.speedPlayer = 0;
                    //  Player.instance.isJumping = true;
                    Invoke("CallEnemy", 1.5f);
                    // bullete = true;
                }
            }

            if (Gun.instance.gunActive == false)
            {
                if (bullete == false)
                {
                   

                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                    GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

                    Player.instance.anim.GetComponent<Animator>().enabled = false;

                    Player.instance.speedPlayer = 0;
                    //  Player.instance.isJumping = true;
                    Invoke("CallEnemy", 1.5f);
                    bullete = true;
                    // Debug.Log("!!!!!!!!!!!!!!!!!Callldfldfl!!!!!!!!!!!!!!!!!!!!!!!");
                }

            }
        }




    }











    void CallEnemy()
    {
        if (PlayerPrefs.GetInt("Lives") > 1)
        {


            Player.instance.speedPlayer = 10;
            Vector3 pos = Player.instance.respawnPoint;
            pos.z = -10f;
            Player.instance.cam.transform.position = pos;
            //   respawnPoint.z = respawnPoint.z + 1f;
            Player.instance.anim.GetComponent<Animator>().enabled = true;
            Player.instance.transform.position = Player.instance.respawnPoint;
            CoinCounter.instance.livesCounter(coins);
            //Player.instance.isJumping = false;
            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

        }
        else
        {
            CoinCounter.instance.livesCounter(coins);
        }

    }


    void gunCall()
    {


        health = 2;

    }

    void HealthEffect()
    {

        healthEffectVar--;

        if (healthEffectVar % 2 == 0)
        {
            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
        }
        if (healthEffectVar == 0)
        {

            CancelInvoke("HealthEffect");
        }

    }



}







//private void OnCollisionEnter2D(Collision2D collision)
//{
//    if (collision.gameObject.CompareTag("Floor"))
//    {
//        Invoke("destroyBody", 0.14f);
//    }

//    if (collision.gameObject.CompareTag("Player"))
//    {
//        Invoke("destroyBody", 0.1f);
//    }

//}