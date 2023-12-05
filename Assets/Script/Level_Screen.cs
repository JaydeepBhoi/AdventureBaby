using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Screen : MonoBehaviour
{
    // Start is called before the first frame update
      public Button[] LEVELS;
    void Start()
    {
         
     for (int i = 0; i<LEVELS.Length; i++)
        {
            int closureIndex = i;
           Button btns = LEVELS[i].GetComponent<Button>();
            LEVELS[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick(int buttonIndex)
    {
        SceneManager.LoadScene(buttonIndex + 1, LoadSceneMode.Single);

    }
}
