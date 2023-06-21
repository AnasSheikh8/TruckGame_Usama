using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSettings : MonoBehaviour
{


    public GameObject audioSourceMusic;
    public AudioSource[] audioSourceSounds;

    public GameObject[] soundButtons;
    public GameObject[] musicButtons;
    // Start is called before the first frame update
    void Start()
    {
       
            if (PlayerPrefs.GetInt("sound") == 1)
            {
            
                for (int i = 0; i < audioSourceSounds.Length; i++)
                {
                    audioSourceSounds[i].enabled = true;
                }
                soundButtons[0].SetActive(false);
                soundButtons[1].SetActive(true);

            }
            else
            {
                for (int i = 0; i < audioSourceSounds.Length; i++)
                {
                    audioSourceSounds[i].enabled = false;
                }
                soundButtons[0].SetActive(true);
                soundButtons[1].SetActive(false);

            }



        

    }

    // Update is called once per frame
    void Update()
    {
       
        if(PlayerPrefs.GetInt("music")==1)
        {
            audioSourceMusic.SetActive(true);
            musicButtons[0].SetActive(false);
            musicButtons[1].SetActive(true);

        }
        else
        {
            audioSourceMusic.SetActive(false);
            musicButtons[0].SetActive(true);
            musicButtons[1].SetActive(false);
        }



       


    }



    public void soundOn()
    {
        PlayerPrefs.SetInt("sound",1);

        for (int i = 0; i < audioSourceSounds.Length; i++)
        {
                
            audioSourceSounds[i].enabled=true;
            
        }


    }


    public void soundOff()
    {
        PlayerPrefs.SetInt("sound", 0);
        for (int i = 0; i < audioSourceSounds.Length; i++)
        {

            audioSourceSounds[i].enabled=false;

        }


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
