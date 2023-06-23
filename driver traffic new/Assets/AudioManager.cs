using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] songs; 

    // Start is called before the first frame update
    void Start()
    {


    }




    private void Awake()
    {

        GetComponent<AudioSource>().clip = songs[0];

        GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
