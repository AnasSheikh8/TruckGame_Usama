using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSettings : MonoBehaviour
{


    public GameObject audioSourceMusic;
    public GameObject audioSourceSounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(PlayerPrefs.GetInt("music")==1)
        {
            audioSourceMusic.SetActive(true);
        }
        else
        {
            audioSourceMusic.SetActive(false);
        }

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            audioSourceSounds.SetActive(true);
        }
        else
        {
            audioSourceSounds.SetActive(false);
        }


    }



    public void soundOn()
    {
        PlayerPrefs.SetInt("sound",1);
    }


    public void soundOff()
    {
        PlayerPrefs.SetInt("sound", 0);
    }

    public void musicOn()
    {
        PlayerPrefs.SetInt("music", 1);
    }


    public void musicOff()
    {
        PlayerPrefs.SetInt("music", 0);
    }

}
