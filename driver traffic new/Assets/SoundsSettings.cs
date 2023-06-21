using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSettings : MonoBehaviour
{


    public GameObject audioSourceMusic;
    public AudioSource[] audioSourceSounds;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < audioSourceSounds.Length; i++)
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                audioSourceSounds[i].enabled = true;

            }
            else
            {
                audioSourceSounds[i].enabled = false;

            }



        }

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
