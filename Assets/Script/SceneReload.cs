
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneReload : MonoBehaviour
{
    public GameObject player;
    public int var;
    // Start is called before the first frame update

    public int coinValue;
    public static SceneReload instance = null;
    void Start()
    {

        instance = this;

        //if (PlayerPrefs.GetInt("Lives") <= 0)
        //{
        //    //Debug.Log("hfhfghfghfhfghf" + PlayerPrefs.SetInt("Lives",3));
        //  ///  PlayerPrefs.SetInt("Lives", 2);
        //  PlayerPrefs.DeleteAll();
        //}

      //  GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);

        player = GameObject.Find("Mario");
    }

    // Update is called once per frame
    void Update()
    {




    }

    public void reloadData()
    {
       int  nextSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(nextSceneIndex + 1);


        //SceneManager.LoadScene("Jd_level4");
        Debug.Log("Invokecalllllfldlfdlfdlfld");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Invoke("reloadData", 0.5f);
            Debug.Log("ggggggggggggggggggggg");

            //SceneManager.LoadScene("Mario_Level_1");
            //coinValue = PlayerPrefs.GetInt("Lives");
            //CoinCounter.instance.livesCounter(PlayerPrefs.GetInt("Lives", coinValue));





        }

      


        if (collision.gameObject.CompareTag("checkpoint"))
        {

            //  respawnPoint = collision.transform.position;
        }
    }
}
