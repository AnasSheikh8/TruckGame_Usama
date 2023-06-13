using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{


    int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void replayLevel()
    {
        //ScenesManager.instance.currentLevel;
        SceneManager.LoadScene(2);
    }

    public void nextLevel()
    {
       currentLevel= ScenesManager.instance.currentLevel++;
        if (currentLevel > PlayerPrefs.GetInt("levelsPassed"))
        {
            PlayerPrefs.SetInt("levelsPassed", currentLevel);

        }
        else 
        { 
        }
        SceneManager.LoadScene(2);
    }


}
