using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    private int livesCountVal;
    public bool startEnemy;
    public bool stopEnemy;
    public int secondCount = 0;
    public GameObject player;
    public bool call, coinCall, plntEnemy;
    int coins = 3;
    private Animator anim;

    private bool touchEnemy;
    public static SpiderEnemy insance;
  
    int healthEffectVar;
    public GameObject bullete;



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




    }







    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.gameObject.tag == "gunshoot")
        {
            SoundScript.playsound("TurtleJump_2");
            //   SoundScript.playsound("Die_Sound");
            // Debug.Log("++++++++++++++++++++++++++++++");
            Destroy(bullete);
          //  myAnimation.gameObject.GetComponent<Animator>().enabled = false;
        //    gameObject.GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
            // Invoke("callDestroy", 0.2f);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 50f;

          // speed = 0;
            //startEnemy = true;
           // movementBool = true;
        }







        foreach (ContactPoint2D hitpoints in collision.contacts)
        {


            if (collision.gameObject.tag == "Player" )
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
                            SoundScript.playsound("Die_Sound");
                            //CoinCall is used to reduce  Twice colision of enemy and calculate the right Lives 
                            if (coinCall == false)
                            {
                                healthEffectVar = 10;
                                InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                                GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                                coinCall = true;
                                Invoke("gunCall", 0.25f);
                                // CoinCounter.instance.livesCounter(coins);
                                //   Debug.Log("<<<<<<<<<<<<<<<<<<<<Call Lives>>>>>>>>>>>>>>>>>>>>>>");
                            }

                            //Call the Gun variable false if enemy Touch 
                           
                        }

                    }

                    //If Player Don't have any Power of gun the Directly kill by the Enemy 
                    if (Gun.instance.gunActive == false && startEnemy == false)
                    {

                        if (touchEnemy == false && plntEnemy == false)
                        {
                            SoundScript.playsound("Die_Sound");
                            // startEnemy = true;
                            //    SceneReload.instance.reloadData();
                            //     Gun.instance.EnemyActive = true;

                            //  TurtleEnemy = true;


                            healthEffectVar = 10;
                            InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

                            plntEnemy = true;
                            Invoke("PlantCall", 1.5f);

                            Player.instance.speedPlayer = 0;


                            Vector2 pos = Player.instance.gameObject.transform.position;
                            pos.x = pos.x - 0.8f;
                            Player.instance.gameObject.transform.position = pos;
                           // Player.instance.isJumping = true;
                            Player.instance.anim.GetComponent<Animator>().enabled = false;
                            //   Player.instance.moveVal = true;
                            Player.instance.speedPlayer = 0;

                        }

                    }

                }
            }

        }
    }


    void PlantCall()
    {
        if (PlayerPrefs.GetInt("Lives") > 1)
        {
            plntEnemy = false;
            Vector3 pos = Player.instance.respawnPoint;
            pos.z = -10f;
            Player.instance.cam.transform.position = pos;
            //   respawnPoint.z = respawnPoint.z + 1f;
            Player.instance.transform.position = Player.instance.respawnPoint;
            Player.instance.speedPlayer = 10;
            Player.instance.anim.GetComponent<Animator>().enabled = true;
            //Player.instance.isJumping = false;
            CoinCounter.instance.livesCounter(coins);
            //  Player.instance.moveVal = false;
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


}
