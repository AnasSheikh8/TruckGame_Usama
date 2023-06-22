using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GA_Manager : MonoBehaviour
{

    private void Start()
    {

    }

    public void GameanalyticsInitialization()
    {
        GameAnalytics.Initialize();
    }

    public void TriggerMissionStart(int missionID)
    {
        if (AdsOnOff.gameanalyticsAdsBool)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "mission" + missionID + "_started");
        }
    }

    public void TriggerMissionComplete(int missionID)
    {
        if (AdsOnOff.gameanalyticsAdsBool)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "mission" + missionID + "_completed");
        }
    }

    public void TriggerMissionFailed(int missionID)
    {
        if (AdsOnOff.gameanalyticsAdsBool)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "mission" + missionID + "_failed");
        }
    }

    public void TriggerDesignEvent(string eventName)
    {
        if (AdsOnOff.gameanalyticsAdsBool)
        {
            GameAnalytics.NewDesignEvent(eventName);
        }
    }
}
