using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

   public static Player instance = null;
    public int jumpForce=600;

   // public int jumpForce = 5;
    public int speedPlayer=10;
    public float playerMoveX;
    public Vector2 velocity;
   public bool isJumping;

    public bool gunActive = false;
   public Camera cam;
    
    public Animator anim;

    private bool lvs;
    private int livesCountVal=3;
    public bool moveVal;
    public Vector3 respawnPoint;

    CoinCounter  coin_one;
    public int count;
    public bool Kill;
    public GameObject enerGy;
    public TextMeshProUGUI textVal;
    [SerializeField]
    public int coins=3,var ;
    public bool PlayerMove;
    Vector2 p;
    Vector3 backPosition;

    public static int bossTouch;

    public bool startEnemy;
    public bool stopEnemy;
    public int secondCount = 0;

    public bool call, coinCall, plntEnemy;


    private bool touchEnemy, TurtleEnemy, bullete;
    public static EnemyBullete insance;

    public int healthEffectVar, health;



    void Start()
    {
        isJumping = false;
        bossTouch = 0;
        startEnemy = false;
        stopEnemy = true;
        call = false;
        coinCall = false;
        touchEnemy = false;
        bullete = false;
        plntEnemy = false;

        health = 1;

      //  GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
        Physics2D.IgnoreLayerCollision(21, 9);
        Physics2D.IgnoreLayerCollision(9, 14);
        Physics2D.IgnoreLayerCollision(24, 9);
        Physics2D.IgnoreLayerCollision(25, 9);
        Physics2D.IgnoreLayerCollision(26, 9);
        instance = this;

        Kill = false;
        coin_one = FindObjectOfType<CoinCounter>();
        lvs = false;

        moveVal = false;



      anim = GetComponent<Animator>();

        
     
    }

   

// Update is called once per frame
void Update()
    {
        characterMovement();
       // Debug.Log("%%%%%%%%%%%%%%%%%%%%%%%%% Jumping %%%%%%%%%%%%%%%%%%%%% " + isJumping);

    }
    void characterMovement()
    {

        // playerMoveX = Input.GetAxis("Horizontal");

     
        Vector3 scale = transform.localScale;
        

        if (playerMoveX < 0.0f)
        {
            scale.x = -0.6f;

          
        }
        else if (playerMoveX > 0.0f)
        {
            scale.x = 0.6f;

           
        }

        transform.localScale = scale;

        //Character Jump


  // if (Input.GetButtonDown("Jump") && isJumping == false)
      if (CrossPlatformInputManager.GetButtonDown("Jump") && isJumping == false)
        {

            //if (Input.GetButtonDown("Jump") && isJumping == false)
            //{
            isJumping = true;
            SoundScript.playsound("jump_Sound");
            Debug.Log("KUDYO");
             gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
         //   Vector2 UpPosition = new Vector2(0, 0.9f);
           // gameObject.GetComponent<Rigidbody2D>().velocity = (UpPosition * jumpForce);
        }
     
        

          //if (Camera_Move.instance.p.x > gameObject.transform.position.x)
          //{



          //}
         playerMoveX = CrossPlatformInputManager.GetAxis("Horizontal");
        
      //  playerMoveX = Input.GetAxis("Horizontal");

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerMoveX * speedPlayer, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        //}







        setAnimationCharacter();
    }

    void setAnimationCharacter()
    {

        anim.SetFloat("Moavement", Mathf.Abs(playerMoveX));

       anim.SetBool("isJumping", isJumping);

        anim.SetBool("gunActive", Gun.instance.gunActive);
        //  anim.SetBool("gunActive", false);

      //  Debug.Log("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%********************^^^^^^^^^^^^^^^^^^^^%%%%%%%%%%%%" + Gun.instance.gunActive);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        foreach (ContactPoint2D hitpoints in collision.contacts)
        {
            if (hitpoints.normal.y > 0 || gameObject.tag == ("Floor") || gameObject.tag == ("CoinBriks"))
            {
                isJumping = false;
                Debug.Log("NA KUDYO");
            }


        }

        if (collision.gameObject.tag == "Turtle")
        {

            foreach (ContactPoint2D hitpoints in collision.contacts)
            {
                if ((hitpoints.normal.x < 0 || hitpoints.normal.x > 0) && Kill == false)
                {
                    Kill = true;
                    gunActive = false;

                }
            }


        }

        if (collision.gameObject.CompareTag("BossBullet") )
        {


            if (Gun.instance.gunActive == true)
            {

                if (health == 1)
                {

                    SoundScript.playsound("Die_Sound");
                    Invoke("gunCall", 1f);
                    coinCall = true;

                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                    GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);


                  //  Debug.Log("############### Helth ####################### " + health);

                }
                else if (health == 2)
                {
                    // Debug.Log("****************** Helth ********************" + health);

                    SoundScript.playsound("Die_Sound");
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
                    SoundScript.playsound("Die_Sound");
                    Player.instance.speedPlayer = 0;
                  //  Player.instance.isJumping = true;
                    Invoke("CallEnemy", 1.5f);
                    bullete = true;
                   // Debug.Log("!!!!!!!!!!!!!!!!!Callldfldfl!!!!!!!!!!!!!!!!!!!!!!!");

                }

            }



        }



        if (collision.gameObject.CompareTag("BossEnemy") && bossTouch == 0)
        {
            bossTouch = 1;
            if (Gun.instance.gunActive == true)
            {

                if (health == 1)
                {

                   SoundScript.playsound("Die_Sound");
                    Invoke("gunCall", 1f);
                    coinCall = true;

                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                    GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);


                   // Debug.Log("############### Helth ####################### " + health);

                }
                else if (health == 2)
                {
                    //  Debug.Log("****************** Helth ********************" + health);
                    //SoundScript.playsound("TurtleJump_2");
                    SoundScript.playsound("Die_Sound");

                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                    GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

                    Player.instance.anim.GetComponent<Animator>().enabled = false;

                    Player.instance.speedPlayer = 0;
                    Player.instance.isJumping = true;
                    Invoke("CallEnemy", 1.5f);
                    // bullete = true;
                }
            }

            if (Gun.instance.gunActive == false)
            {
                if (bullete == false)
                {
                    SoundScript.playsound("Die_Sound");

                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);

                    GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

                    Player.instance.anim.GetComponent<Animator>().enabled = false;

                    Player.instance.speedPlayer = 0;
                    Player.instance.isJumping = true;
                    Invoke("CallEnemy", 1.5f);
                    bullete = true;
                    //Debug.Log("!!!!!!!!!!!!!!!!!Callldfldfl!!!!!!!!!!!!!!!!!!!!!!!");

                }

            }



        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

      

            if (collision.gameObject.CompareTag("checkpoint"))
            {
                 respawnPoint = collision.gameObject.transform.position;
            //respawnPoint = playerObj.transform.position;
            
            }
            if (collision.CompareTag("FallDown"))
            {
                Vector3 pos = respawnPoint;
                pos.z = -10f;
                cam.transform.position = pos;
                //   respawnPoint.z = respawnPoint.z + 1f;
               transform.position = respawnPoint;
            CoinCounter.instance.livesCounter(coins);
            }


        if (collision.CompareTag("FallDown"))
        {

        }


        }
    void gunCall()
    {

        bossTouch = 0;
        health = 2;

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
