using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public int MoveEnimyX;
    public int enemySpeed;
    public Vector2 scale;
    public int speed;
    private int livesCountVal;
    public Sprite emptyBlockSprite;
    public bool startEnemy;
    public bool stopEnemy;
    public int secondCount = 0;
    public GameObject player;
    public bool call,coinCall;
    int coins = 3;
    private Animator anim;
    public static Enemy insance;
    int healthEffectVar;
    public bool TurtleEnemy;
    Animator myAnimation;
  
    public GameObject bullete;
 
    void Start()
    {
        myAnimation = GetComponent<Animator>();
        if (insance == null)
        {
            insance = this;
        }
        startEnemy = false;
        stopEnemy = true;
        call = false;
        coinCall = false;
        TurtleEnemy = false;
        
        anim = GetComponent<Animator>();
//        Debug.Log("Count++++===" + Gun.instance.gunActive);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(MoveEnimyX, gameObject.GetComponent<Rigidbody2D>().velocity.y) * enemySpeed;
    }



    void flip()
    {
        scale = transform.localScale;
        if (MoveEnimyX > 0)
        {

            MoveEnimyX = -1;
            scale.x = 0.6f;
        }
        else if (MoveEnimyX < 0)
        {

            MoveEnimyX = 1;
            scale.x = -0.6f;
        }

        transform.localScale = scale;
    }


    void callDestroy()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "gunshoot")
        {
            SoundScript.playsound("TurtleJump_2");
            Destroy(bullete);
            myAnimation.gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
           // Invoke("callDestroy", 0.2f);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 30f;
           
            enemySpeed = 0;
            startEnemy = true;
        }


        //if (collision.gameObject.tag == "startEnemy" || collision.gameObject.tag == "floor")
        //{
        //    Debug.Log("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
        //}
        //else
        //{
        //    Debug.Log("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            if (startEnemy == false)
            {
                Invoke("flip", 0.02f);
            }
        //}

          

      //  Debug.Log("Count++++===" + startEnemy + stopEnemy);


        foreach (ContactPoint2D hitpoints in collision.contacts)
        {


            if (collision.gameObject.tag == "Player")
            {

                //Enemy first Disable and Destroy

                if (hitpoints.normal.y < 0)
                {
                    startEnemy = true;

                    if (startEnemy == true)
                    {
                        myAnimation.gameObject.GetComponent<Animator>().enabled = false;
                        enemySpeed = 0;
                        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
                        gameObject.GetComponent<Rigidbody2D>().mass = 1000f;
                        CancelInvoke("flip");
                        Invoke("EnemyCall", 0.7f);
                        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20f);

                        SoundScript.playsound("TurtleJump_2");
                        //Back goes to Enemy
                        Vector2 pos= gameObject.transform.position;
                        pos.x = pos.x - 0.7f;
                        gameObject.transform.position = pos;

                    }
                    if (stopEnemy == false)
                    {
                        Vector2 pos = gameObject.transform.position;
                        pos.x = pos.x + 1f;
                        gameObject.transform.position = pos;

                        gameObject.GetComponent<Rigidbody2D>().gravityScale = 100f;
                       
                        Destroy(gameObject.GetComponent<BoxCollider2D>());
                       
                    }

                  


                }

     //If Player first get power of Gun Then Eemy first Disable the Power of Gun After kill The Player if Player Don't have any power of Gun then Direct kill By The Enemy


                if (hitpoints.normal.x < 0 || hitpoints.normal.x > 0  )
                    {
                        if (startEnemy == false)
                        {

                        //Player has Power of Gun and Disabled the Power of Gun

                            if (Gun.instance.gunActive == true )
                            {
                           
                            //CoinCall is used to reduce  Twice colision of enemy and calculate the right Lives 
                            if (coinCall == false)
                                {
                                healthEffectVar = 10;
                                InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                                SoundScript.playsound("Die_Sound");
                                GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                                coinCall = true;
                                    //CoinCounter.instance.livesCounter(coins);
                                }

                            //Call the Gun variable false if enemy Touch 
                            Invoke("gunCall", 0.25f);
                            }

                        }

                        //If Player Don't have any Power of gun the Directly kill by the Enemy 
                        if (Gun.instance.gunActive == false && startEnemy == false  && TurtleEnemy==false)
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

                        SoundScript.playsound("Die_Sound");

                       
                        
                        //Player.instance.cam.transform.position = Player.instance.respawnPoint;
                        //Player.instance.respawnPoint.z = Player.instance.respawnPoint.z + 1f;

                        //Player.instance.transform.position = Player.instance.respawnPoint;




                    }

                    }
            }

        }
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
    void EnemyCall()
    {
        stopEnemy = false;
       
       // Debug.Log("Calllllllllll");
    }
    void gunCall()
    {
       

        Gun.instance.gunActive = false;
       
    }
    void CallEnemy()
    {
       // Debug.Log("////////Counter//////////" + PlayerPrefs.GetInt("Lives"));
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
            //Player.instance.isJumping = false;
        }
        else
        {
            CoinCounter.instance.livesCounter(coins);
        }
    }
   

    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Disable"))
        {
            gameObject.SetActive(false);

        }
    }
}

   
