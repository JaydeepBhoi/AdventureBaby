using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    // Start is called before the first frame update

    public static CoinCounter instance;
    public TextMeshProUGUI text,textLives,gameOverText;
 
    public int score;
    public int coinValue;


    public int livescount=300;

    public int countScene;
    

    void Start()
    {
       livescount = PlayerPrefs.GetInt("Lives", livescount);
        PlayerPrefs.SetInt("Lives", livescount);
        textLives.text = "X" + livescount.ToString();


        if (instance == null)
        {
            instance = this;
        }

       
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScore( int coinValue)
    {
        score += coinValue;
        text.text = "X" + score.ToString();
    }

    public void livesCounter(int countVal)
    {

       


        if (livescount != 0)
        {

           
            livescount--;
            PlayerPrefs.SetInt("Lives", livescount);
            PlayerPrefs.Save();
        }
        if (PlayerPrefs.GetInt("Lives") == 0)
        {
            countScene++;
            PlayerPrefs.DeleteAll();
            gameOverText.text = "Game Over";
          //  SceneReload.instance.reloadData();
            Invoke("recall", 1f);
        }


          


        textLives.text = "X" + livescount.ToString();


    }

    void recall()
    {

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(nextSceneIndex);
       // SceneReload.instance.reloadData();
    }
}
