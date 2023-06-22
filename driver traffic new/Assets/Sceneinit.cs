using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Sceneinit : MonoBehaviour
{

    public Slider loadingslider;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        loadMainMenu();

    }



    void loadMainMenu()
    {
        if (loadingslider.value < 1)
        {
            loadingslider.value = loadingslider.value+ Time.deltaTime + 0.05f;

        }
        else
        {
            SceneManager.LoadScene(1);
        }


        
    }
}
