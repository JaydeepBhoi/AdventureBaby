using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwiseBeeFly : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = true;

    Vector3 pos, localScale;

    public GameObject player;

    private float moveX;
    public bool fly = false;

    public bool beeEnemy;
    public int beecheck;
    public bool startEnemy, coinCall, stopEnemy;
    int coins = 3;
    int healthEffectVar;

    public int flyCount;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(28, 11);
        Physics2D.IgnoreLayerCollision(23, 22);
        startEnemy = false;
        stopEnemy = true;
        coinCall = false;
        beeEnemy = false;
        moveX = transform.position.x;
        pos = transform.position;
        //   flyCount = 0;
        localScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (fly == false)
        {
            CheckWhereToFace();

            if (facingRight)
                MoveRight();
            else
                MoveLeft();
        }


    }

    void CheckWhereToFace()
    {
        if (pos.x < moveX - 20)
            facingRight = true;

        else if (pos.x > moveX)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }



    void callBox()
    {
        Destroy(Player.instance.gameObject.GetComponent<BoxCollider2D>());

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "gunshoot")
        {
            SoundScript.playsound("TurtleJump_2");
            //   SoundScript.playsound("Die_Sound");

            moveSpeed = 0;
            frequency = 0;
            magnitude = 0;
            fly = true;

            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }



        if (collision.gameObject.tag == "Player" )
        {
           // flyCount = 1;

            foreach (ContactPoint2D hitpoints in collision.contacts)
            {

                if (hitpoints.normal.y < 0)
                {
                    Destroy(gameObject.GetComponent<BoxCollider2D>());
                    SoundScript.playsound("TurtleJump_2");
                    moveSpeed = 0;
                    frequency = 0;
                    magnitude = 0;
                    fly = true;

                }


                if (hitpoints.normal.x < 0 || hitpoints.normal.x > 0)
                {

                    if (Gun.instance.gunActive == true)
                    {

                        //  Debug.Log("check");
                        if (coinCall == false)
                        {
                            SoundScript.playsound("Die_Sound");
                            healthEffectVar = 10;
                            InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                            flyCount = 0;
                            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                            coinCall = true;
                            // CoinCounter.instance.livesCounter(coins);
                            Invoke("gunCall", 0.25f);




                        }
                    }


                    if (Gun.instance.gunActive == false  && beeEnemy == false)
                    {
                        // Physics2D.IgnoreLayerCollision(28, 9);
                        // flyCount = 1;
                        //startEnemy = true;
                        //SceneReload.instance.reloadData();

                        SoundScript.playsound("Die_Sound");
                        //Destroy(player.GetComponent<BoxCollider2D>());

                        healthEffectVar = 10;
                        InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                        GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                        Player.instance.anim.GetComponent<Animator>().enabled = false;

                        beeEnemy = true;
                        Player.instance.speedPlayer = 0;
                        Invoke("beeCall", 0.4f);
                        Invoke("callEnemyBee", 1f);
                        //  Invoke("callBox", 0.15f);

                       // gameObject.SetActive(false);


                    }
                }

            }



        }









    }

    void beeCall()
    {

        if (PlayerPrefs.GetInt("Lives") > 1)
        {
            // beecheck = 0;
            beeEnemy = false;

            Vector3 pos = Player.instance.respawnPoint;
            pos.z = -10f;
            Player.instance.cam.transform.position = pos;
            //   respawnPoint.z = respawnPoint.z + 1f;
            Player.instance.transform.position = Player.instance.respawnPoint;
            Player.instance.anim.GetComponent<Animator>().enabled = true;
            Player.instance.speedPlayer = 10;
            //  Player.instance.isJumping = false;
            CoinCounter.instance.livesCounter(coins);
            Player.instance.gameObject.AddComponent<BoxCollider>();
            //   beecheck = 0;
        }
        else
        {
            CoinCounter.instance.livesCounter(coins);

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

    void callEnemyBee()
    {
        flyCount = 0;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Disable"))
        {
            gameObject.SetActive(false);

        }
    }

}
