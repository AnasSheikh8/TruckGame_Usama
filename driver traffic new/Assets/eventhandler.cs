using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class eventhandler : MonoBehaviour, ISelectHandler, IDeselectHandler
{


    public GameObject img;
    public int SelectedLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnSelect(BaseEventData eventData)
    {
        img.SetActive(true);
        MainMenuManager.instance.SelectedLevel(SelectedLevel);
    }


    public void OnDeselect(BaseEventData eventData)
    {
        img.SetActive(false);

    }

}
