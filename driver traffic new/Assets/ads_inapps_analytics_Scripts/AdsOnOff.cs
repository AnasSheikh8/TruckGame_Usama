using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class AdsOnOff : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }
    public bool UseThisPlugin;

    public string admobString;
    public string unityString;
    public string gameanalyticsString;

    public static bool admobAdsBool;
    public static bool unityAdsBool;
    public static bool gameanalyticsAdsBool;

    // Start is called before the first frame update
    void Awake()
    {
        if (!UseThisPlugin)
        {
            admobAdsBool = true;
            unityAdsBool = true;
            gameanalyticsAdsBool = true;
            return;
        }

        ConfigManager.FetchCompleted += SetAds;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    private void Start()
    {
        if (!UseThisPlugin)
        {
            SetInitializations();
        }
    }

    void SetAds(ConfigResponse response)
    {
        admobAdsBool = ConfigManager.appConfig.GetBool(admobString);
        unityAdsBool = ConfigManager.appConfig.GetBool(unityString);
        gameanalyticsAdsBool = ConfigManager.appConfig.GetBool(gameanalyticsString);

        SetInitializations();
    }

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= SetAds;
    }

    private void SetInitializations()
    {
        if (admobAdsBool)
        {
            Instance.GetInstance().my_AdManager.AdmobInitialization();
        }

        if (unityAdsBool)
        {
            Instance.GetInstance().my_AdManager.UnityInitialization();
        }

        if (gameanalyticsAdsBool)
        {
            Instance.GetInstance().ga_Manager.GameanalyticsInitialization();
        }
    }
}
