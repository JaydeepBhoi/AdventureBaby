
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Gunshoot : MonoBehaviour
{

    public GameObject projectile, Player, go;
    public Vector2 velocity;
    bool canShoot = true;
    public Vector2 offset;
    public float cooldown = 0.5f;
    public int countEnergy;

    public SortingLayer sort;

    public GameObject turtleEnemy;

    // Use this for initialization
    void Start()
    {

        offset = new Vector2(0.8f, 2);
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
       // if (Gun.instance.gunActive == true)
        {
     // if (CrossPlatformInputManager.GetButtonDown("Fire1") && canShoot && Gun.instance.gunActive==true)

          if (Input.GetKeyDown(KeyCode.T) && canShoot && Gun.instance.gunActive == true)
            {
                    Debug.Log("Hi....");
                countEnergy++;

                //go = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.position.x, Quaternion.identity);
                go = (GameObject)Instantiate(projectile, GameObject.Find("FirePos").transform.position, Quaternion.identity);

         
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * Player.transform.localScale.x, velocity.y);
                StartCoroutine(CanShoot());
                SoundScript.playsound("Bullet_Sound");

                

                //    Timer.instance.selectorArr[10 - (Timer.instance.count)].SetActive(false);
                //    Timer.instance.count++;
                //    Timer.instance.curentTime = 1;
                //Debug.Log("Shooooooot" + countEnergy);





            }

       }
       



        IEnumerator CanShoot()
        {
            
            canShoot = false;
            yield return new WaitForSeconds(cooldown);
            canShoot = true;
            Destroy(go);


        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Turtle")
        {
            Destroy(go);
           
        }

        if (collision.gameObject.tag == "plantEnemy")
        {
            Destroy(go);


        }


        if (collision.gameObject.tag == "spider")
        {
            Destroy(go);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spider")
        {
            Destroy(go);


        }
    }
}