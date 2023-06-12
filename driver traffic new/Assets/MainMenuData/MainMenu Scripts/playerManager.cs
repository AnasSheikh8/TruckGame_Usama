using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerManager : MonoBehaviour
{
    public GameObject[] trucksList;
    public int truckSelected;

    //public RCC_Camera RCC_Camera_Object;

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

        /*
        if (trucksList[2].activeInHierarchy)
        {
            Debug.Log("true");

            RCC_Camera_Object.TPSMinimumFOV = 71;
            RCC_Camera_Object.TPSMaximumFOV = 71;
            RCC_Camera_Object.TPSPitch = 23.6f;
            RCC_Camera_Object.TPSDistance = 19.4f;
            RCC_Camera_Object.TPSHeight = 6;


            RCC_Camera_Object.TPSOffset = new Vector3(0, 1.34f, 7.61f);

        }
        else
        {
            Debug.Log("false");

        }

        */


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        //Debug.Log(truckSelected);
    }
}
