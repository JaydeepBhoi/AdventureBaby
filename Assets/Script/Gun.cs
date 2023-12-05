using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public static Gun instance=null;
    public  bool gunActive;
    public bool EnemyActive;
    GameObject gmPlayer;
    EnemyBullete Eb;
    void Start()
    {
      //  anim = GetComponent<Animator>();

        instance = this;
        gunActive = false;
        gmPlayer = GameObject.FindGameObjectWithTag("Player");

        Eb = FindObjectOfType<EnemyBullete>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
       // Debug.Log("Triger");
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundScript.playsound("Gun_Get");

            gunActive = true;

          //  Debug.Log("<<<<<<<<Active>>>>>>>>" + gunActive);
            Destroy(gameObject);

          

            //anim.SetBool("gunActive", Gun.instance.gunActive);
        }

        
        
    }
}
