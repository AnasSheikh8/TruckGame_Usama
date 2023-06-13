using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class trucksManager : MonoBehaviour
{
    public GameObject[] trucksList;
    public int truckSelected;

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

    // Update is called once per frame
    void Update()
    {


        



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        //Debug.Log(truckSelected);
    }
}
