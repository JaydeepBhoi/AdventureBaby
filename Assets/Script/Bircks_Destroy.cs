 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bircks_Destroy : MonoBehaviour
{
    // Start is called before the first frame update

    private ParticleSystem particle;
    private SpriteRenderer sr;
    public GameObject briksBroken;
    public GameObject brik;
    void Start()
    {
        
    }

    // Update is called once per frame


    private void Awake()
    {
       // particle = GetComponentInChildren<ParticleSystem>();

        sr = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {

            if (collision.contacts[0].normal.y > 0)
            {




                ///    gameObject.GetComponent<SpriteRenderer>().enabled = false;

                // Debug.Log("gameObject--->>>" + gameObject);
                //   StartCoroutine(Broke());
                ////  gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //// sr.enabled = false;
                SoundScript.playsound("BrickDestroy_Sound");
                Destroy(gameObject);
                GameObject newwa = Instantiate(briksBroken, transform.position, Quaternion.identity) as GameObject;
                Destroy(newwa, 1f);
                
                     
            }
        }

    }

    IEnumerator Broke()
    {
        //   particle.GetComponent<ParticleSystemRenderer>().sortingOrder = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().sortingOrder+1;
        //particle.Play();
        //Instantiate(briksBroken, transform.position, Quaternion.identity);

        /////gameObject.GetComponent
        ///<SpriteRenderer>().enabled = false;


     
        
        yield return new WaitForSeconds(0.1f);
        //   Destroy(sr);
        
      //  Debug.Log("Call");
    }
}
