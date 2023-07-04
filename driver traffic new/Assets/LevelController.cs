using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{


    int currentLevel;
    public GameObject nextBtn;
    // Start is called before the first frame update
    void Start()
    {

        if (ScenesManager.instance.currentLevel >= 9)
        {
            nextBtn.SetActive(false);


        }
        else
        {
            nextBtn.SetActive(true);

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void replayLevel()
    {
        //ScenesManager.instance.currentLevel;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Instance.GetInstance().my_AdManager.hideBigBanner();
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

        Instance.GetInstance().my_AdManager.hideBigBanner();

    }



    public void homeBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Instance.GetInstance().my_AdManager.showBigBanner();
    } 

}
