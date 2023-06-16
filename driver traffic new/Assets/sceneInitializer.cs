using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneInitializer : MonoBehaviour
{
    public GameObject village;
    public GameObject Mountain;
    public GameObject wholeScene;
    public GameObject villageAI;
    public GameObject MountainAI;
    // Start is called before the first frame update
    void Start()
    {

        envInIt();

    }



    void envInIt()
    {
        if (ScenesManager.instance.currentLevel == 7 || ScenesManager.instance.currentLevel == 8 || ScenesManager.instance.currentLevel == 3)
        {
            Instantiate(Mountain);
            MountainAI.SetActive(true);
        }
        else
        {
            Instantiate(village);
            villageAI.SetActive(true);
        }

        //yield return new WaitForSeconds(0.1f);

        //wholeScene.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
