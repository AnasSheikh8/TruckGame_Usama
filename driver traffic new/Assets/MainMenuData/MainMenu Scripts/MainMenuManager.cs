using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{

    public GameObject[] trucksSpecs;
    public GameObject[] trucksList;
    public int[] trucksRateList;
    public int thisTruckRate;
    int nowShowingTruck=0;
    public GameObject lockScreen;
    public static MainMenuManager instance;
    public Text popUpTxt;
    public GameObject popUp;
    public Text truckRateText;
    public int coinsAvailable;
    public Text PopUpHeader;
    public Text coinsAvailableTxt;
    // Start is called before the first frame update
    public GameObject[] missions;
    public GameObject[] locks;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);   
        }

    }



    void Start()
    {
        Time.timeScale = 1;

        //For Testing

        /*PlayerPrefs.SetInt("purchased2", 0);
        PlayerPrefs.SetInt("purchased1", 0);
        */
        if (PlayerPrefs.GetInt("coins") == 0)
        {
            PlayerPrefs.SetInt("coins", 5000);
        }

        //For testing





        int levelsPassed= PlayerPrefs.GetInt("levelsPassed");
        for(int i=0; i <= levelsPassed+1; i++) 
        {


            missions[i].GetComponent<Button>().enabled = true;
            if (i != 0)
            {
                locks[i].SetActive(false);

            }
        }


        for (int i=0; i<trucksList.Length; i++)
        {
            if (i == 0)
            {
                trucksList[0].SetActive(true);
                trucksSpecs[0].SetActive(true);
            }
            else
            {
                trucksList[i].SetActive(false);

                trucksSpecs[i].SetActive(false);
            }

        }
    }


    public void nextBtn()
    {


        if (nowShowingTruck < trucksList.Length-1)
        {
            nowShowingTruck++;
            //trucksList[nowShowingTruck].SetActive(true);

            //trucksList[nowShowingTruck--].SetActive(false);


            

        }
        else
        {
            nowShowingTruck = 0;
        }


        for (int i = 0; i < trucksList.Length; i++)
        {
            if (i == nowShowingTruck)
            {
                trucksList[i].SetActive(true);
                trucksSpecs[i].SetActive(true);
            }
            else
            {
                trucksList[i].SetActive(false);

                trucksSpecs[i].SetActive(false);
            }
        }
    }

    public void PrevBtn()
    {

        if (nowShowingTruck > 0)
        {
            nowShowingTruck--;


            
        }
        else
        {
            nowShowingTruck = 2;
        }



        for (int i = 0; i < trucksList.Length; i++)
        {
            if (i == nowShowingTruck)
            {
                trucksList[i].SetActive(true);
                trucksSpecs[i].SetActive(true);
            }
            else
            {
                trucksList[i].SetActive(false);
                trucksSpecs[i].SetActive(false);
            }
        }

    }




    public void SelectBtn()
    {

        ScenesManager.instance.truckSelected = nowShowingTruck;

        SceneManager.LoadScene(1);
    }




    public void OpenWorldSceneButton()
    {

        ScenesManager.instance.truckSelected = nowShowingTruck;
        ScenesManager.instance.currentMode = 0;
        SceneManager.LoadScene(1);
    }




    public void MissionBasedSceneButton()
    {
        ScenesManager.instance.currentMode = 1;
    }

    public void SelectedLevel(int levelNum)
    {
        ScenesManager.instance.currentLevel = levelNum;
    }



    public void GameExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

        coinsAvailable = PlayerPrefs.GetInt("coins");

        coinsAvailableTxt.text="" + coinsAvailable;

        if(nowShowingTruck>0)
        {
            if (PlayerPrefs.GetInt("purchased" + nowShowingTruck) != 1)
            {
                lockScreen.SetActive(true);
            }
            else
            {
                lockScreen.SetActive(false);
            }
                
        }
        else
        {
            lockScreen.SetActive(false);
        }


        truckRateManager();



       // Debug.Log("Showing Truck=" + nowShowingTruck);
    }



    public void buyButton()
    {
        if (PlayerPrefs.GetInt("coins") >= thisTruckRate)
        {
            popUp.SetActive(true);
            lockScreen.SetActive(false);
            PlayerPrefs.SetInt("purchased"+nowShowingTruck, 1);
            PopUpHeader.text = "Unlocked!";
            popUpTxt.text = "New Truck Unlocked By " + thisTruckRate + " Coins!";
            PlayerPrefs.SetInt("coins", coinsAvailable - thisTruckRate);
        }
        else
        {
            popUp.SetActive(true);
            PopUpHeader.text = "Insufficient Coins!";
            popUpTxt.text = "Need More Coins To Unlock This Truck :(";
        }

    }



    public void truckRateManager()
    {
        if (nowShowingTruck != 0)
        {
            
            thisTruckRate = trucksRateList[nowShowingTruck];
            truckRateText.text = "" + thisTruckRate;

        }

    }
}
