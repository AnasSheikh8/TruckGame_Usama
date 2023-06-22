using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance : MonoBehaviour
{
    private static Instance instance;

    public myAdManager my_AdManager;
    public IAPManager iap_Manager;
    public GA_Manager ga_Manager;
    public AdsOnOff ads_OnOff;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Instance GetInstance()
    {
        return instance;
    }
}
