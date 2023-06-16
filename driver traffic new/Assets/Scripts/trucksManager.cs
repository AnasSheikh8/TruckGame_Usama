using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class trucksManager : MonoBehaviour
{
    public GameObject[] trucksList;
    public int truckSelected;

    public GameObject gamePausedPanel;

    // Start is called before the first frame update
    void Start()
    {




        truckSelected = ScenesManager.instance.truckSelected;


        for(int i=0; i<trucksList.Length; i++)
        {
            if (i == truckSelected)
            {


                trucksList[i].SetActive(true);
            }
            else
            {
                trucksList[i].SetActive(false);
            }

        }



        

    }


    public void resumeBtn()
    {
        Time.timeScale = 1;
        gamePausedPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {


        



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(0);
            Time.timeScale = 0;
            gamePausedPanel.SetActive(true);
        }

        //Debug.Log(truckSelected);
    }
}
