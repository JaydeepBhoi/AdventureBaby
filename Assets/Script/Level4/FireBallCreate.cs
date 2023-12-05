
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FireBallCreate : MonoBehaviour
{


    public bool canShoot;
    public Vector2 offset;
    public GameObject Enemy;
    public Rigidbody2D FireRigitbody;
    public Transform FireTranform;
    Rigidbody2D newfirebody;
    public float cooldown;
    public GameObject bulete;
   
    public  Vector2 velocity;
    
    void Start()
    {
        cooldown = 1f;
        canShoot = true;
        offset = new Vector2(0.8f, 2);
      //  bossEnemy = GameObject.FindGameObjectWithTag("BossEnemy");

    }

    // Update is called once per frame
    void Update()
    {
       
           if(canShoot)
            {

           
            newfirebody = Instantiate(FireRigitbody, gameObject.transform.position, Quaternion.identity);

           // SoundScript.playsound("Bullet_Sound");

            if (gameObject.transform.localScale.x>0)
            {

                newfirebody.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f , newfirebody.transform.position.y + 4);
              
            }
            else if (gameObject.transform.localScale.x < 0)
            {
                newfirebody.GetComponent<Rigidbody2D>().velocity = new Vector2(10f , newfirebody.transform.position.y + 4);
               
            }

                
            newfirebody.GetComponent<SpriteRenderer>().sortingOrder = 10;
        

            StartCoroutine(CanShoot());










        }





       


    }


    IEnumerator CanShoot()
    {

        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //}
}