using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Common;

public class myAdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Test Settings")]
    public bool admobTestBool;
    public bool unityTestBool;
    [Header("Add this string in admob settings if you are in test mode")]
    public string admobAppID;

    [Header("Admob Settings")]
    [Header("Banners")]
    public bool useBanners;
    public string bannerID;
    public AdPosition bannerPosition;
    public string bigBannerID;
    public AdPosition bigBannerPosition;

    private BannerView bannerView;
    private bool bannerLoaded;
    private bool bannerShowing;
    private BannerView bigBannerView;
    private bool bigBannerLoaded;
    private bool bigBannerShowing;

    [Header("App Open")]
    public bool useAppOpen;
    public string appOpenId;
    private AppOpenAd appOpenAd;
    private DateTime appOpenExpireTime;
    private readonly TimeSpan APPOPEN_TIMEOUT = TimeSpan.FromHours(4);

    [Header("Interstitial")]
    public string interstitialID;
    private InterstitialAd interstitialAd;

    [Header("Rewarded")]
    public string rewardedVideoID;
    private RewardedAd rewardedAd;


    [Header("Unity Ads Settings")]

    [Header("App ID")]
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    private string _gameId;

    [Header("Interstitial")]

    [SerializeField] string _androidInterstitialAdUnitId = "Android_Interstitial";
    [SerializeField] string _iOSInterstitialAdUnitId = "iOS_Interstitial";
    string unityInterstitialAdUnit;

    [Header("Rewarded")]
    [SerializeField] string _androidRewardedAdUnitId = "Android_Rewarded";
    [SerializeField] string _iOSRewardedAdUnitId = "iOS_Rewarded";
    string unityRewardedAdUnit;

    private void Start()
    {
        
    }

    public void AdmobInitialization()
    {
        MobileAds.SetiOSAppPauseOnBackground(true);
        if (admobTestBool)
        {
            bannerID = "ca-app-pub-3940256099942544/6300978111";
            bigBannerID = "ca-app-pub-3940256099942544/6300978111";
            interstitialID = "ca-app-pub-3940256099942544/1033173712";
            rewardedVideoID = "ca-app-pub-3940256099942544/5224354917";
            appOpenId = "ca-app-pub-3940256099942544/3419835294";
        }
        admobInitialization();
    }

    public void UnityInitialization()
    {
        unityInitialization();
    }

    private void admobInitialization()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(HandleInitCompleteAction);

        // Listen to application foreground / background events.
        AppStateEventNotifier.AppStateChanged += OnAppStateChanged;
    }

    private void HandleInitCompleteAction(InitializationStatus initstatus)
    {
        Debug.Log("Initialization complete.");
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (useBanners)
            {
                RequestBannerAd();
                RequestBigBannerAd();
            }

            RequestAndLoadInterstitialAd();
            RequestAndLoadRewardedAd();
            RequestAndLoadAppOpenAd();
        });
    }

    private void unityInitialization()
    {
        //app id initialization
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
    ? _iOSGameId
    : _androidGameId;
        Advertisement.Initialize(_gameId, unityTestBool, this);

        //interstitial initialization
        unityInterstitialAdUnit = (Application.platform == RuntimePlatform.IPhonePlayer)
    ? _iOSInterstitialAdUnitId
    : _androidInterstitialAdUnitId;

        //rewarded initialization
        unityRewardedAdUnit = (Application.platform == RuntimePlatform.IPhonePlayer)
    ? _iOSRewardedAdUnitId
    : _androidRewardedAdUnitId;
    }

    //app id initialization complete
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadUnityInterstitial();
        LoadUnityRewarded();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    // Load content to the Ad Unit:
    public void LoadUnityInterstitial()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + unityInterstitialAdUnit);
        Advertisement.Load(unityInterstitialAdUnit, this);
    }

    // Show the loaded content in the Ad Unit:
    public void ShowUnityInterstitial()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + unityInterstitialAdUnit);
        Advertisement.Show(unityInterstitialAdUnit, this);
    }

    public void LoadUnityRewarded()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + unityRewardedAdUnit);
        Advertisement.Load(unityRewardedAdUnit, this);
    }

    // Show the loaded content in the Ad Unit:
    public void ShowUnityRewarded()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + unityRewardedAdUnit);
        Advertisement.Show(unityRewardedAdUnit, this);
    }

    //Load another ad while current is showing
    public void OnUnityAdsShowStart(string adUnitId)
    {
        if (adUnitId.Equals(unityInterstitialAdUnit))
        {
            LoadUnityInterstitial();
            Debug.Log("Load another ad");
        }

        if (adUnitId.Equals(unityRewardedAdUnit))
        {
            LoadUnityRewarded();
            Debug.Log("Load another ad");
        }
    }

    //When reward ad completed
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(unityRewardedAdUnit) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            GiveReward();
        }
    }

    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.

        if (adUnitId.Equals(unityInterstitialAdUnit))
        {
            LoadUnityInterstitial();
            Debug.Log("Load another ad");
        }

        if (adUnitId.Equals(unityRewardedAdUnit))
        {
            LoadUnityRewarded();
            Debug.Log("Load another ad");
        }
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }
    public void OnUnityAdsShowClick(string adUnitId) { }


    /// <summary>
    /// REQUESTS ADMOB
    /// </summary>

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    /// <summary>
    /// SMALL BANNER
    /// </summary>
    ///

    private void RequestBannerAd()
    {
        // Clean up banner before reusing
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);

        // Add Event Handlers
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner ad loaded.");
            bannerLoaded = true;
            bannerShowing = true;

            Invoke("hideBanner", 0.01f);
        };
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.Log("Banner ad failed to load with error: " + error.GetMessage());
        };
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner ad opening.");
        };
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner ad closed.");
        };
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            string msg = string.Format("{0} (currency: {1}, value: {2}",
                                        "Banner ad received a paid event.",
                                        adValue.CurrencyCode,
                                        adValue.Value);
            Debug.Log(msg);
        };

        // Load a banner ad
        bannerView.LoadAd(CreateAdRequest());
    }

    public void showBanner()
    {
        if (PlayerPrefs.GetInt("noAds") == 0)
        {
            if (useBanners && bannerView != null && bannerLoaded)
            {
                if (!bannerShowing)
                {
                    if (AdsOnOff.admobAdsBool)
                    {
                        bannerShowing = true;
                        bannerView.Show();
                    }
                }
            }
        }
    }

    public void hideBanner()
    {
        if (useBanners && bannerView != null && bannerLoaded)
        {
            if (bannerShowing)
            {
                if (AdsOnOff.admobAdsBool)
                {
                    bannerShowing = false;
                    bannerView.Hide();
                }
            }
        }
    }

    private void DestroyBanner()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }
    }

    /// <summary>
    /// BIG BANNER
    /// </summary>
    ///

    private void RequestBigBannerAd()
    {
        // Clean up banner before reusing
        if (bigBannerView != null)
        {
            bigBannerView.Destroy();
            bigBannerView = null;
        }

        // Create a 320x50 banner at top of the screen
        AdSize nativeSize = new AdSize(300, 250); //image size
        bigBannerView = new BannerView(bigBannerID, nativeSize, bigBannerPosition);

        // Add Event Handlers
        bigBannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Big Banner ad loaded.");
            bigBannerLoaded = true;
            bigBannerShowing = true;

            Invoke("hideBigBanner", 0.01f);
        };
        bigBannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.Log("Big Banner ad failed to load with error: " + error.GetMessage());
        };
        bigBannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Big Banner ad opening.");
        };
        bigBannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Big Banner ad closed.");
        };
        bigBannerView.OnAdPaid += (AdValue adValue) =>
        {
            string msg = string.Format("{0} (currency: {1}, value: {2}",
                                        "Banner ad received a paid event.",
                                        adValue.CurrencyCode,
                                        adValue.Value);
            Debug.Log(msg);
        };

        // Load a banner ad
        bigBannerView.LoadAd(CreateAdRequest());
    }

    public void showBigBanner()
    {
        if (PlayerPrefs.GetInt("noAds") == 0 && AdsOnOff.admobAdsBool)
        {
            if (useBanners && bigBannerView != null && bigBannerLoaded)
            {
                if (!bigBannerShowing)
                {
                    if (AdsOnOff.admobAdsBool)
                    {
                        bigBannerShowing = true;
                        bigBannerView.Show();
                    }
                }
            }
        }
    }

    public void hideBigBanner()
    {
        if (useBanners && bigBannerView != null && bigBannerLoaded)
        {
            if (bigBannerShowing)
            {
                if (AdsOnOff.admobAdsBool)
                {
                    bigBannerShowing = false;
                    bigBannerView.Hide();
                }
            }
        }
    }

    private void DestroyBigBanner()
    {
        if (bigBannerView != null)
        {
            bigBannerView.Destroy();
            bigBannerView = null;
        }
    }

    /// <summary>
    /// INTERSTITIAL
    /// </summary>
    ///

    public void RequestAndLoadInterstitialAd()
    {
        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        // Load an interstitial ad
        InterstitialAd.Load(interstitialID, CreateAdRequest(),
            (InterstitialAd ad, LoadAdError loadError) =>
            {
                if (loadError != null)
                {
                    Debug.Log("Interstitial ad failed to load with error: " +
                        loadError.GetMessage());
                    return;
                }
                else if (ad == null)
                {
                    Debug.Log("Interstitial ad failed to load.");
                    return;
                }

                Debug.Log("Interstitial ad loaded.");
                interstitialAd = ad;

                ad.OnAdFullScreenContentOpened += () =>
                {
                    Debug.Log("Interstitial ad opening.");
                };
                ad.OnAdFullScreenContentClosed += () =>
                {
                    Debug.Log("Interstitial ad closed.");
                    RequestAndLoadInterstitialAd();
                };
                ad.OnAdImpressionRecorded += () =>
                {
                    Debug.Log("Interstitial ad recorded an impression.");
                };
                ad.OnAdClicked += () =>
                {
                    Debug.Log("Interstitial ad recorded a click.");
                };
                ad.OnAdFullScreenContentFailed += (AdError error) =>
                {
                    Debug.Log("Interstitial ad failed to show with error: " +
                                error.GetMessage());
                    RequestAndLoadInterstitialAd();
                };
                ad.OnAdPaid += (AdValue adValue) =>
                {
                    string msg = string.Format("{0} (currency: {1}, value: {2}",
                                               "Interstitial ad received a paid event.",
                                               adValue.CurrencyCode,
                                               adValue.Value);
                    Debug.Log(msg);
                };
            });
    }

    public void showBothInterstitial()
    {
        if (PlayerPrefs.GetInt("noAds") == 0)
        {
            if (interstitialAd != null && interstitialAd.CanShowAd() && AdsOnOff.admobAdsBool)
            {
                interstitialAd.Show();    
            }

            else
            {
                if (AdsOnOff.unityAdsBool)
                {
                    ShowUnityInterstitial();
                }
            }
        }
    }

    public void DestroyInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
    }

    /// <summary>
    /// REWARDED AD
    /// </summary>


    public void RequestAndLoadRewardedAd()
    {
        // create new rewarded ad instance

        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        RewardedAd.Load(rewardedVideoID, CreateAdRequest(),
            (RewardedAd ad, LoadAdError loadError) =>
            {
                if (loadError != null)
                {
                    Debug.Log("Rewarded ad failed to load with error: " +
                                loadError.GetMessage());
                    return;
                }
                else if (ad == null)
                {
                    Debug.Log("Rewarded ad failed to load.");
                    return;
                }

                Debug.Log("Rewarded ad loaded.");
                rewardedAd = ad;

                ad.OnAdFullScreenContentOpened += () =>
                {
                    Debug.Log("Rewarded ad opening.");
                };
                ad.OnAdFullScreenContentClosed += () =>
                {
                    Debug.Log("Rewarded ad closed.");
                    RequestAndLoadRewardedAd();
                };
                ad.OnAdImpressionRecorded += () =>
                {
                    Debug.Log("Rewarded ad recorded an impression.");
                };
                ad.OnAdClicked += () =>
                {
                    Debug.Log("Rewarded ad recorded a click.");
                };
                ad.OnAdFullScreenContentFailed += (AdError error) =>
                {
                    Debug.Log("Rewarded ad failed to show with error: " +
                               error.GetMessage());
                    RequestAndLoadRewardedAd();
                };
                ad.OnAdPaid += (AdValue adValue) =>
                {
                    string msg = string.Format("{0} (currency: {1}, value: {2}",
                                               "Rewarded ad received a paid event.",
                                               adValue.CurrencyCode,
                                               adValue.Value);
                    Debug.Log(msg);
                };
            });
    }

    public void showRewardedVideo()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd() && AdsOnOff.admobAdsBool)
        {
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("Rewarded ad granted a reward: " + reward.Amount);
                GiveReward();
            });      
        }

        else
        {
            if (AdsOnOff.unityAdsBool)
            {
                Debug.Log("Rewarded ad is not ready yet.");
                ShowUnityRewarded();
            }
        }
    }

    public void DestroyRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
    }

    /// <summary>
    /// APP OPEN
    /// </summary>


    public void RequestAndLoadAppOpenAd()
    {
        if (appOpenAd != null)
        {
            appOpenAd.Destroy();
            appOpenAd = null;
        }

        // Create a new app open ad instance.
        AppOpenAd.Load(appOpenId, Screen.orientation, CreateAdRequest(),
            (AppOpenAd ad, LoadAdError loadError) =>
            {
                if (loadError != null)
                {
                    Debug.Log("App open ad failed to load with error: " +
                        loadError.GetMessage());
                    return;
                }
                else if (ad == null)
                {
                    Debug.Log("App open ad failed to load.");
                    return;
                }

                Debug.Log("App Open ad loaded. Please background the app and return.");
                this.appOpenAd = ad;
                this.appOpenExpireTime = DateTime.Now + APPOPEN_TIMEOUT;

                ad.OnAdFullScreenContentOpened += () =>
                {
                    Debug.Log("App open ad opened.");
                };
                ad.OnAdFullScreenContentClosed += () =>
                {
                    Debug.Log("App open ad closed.");
                    RequestAndLoadAppOpenAd();
                };
                ad.OnAdImpressionRecorded += () =>
                {
                    Debug.Log("App open ad recorded an impression.");
                };
                ad.OnAdClicked += () =>
                {
                    Debug.Log("App open ad recorded a click.");
                };
                ad.OnAdFullScreenContentFailed += (AdError error) =>
                {
                    Debug.Log("App open ad failed to show with error: " +
                        error.GetMessage());
                    RequestAndLoadAppOpenAd();
                };
                ad.OnAdPaid += (AdValue adValue) =>
                {
                    string msg = string.Format("{0} (currency: {1}, value: {2}",
                                               "App open ad received a paid event.",
                                               adValue.CurrencyCode,
                                               adValue.Value);
                    Debug.Log(msg);
                };
            });
    }

    public bool IsAppOpenAdAvailable
    {
        get
        {
            return (appOpenAd != null
                    && appOpenAd.CanShowAd()
                    && DateTime.Now < appOpenExpireTime);
        }
    }

    public void ShowAppOpenAd()
    {
        if (AdsOnOff.admobAdsBool && useAppOpen)
        {
            if (!IsAppOpenAdAvailable)
            {
                return;
            }
            appOpenAd.Show();
        }
    }

    public void OnAppStateChanged(AppState state)
    {
        // Display the app open ad when the app is foregrounded.
        UnityEngine.Debug.Log("App State is " + state);

        // OnAppStateChanged is not guaranteed to execute on the Unity UI thread.
        MobileAdsEventExecutor.ExecuteInUpdate(() =>
        {
            if (state == AppState.Foreground)
            {
                ShowAppOpenAd();
            }
        });
    }


    public void DestroyAppOpenAd()
    {
        if (AdsOnOff.admobAdsBool)
        {
            if (this.appOpenAd != null)
            {
                this.appOpenAd.Destroy();
                this.appOpenAd = null;
            }
        }
    }

    private void OnDestroy()
    {
        AppStateEventNotifier.AppStateChanged -= OnAppStateChanged;
    }

    /// <summary>
    /// GIVE REWARD
    /// </summary>

    public void GiveReward()
    {
        //Give Reward Here...
        Debug.Log("you got a reward");
    }
}
