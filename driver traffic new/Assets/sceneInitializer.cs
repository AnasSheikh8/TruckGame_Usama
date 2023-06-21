using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sceneInitializer : MonoBehaviour
{
    public GameObject village;
    public GameObject Mountain;
    public GameObject wholeScene;
    public GameObject villageAI;
    public GameObject MountainAI;

    public GameObject Levels;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        
        envInIt();

    }



    void envInIt()
    {
        
        if (ScenesManager.instance.currentMode == 1)
        {
            if (ScenesManager.instance.currentLevel == 7 || ScenesManager.instance.currentLevel == 8 || ScenesManager.instance.currentLevel == 3)
            {
                Mountain.SetActive(true);
                village.SetActive(false);
                MountainAI.SetActive(true);
            }
            else
            {
                Mountain.SetActive(false);
                village.SetActive(true);
                villageAI.SetActive(true);
            }

            //seperation.SetActive(true);
            Levels.SetActive(true);
        }

        else
        {
            Mountain.SetActive(true);
            village.SetActive(true);
            MountainAI.SetActive(true);
            villageAI.SetActive(true);


            GameObject.Find("wallMountain").SetActive(false);
            GameObject.Find("wallVillage (4)").SetActive(false);

            Levels.SetActive(false);
        }

        //yield return new WaitForSeconds(0.1f);

        //wholeScene.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
       
        
    }
}
