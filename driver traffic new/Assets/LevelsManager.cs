using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelsManager : MonoBehaviour
{

    public GameObject[] LevelsStarting;
    public GameObject[] LevelsDestination;
    public GameObject[] LevelsTruckInitPoint;
    public GameObject[] LevelsPlayerInitPoint;
    public GameObject player;
    public GameObject BlackPanel;

    public GameObject[] boxesPref;
    public Transform container;

    public GameObject[] LevelCameras;


    public Transform[] truckLoadingPoints;


    public Animator craneAnim;
    public GameObject floorPerson;
    public GameObject gameCanvas;

    public GameObject[] locationSignsSP;
    public GameObject levelPass;
    public Animator CharacterAnimator;
    int currentLevel;

    public GameObject[] DirectionArrowsOfLevel;

    public GameObject phone;
    public GameObject level5Cow;
    public GameObject idleCows;

    public GameObject popUp;
    public Text popUpText;


    public int[] rewards;

    //bool level1spCollided;


    // Start is called before the first frame update
    void Start()
    {





        currentLevel = ScenesManager.instance.currentLevel;
        craneAnim.enabled = false;
        floorPerson.SetActive(false);



        if (currentLevel == 2)
        {
            popUpShow("Insufficient fuel for upcoming missions, arrows are telling the way to petrol pump.");
        }
        else if(currentLevel==4)
        {
            
        }
        else
        {
            popUpShow("Pick the truck, and park it into the pinned location.");
        }


        if (currentLevel == 4)
        {
            BlackPanel.SetActive(true);

        }

        for (int i=0; i<LevelsStarting.Length; i++)
        {
            if (i == currentLevel)
            {
                
                    
                LevelsStarting[i].SetActive(true);
                    
                gameObject.transform.position = LevelsTruckInitPoint[i].transform.position;
                gameObject.transform.rotation = LevelsTruckInitPoint[i].transform.rotation;


                player.transform.position = LevelsPlayerInitPoint[i].transform.position;
                player.transform.rotation = LevelsPlayerInitPoint[i].transform.rotation;



            }
            else
            {
                LevelsStarting[i].SetActive(false);
            }
            
        }


        for (int i = 0; i < LevelsDestination.Length; i++)
        {
            
                
            LevelsDestination[i].SetActive(false);
            

        }


        if (currentLevel == 1)
        {
            StartCoroutine(lv2StartCutScene());

        }
        else if (currentLevel==2)
        {
            StartCoroutine(lv3StartCutScene());

        }


        level5Cow.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("level1sp"))
        {
            StartCoroutine(level1sp());
        }

        if (other.CompareTag("level1dp"))
        {
            StartCoroutine(level1dp());

        }

        if (other.CompareTag("level2sp"))
        {
            StartCoroutine(level2sp());
        }

        if (other.CompareTag("level2dp"))
        {
            StartCoroutine(level2dp());

        }


        if (other.CompareTag("level3sp"))
        {
            StartCoroutine(level3sp());
        }

        if (other.CompareTag("level3dp"))
        {
            StartCoroutine(level3dp());

        }



        if (other.CompareTag("level4sp"))
        {
            StartCoroutine(level4sp());
        }

        if (other.CompareTag("level4dp"))
        {
            StartCoroutine(level4dp());

        }




        if (other.CompareTag("level5sp"))
        {
            StartCoroutine(level5sp());
        }

        if (other.CompareTag("level5dp"))
        {
            StartCoroutine(level5dp());

        }



        if (other.CompareTag("level6sp"))
        {
            StartCoroutine(level6sp());
        }

        if (other.CompareTag("level6dp"))
        {
            StartCoroutine(level6dp());

        }




        if (other.CompareTag("level7sp"))
        {
            StartCoroutine(level7sp());
        }

        if (other.CompareTag("level7dp"))
        {
            StartCoroutine(level7dp());

        }



        if (other.CompareTag("level8sp"))
        {
            StartCoroutine(level8sp());
        }

        if (other.CompareTag("level8dp"))
        {
            StartCoroutine(level8dp());

        }





        if (other.CompareTag("level9sp"))
        {
            StartCoroutine(level9sp());
        }

        if (other.CompareTag("level9dp"))
        {
            StartCoroutine(level9dp());

        }



        if (other.CompareTag("level10sp"))
        {
            StartCoroutine(level10sp());
        }

        if (other.CompareTag("level10dp"))
        {
            StartCoroutine(level10dp());

        }







    }






    IEnumerator lv2StartCutScene()
    {

        gameCanvas.SetActive(false);

        CharacterAnimator.SetBool("calling", true);
        LevelCameras[1].SetActive(true);
        phone.SetActive(true);
        yield return new WaitForSeconds(10f);

        LevelCameras[1].SetActive(false);
        yield return new WaitForSeconds(9f);

        CharacterAnimator.SetBool("calling", false);
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(1f);

        phone.SetActive(false);
        BlackPanel.SetActive(false);
        gameCanvas.SetActive(true);

    }


    IEnumerator lv3StartCutScene()
    {

        gameCanvas.SetActive(false);

        //CharacterAnimator.SetBool("calling", true);
        LevelCameras[2].SetActive(true);
        //phone.SetActive(true);
        yield return new WaitForSeconds(17f);


        LevelCameras[2].SetActive(false);

        //CharacterAnimator.SetBool("calling", false);
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(1f);

        //phone.SetActive(false);
        BlackPanel.SetActive(false);
        gameCanvas.SetActive(true);

        DirectionArrowsOfLevel[2].SetActive(true);
    }






    IEnumerator level1dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }


    IEnumerator level1sp()
    {

       
        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward (0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[0].position;
        gameObject.transform.rotation = truckLoadingPoints[0].rotation;
        LevelsStarting[0].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[0].SetActive(false);
        LevelCameras[0].SetActive(true);

        yield return new WaitForSeconds(2);


            BlackPanel.SetActive(false);
            craneAnim.enabled = true;
            yield return new WaitForSeconds(14);
            BlackPanel.SetActive(true);

            yield return new WaitForSeconds(1);
            BlackPanel.SetActive(false);


            Instantiate(boxesPref[0], container);

            

            LevelCameras[0].SetActive(false);

        gameCanvas.SetActive(true);


        yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[0].SetActive(true);

        DirectionArrowsOfLevel[0].SetActive(true);
        popUpShow("Follow the arrows to take the boxes to the destination");
    }



    IEnumerator level2sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);
        
        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[1].position;
        gameObject.transform.rotation = truckLoadingPoints[1].rotation;
        LevelsStarting[1].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[1].SetActive(false);
        //LevelCameras[1].SetActive(true);

        //yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        //yield return new WaitForSeconds(14);
        //BlackPanel.SetActive(true);

        //yield return new WaitForSeconds(1);
        //BlackPanel.SetActive(false);


        Instantiate(boxesPref[1], container);



        //LevelCameras[1].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[1].SetActive(true);

        DirectionArrowsOfLevel[1].SetActive(true);
        popUpShow("Deliver vegitables to the market.");
    }


    IEnumerator level2dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }
















    IEnumerator level3sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f); 
        
        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[2].position;
        gameObject.transform.rotation = truckLoadingPoints[2].rotation;
        LevelsStarting[2].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[2].SetActive(false);
        //LevelCameras[1].SetActive(true);

        //yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        //yield return new WaitForSeconds(14);
        //BlackPanel.SetActive(true);

        //yield return new WaitForSeconds(1);
        //BlackPanel.SetActive(false);





        //LevelCameras[1].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[2].SetActive(true);



        DirectionArrowsOfLevel[2].SetActive(false);
        DirectionArrowsOfLevel[10].SetActive(true);

        popUpShow("Now we have enough fuel, let's park the truck");
    }


    IEnumerator level3dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }

















    IEnumerator level4sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[3].position;
        gameObject.transform.rotation = truckLoadingPoints[3].rotation;
        LevelsStarting[3].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[3].SetActive(false);
        LevelCameras[3].SetActive(true);

        yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        floorPerson.SetActive(true);
        yield return new WaitForSeconds(5f);
        BlackPanel.SetActive(true);

        //Instantiate(boxesPref[2], container);
        yield return new WaitForSeconds(1);
        floorPerson.SetActive(false);

        BlackPanel.SetActive(false);




        Instantiate(boxesPref[3], container);
        LevelCameras[3].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[3].SetActive(true);

        DirectionArrowsOfLevel[3].SetActive(true);
        popUpShow("Drop wheat bags to the farm.");
    }


    IEnumerator level4dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }














    IEnumerator level5sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[4].position;
        gameObject.transform.rotation = truckLoadingPoints[4].rotation;
        LevelsStarting[4].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[4].SetActive(false);
        LevelCameras[4].SetActive(true);

        yield return new WaitForSeconds(0.1f);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        yield return new WaitForSeconds(7);
        BlackPanel.SetActive(true);

        yield return new WaitForSeconds(1);
        BlackPanel.SetActive(false);





        LevelCameras[4].SetActive(false);

        level5Cow.SetActive(true);
        yield return new WaitForSeconds(3);


        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(1);


        level5Cow.SetActive(false);
        idleCows.SetActive(false);
        Instantiate(boxesPref[4], container);
        yield return new WaitForSeconds(0.3f);

        BlackPanel.SetActive(false);



        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[4].SetActive(true);
        DirectionArrowsOfLevel[4].SetActive(true);

        popUpShow("Cows are loaded in the truck, take the cows to the fields.");

    }


    IEnumerator level5dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }





    IEnumerator level6sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[5].position;
        gameObject.transform.rotation = truckLoadingPoints[5].rotation;
        LevelsStarting[5].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[5].SetActive(false);
        //LevelCameras[1].SetActive(true);

        //yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        //yield return new WaitForSeconds(14);
        //BlackPanel.SetActive(true);

        //yield return new WaitForSeconds(1);
        //BlackPanel.SetActive(false);





        //LevelCameras[1].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[5].SetActive(true);
        DirectionArrowsOfLevel[5].SetActive(true);


    }


    IEnumerator level6dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }




















    IEnumerator level7sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[6].position;
        gameObject.transform.rotation = truckLoadingPoints[6].rotation;
        LevelsStarting[6].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[6].SetActive(false);
        //LevelCameras[1].SetActive(true);

        //yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        //yield return new WaitForSeconds(14);
        //BlackPanel.SetActive(true);

        //yield return new WaitForSeconds(1);
        //BlackPanel.SetActive(false);





        //LevelCameras[1].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[6].SetActive(true);
        DirectionArrowsOfLevel[6].SetActive(true);


    }


    IEnumerator level7dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }













    IEnumerator level8sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[7].position;
        gameObject.transform.rotation = truckLoadingPoints[7].rotation;
        LevelsStarting[7].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[7].SetActive(false);
        //LevelCameras[1].SetActive(true);

        //yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        //yield return new WaitForSeconds(14);
        //BlackPanel.SetActive(true);

        //yield return new WaitForSeconds(1);
        //BlackPanel.SetActive(false);





        //LevelCameras[1].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[7].SetActive(true);
        DirectionArrowsOfLevel[7].SetActive(true);


    }


    IEnumerator level8dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }








    IEnumerator level9sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[8].position;
        gameObject.transform.rotation = truckLoadingPoints[8].rotation;
        LevelsStarting[8].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[8].SetActive(false);
        //LevelCameras[1].SetActive(true);

        //yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        //yield return new WaitForSeconds(14);
        //BlackPanel.SetActive(true);

        //yield return new WaitForSeconds(1);
        //BlackPanel.SetActive(false);





        //LevelCameras[1].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[8].SetActive(true);
        DirectionArrowsOfLevel[8].SetActive(true);


    }


    IEnumerator level9dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }

















    IEnumerator level10sp()
    {



        GameControl.manager.VehicleHandBrake(true);
        GameControl.manager.VehicleAccelForward(0f);
        GameControl.manager.VehicleAccelBack(0f);
        GameControl.manager.VehicleSteer(0f);

        BlackPanel.SetActive(true);
        gameCanvas.SetActive(false);




        yield return new WaitForSeconds(1f);
        gameObject.transform.position = truckLoadingPoints[9].position;
        gameObject.transform.rotation = truckLoadingPoints[9].rotation;
        LevelsStarting[9].GetComponent<Rigidbody>().detectCollisions = false;


        locationSignsSP[9].SetActive(false);
        //LevelCameras[1].SetActive(true);

        //yield return new WaitForSeconds(2);


        BlackPanel.SetActive(false);
        //craneAnim.enabled = true;
        //yield return new WaitForSeconds(14);
        //BlackPanel.SetActive(true);

        //yield return new WaitForSeconds(1);
        //BlackPanel.SetActive(false);





        //LevelCameras[1].SetActive(false);

        gameCanvas.SetActive(true);


        //yield return new WaitForSeconds(2);
        GameControl.manager.VehicleHandBrake(false);
        LevelsDestination[9].SetActive(true);
        DirectionArrowsOfLevel[9].SetActive(true);


    }


    IEnumerator level10dp()
    {
        BlackPanel.SetActive(true);
        yield return new WaitForSeconds(2);
        levelPass.SetActive(true);
    }







    public void popUpShow(string missionText)
    {

        popUp.SetActive(true);
        popUpText.text = missionText;
    }





}
