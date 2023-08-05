using GoogleMobileAds;
using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
      private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
    // #elif UNITY_IPHONE
    //   private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
      private string _adUnitId = "unused";
    #endif

    private InterstitialAd interstitialAd;
    public void Start()
    {
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
    }

      /// <summary>
      /// Loads the interstitial ad.
      /// </summary>
    public void LoadInterstitialAd()
    {
          // Clean up the old ad before loading a new one.
          if (interstitialAd != null)
          {
                interstitialAd.Destroy();
                interstitialAd = null;
          }

          Debug.Log("Loading the interstitial ad.");

          // create our request used to load the ad.
          var adRequest = new AdRequest();
          adRequest.Keywords.Add("unity-admob-sample");

          // send the request to load the ad.
          InterstitialAd.Load(_adUnitId, adRequest,
              (InterstitialAd ad, LoadAdError error) =>
              {
                  // if error is not null, the load request failed.
                  if (error != null || ad == null)
                  {
                      Debug.LogError("interstitial ad failed to load an ad " + "with error : " + error);
                      return;
                  }

                  Debug.Log("Interstitial ad loaded with response : " + ad.GetResponseInfo());

                  interstitialAd = ad;
              });
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }

    }

    private void RegisterEventHandlers(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(("Interstitial ad paid {0} {1}.", adValue.Value.ToString(), adValue.CurrencyCode.ToString()));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " + "with error : " + error);
        };
    }

    private void RegisterReloadHandler(InterstitialAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " + "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
    }
}