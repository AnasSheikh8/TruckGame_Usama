using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScenesManager : MonoBehaviour
{


    public int truckSelected=0;

    public static ScenesManager instance;

    public int currentLevel=0;
    public int currentMode = 0;

    public Slider loadingSlider;
    public GameObject loadingCanvas;
    float sliderSpeed = 0.06f;
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

        DontDestroyOnLoad(gameObject);

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (loadingSlider.value < 1)
        {
            loadingSlider.value = loadingSlider.value+ Time.deltaTime * sliderSpeed;
        }
        
        
    //    Debug.Log("Level=" + currentLevel);
    }
}
