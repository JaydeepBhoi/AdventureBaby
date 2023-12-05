using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{

    // Start is called before the first frame update
    public float bounceSpeed = 4.0f;
    public float bounceHeight = 2;
    public bool canBounce = true;
    // public bool exitBounce = false;
    public Vector2 OriginalPosition;

    public Sprite emptyBlockSprite;
    public int Counter;
    //int CoinValue = 5;


    public float coinMoveSpeed = 5f;
    public float coinHeight = 0.2f;
    public float coinDistance = 2f;

    public GameObject coins;
    private GameObject spiningCoin;

    private int coinValue = 1;
   // public GameObject guns;
    void Start()
    {
        OriginalPosition = transform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BriksBounce()
    {


        if (canBounce == true)
        {
            //  exitBounce = true;
            canBounce = false;
            StartCoroutine(BriksBank());


        }


    }

    void coinCreation()
    {
        spiningCoin = (GameObject)Instantiate(coins);
        spiningCoin.transform.SetParent(this.transform.parent);
        spiningCoin.transform.localPosition = new Vector2(OriginalPosition.x, OriginalPosition.y + 1);

        StartCoroutine(moveCoin(spiningCoin));
    }

    IEnumerator moveCoin(GameObject coin)
    {

        while (true)
        {
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x, coin.transform.localPosition.y + coinMoveSpeed * Time.deltaTime);

            if (coin.transform.localPosition.y >= OriginalPosition.y + coinHeight + 1)
            {
                transform.localPosition = OriginalPosition;
                break;

            }
            yield return null;
        }

        //while (true)
        //{
        //    coin.transform.localPosition = new Vector2(coin.transform.localPosition.x, coin.transform.localPosition.y - coinMoveSpeed * Time.deltaTime);

        //    if (coin.transform.localPosition.y <= OriginalPosition.y + coinHeight + 1)
        //    {
        //        // Destroy(coin.gameObject);
        //        break;

        //    }
        //    yield return null;
        //}

    }

    IEnumerator BriksBank()
    {
        coinCreation();


        while (true)
        {

            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);

            if (transform.localPosition.y >= OriginalPosition.y + bounceHeight)
            {

                break;
            }
            yield return null;


        }

        while (true)
        {

            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);

            if (transform.localPosition.y <= OriginalPosition.y)
            {



                transform.localPosition = OriginalPosition;
                // gameObject.GetComponent<Renderer>().material.color = Color.green;
                GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
             //   CoinCounter.instance.changeScore(coinValue);
                break;
            }

            yield return null;


        }

    }




    //private void OnCollisionExit2D(Collision2D collision)
    //{

    //    if (exitBounce == true)
    //    {

    //        exitBounce = false;
    //        // CoinCounter.instance.changeScore(CoinValue);
    //        canBounce = true;
    //        Counter += 1;
    //        Debug.Log("Counter=" + Counter);
    //        if (Counter >= 1)
    //        {

    //            canBounce = false;
    //            gameObject.GetComponent<Renderer>().material.color = Color.green;
    //        }

    //    }

    //}



    private void OnCollisionEnter2D(Collision2D collision)
    {


        foreach (ContactPoint2D hitPoints in collision.contacts)
        {
           // Debug.Log("Colide(X,Y)=" + hitPoints.normal);
            if (collision.gameObject.tag == "Player")
            {
                if (hitPoints.normal.y > 0)
                {
                  //  Debug.Log("Colide");
                    BriksBounce();

                    // Debug.Log("jumooooooo"+ jumpbool);


                }
            }

           



        }
    }
}
