using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockStone : MonoBehaviour
{
    private int livesCountVal;
    public bool startEnemy;
    public bool stopEnemy;
    public int secondCount = 0;
  
    public bool call, coinCall, plntEnemy;
    int coins = 3;
    private Animator anim;

    private bool touchEnemy, TurtleEnemy;
    public static rockStone insance;

    int healthEffectVar;
   



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

        plntEnemy = false;

    }

    // Update is called once per frame
    void Update()
    {

        Physics2D.IgnoreLayerCollision(13, 12);


    }







    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Floor"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject.GetComponent<Collider2D>());
           
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("destroyBody", 1.5f);
        }



        foreach (ContactPoint2D hitpoints in collision.contacts)
        {


            if (collision.gameObject.tag == "Player")
            {

                //Enemy first Disable and Destroy

           

                //If Player first get power of Gun Then Eemy first Disable the Power of Gun After kill The Player if Player Don't have any power of Gun then Direct kill By The Enemy


                if (hitpoints.normal.x < 0 || hitpoints.normal.x > 0 || hitpoints.normal.y < 0 || hitpoints.normal.y > 0)
                {
                    if (startEnemy == false)
                    {

                        //Player has Power of Gun and Disabled the Power of Gun

                        if (Gun.instance.gunActive == true)
                        {

                            //CoinCall is used to reduce  Twice colision of enemy and calculate the right Lives 
                            if (coinCall == false)
                            {
                                healthEffectVar = 10;
                                InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                                GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                                coinCall = true;
                                //CoinCounter.instance.livesCounter(coins);
                                SoundScript.playsound("Die_Sound");
                            }

                            //Call the Gun variable false if enemy Touch 
                            Invoke("gunCall", 0.25f);
                        }

                    }

                    //If Player Don't have any Power of gun the Directly kill by the Enemy 
                    if (Gun.instance.gunActive == false && startEnemy == false && TurtleEnemy == false)
                    {

                        // startEnemy = true;
                        //SceneReload.instance.reloadData();
                        //  Gun.instance.EnemyActive = true;

                        healthEffectVar = 10;
                        InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                        GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

                        Player.instance.anim.GetComponent<Animator>().enabled = false;
                        TurtleEnemy = true;
                        Invoke("CallEnemy", 1.5f);
                        Player.instance.speedPlayer = 0;
                        //  Player.instance.isJumping = true;
                        //  Player.instance.moveVal = true;

                      //  SoundScript.playsound("TurtleJump_2");
                        SoundScript.playsound("Die_Sound");

                        //Player.instance.cam.transform.position = Player.instance.respawnPoint;
                        //Player.instance.respawnPoint.z = Player.instance.respawnPoint.z + 1f;

                        //Player.instance.transform.position = Player.instance.respawnPoint;




                    }

                }
            }

        }





    }





    void CallEnemy()
    {
        Debug.Log("////////Counter//////////" + PlayerPrefs.GetInt("Lives"));
        if (PlayerPrefs.GetInt("Lives") > 1)
        {

            TurtleEnemy = false;
            Player.instance.speedPlayer = 10;
            Vector3 pos = Player.instance.respawnPoint;
            pos.z = -10f;
            Player.instance.cam.transform.position = pos;
            //   respawnPoint.z = respawnPoint.z + 1f;
            Player.instance.anim.GetComponent<Animator>().enabled = true;
            Player.instance.transform.position = Player.instance.respawnPoint;
            CoinCounter.instance.livesCounter(coins);
        //    Player.instance.isJumping = false;
           // Player.instance.moveVal = false;
        }
        else
        {
            CoinCounter.instance.livesCounter(coins);
        }
    }

    void EnemyCall()
    {
        stopEnemy = false;

        Debug.Log("Calllllllllll");
    }
    void gunCall()
    {


        Gun.instance.gunActive = false;

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

    void destroyBody()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChatanColide"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 3.5f;


            Debug.Log("Chatan Callllllfldfldlfd");
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