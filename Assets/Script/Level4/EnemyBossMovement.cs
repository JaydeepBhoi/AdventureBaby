using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossMovement : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = true;

    Vector3 pos, localScale;

  //  public GameObject player;

    private float moveX;
    public bool fly = false;

    public GameObject[] enemyLife;

    public bool beeEnemy, bullete;

    public bool startEnemy, coinCall, stopEnemy,bulleteTouch;
    int coins = 3;
    int healthEffectVar, health;

    public int counter;
   
    void Start()
    {
        Physics2D.IgnoreLayerCollision(23, 22);
        startEnemy = false;
        stopEnemy = true;
        coinCall = false;
        beeEnemy = false;
        moveX = transform.position.x;
        pos = transform.position;

        localScale = transform.localScale;
        bullete = false;
        bulleteTouch = false;
        counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
            CheckWhereToFace();

            if (facingRight)
                MoveRight();
            else
                MoveLeft();
        


    }

    void CheckWhereToFace()
    {
        if (pos.x < moveX - 8)
        {
            facingRight = true;
            //  FireBallCreate.instance.canShoot = false;
        }

        else if (pos.x > moveX)
        {
            facingRight = false;
            //   FireBallCreate.instance.canShoot = true;
        }


        if (((!facingRight) && (localScale.x < 0)) || ((facingRight) && (localScale.x > 0)))
            localScale.x *= -1;






        transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
       // EnemyBsJump.instance.canShoot = false;
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
       // EnemyBsJump.instance.canShoot = true;
    }




    void callBox()
    {
      //  Destroy(Player.instance.gameObject.GetComponent<BoxCollider2D>());

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
          //  Debug.Log("!!!!!!!&&&&&&&& Counter &&&&&&&&&&&" );

            if (facingRight)
                MoveRight();
            else
                MoveLeft();
        }
        if (collision.gameObject.CompareTag("gunshoot"))
        {
           

            if (bulleteTouch == false)
            {
                
                //SoundScript.playsound("Die_Sound");

                if (counter == 1)
                {
                    // counter = 2;
                    bulleteTouch = true;
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                    Debug.Log("Counter" + counter);
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

                    Invoke("BulleteUse", 0.5f);
                }
                else if (counter == 2)
                {
                    //counter = 3;
                    bulleteTouch = true;
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                  
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                    Invoke("BulleteUse", 0.5f);
                }
                else if (counter == 3)
                {
                    //counter = 2;
                    bulleteTouch = true;
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                   
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                    Invoke("BulleteUse", 0.5f);
                }
                else if (counter == 4)
                {
                    // counter = 2;
                    bulleteTouch = true;
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                   
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                    Invoke("BulleteUse", 0.5f);
                }
                else if (counter == 5)
                {
                    // counter = 2;
                    bulleteTouch = true;
                    Invoke("BulleteUse", 0.5f);
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                   
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                    Invoke("BulleteUse", 0.5f);
                }
                else if (counter == 6)
                {
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                   
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                    bulleteTouch = true;
                    Invoke("BulleteUse", 0.5f);
                    //moveSpeed = 0;
                    //frequency = 0;
                    //magnitude = 0;


                    //Destroy(gameObject.GetComponent<BoxCollider2D>());

                }
                else if (counter == 7)
                {
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
             
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                    bulleteTouch = true;
                    Invoke("BulleteUse", 0.5f);
                    //moveSpeed = 0;
                    //frequency = 0;
                    //magnitude = 0;


                    //Destroy(gameObject.GetComponent<BoxCollider2D>());

                }
                else if (counter == 8)
                {
                    healthEffectVar = 10;
                    InvokeRepeating("HealthEffect", 0.3f, 0.1f);
                  
                    GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
                    bulleteTouch = true;

                    //moveSpeed = 0;
                    //frequency = 0;
                    //magnitude = 0;

                    enemyLife[0].SetActive(false);
                    //Destroy(gameObject.GetComponent<BoxCollider2D>());
                    Destroy(gameObject);
                }

            }
            
        }
          
    }


    void BulleteUse()
    {
       
        bulleteTouch = false;
        enemyLife[8-counter].SetActive(false);
        counter++;
    }

    void HealthEffect()
    {

        healthEffectVar--;

        if (healthEffectVar % 2 == 0)
        {
            GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            GameObject.Find("BossEnemy").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.6f);
        }
        if (healthEffectVar == 0)
        {

            CancelInvoke("HealthEffect");
        }

    }
}
