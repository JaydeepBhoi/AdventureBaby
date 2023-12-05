using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChar : MonoBehaviour
{
    public Sprite emptyBlockSprite,emptysecondSprite;
    public GameObject playerCHar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCHar.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800f);
            gameObject.GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
            // StartCoroutine(changeImg());
           
           
        }
       
       

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = emptysecondSprite;
       
    }

    //IEnumerator changeImg()
    //{
    //    yield return new WaitForSeconds(2f);
    //    
    //}
}
