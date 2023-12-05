using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    public float curentTime = 0f;
    public float startingTime = 1f;

    public float data=10;
    [SerializeField] Text text;


    public static Timer instance;
    public GameObject[] selectorArr;

    public GameObject gm;
    public GameObject player;
    public bool stopEnemy=true;
    public int coinValue;
    //public List<GameObject> selectorArr;
    public int count;
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }


        curentTime = startingTime;

       // selectorArr = new GameObject[numSelectors];
        Debug.Log("Call Array");

    }

    // Update is called once per frame
    void Update()
    {

        curentTime += 1 * Time.deltaTime;

        text.text = curentTime.ToString("0");

        if (curentTime >= 5)
        {
            count++;
            curentTime = 1;
            if (count <= 10 && count >=1)
            {
                selectorArr[10 - count].SetActive(false);
            }

            if (count == 10)
            {

              //  SceneManager.LoadScene("Jd_level4");
                coinValue = PlayerPrefs.GetInt("Lives");
                

                CoinCounter.instance.livesCounter(PlayerPrefs.GetInt("Lives", coinValue));

          //      player.transform.localPosition = new Vector2(player.transform.localPosition.x, player.transform.localPosition.y + 90 * Time.deltaTime);
          //     Destroy(player.GetComponent<BoxCollider2D>());
            }

       }



    }



    public void Enemy()
    {
        
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(2f);
        stopEnemy = false;


    }


}
