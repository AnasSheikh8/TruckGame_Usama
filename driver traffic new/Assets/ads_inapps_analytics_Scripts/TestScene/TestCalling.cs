using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCalling : MonoBehaviour
{

    //...............ads caling...........

    public void showBanner()
    {
        Instance.GetInstance().my_AdManager.showBanner();
    }

    public void hideBanner()
    {
        Instance.GetInstance().my_AdManager.hideBanner();
    }

    public void showBigBanner()
    {
        Instance.GetInstance().my_AdManager.showBigBanner();
    }

    public void hideBigBanner()
    {
        Instance.GetInstance().my_AdManager.hideBigBanner();
    }

    public void ShowBothInterstitial()
    {
        Instance.GetInstance().my_AdManager.showBothInterstitial();
    }

    public void showRewardVideo()
    {
        Instance.GetInstance().my_AdManager.showRewardedVideo();
    }

    public void ShowAppOpen()
    {
        Instance.GetInstance().my_AdManager.ShowAppOpenAd();
    }


    //.................Inapp Calling...................

    public void NoAds()
    {
        Instance.GetInstance().iap_Manager.buyNoAds();
    }


    //................Analytics Calling..............

    public void ClickButton(string buttonName)
    {
        Instance.GetInstance().ga_Manager.TriggerDesignEvent(buttonName);
    }

    public void LevelStart(int missionIndex)
    {
        Instance.GetInstance().ga_Manager.TriggerMissionStart(missionIndex);
    }

    public void LevelWin(int missionIndex)
    {
        Instance.GetInstance().ga_Manager.TriggerMissionComplete(missionIndex);
    }

    public void LevelFail(int missionIndex)
    {
        Instance.GetInstance().ga_Manager.TriggerMissionFailed(missionIndex);
    }
}
