using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class AdAfter : MonoBehaviour
{
    private InterstitialAd interstitialAd ;
    // private string testUnitId = "ca-app-pub-3940256099942544/1033173712";
    private string testUnitId = "ca-app-pub-2230097402282612/9432416399";
    
    // Start is called before the first frame update
    void Start()
    {
        LoadInterstitialAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 public InterstitialAd GetInterstitialAd()
 {
    return interstitialAd;
 }
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

        // interstitialAd = new InterstitialAd(testUnitId);
        // interstitialAd.LoadAd(adRequest);
      // send the request to load the ad.
      InterstitialAd.Load(testUnitId, adRequest,
          (InterstitialAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  Debug.LogError("interstitial ad failed to load an ad " +
                                 "with error : " + error);
                  return;
              }

              Debug.Log("Interstitial ad loaded with response : "
                        + ad.GetResponseInfo());
            // LevelSettings.GetInstance().SetInterstitialAd(ad);

              interstitialAd = ad;
              
          });
  }

    // public void ShowAd()
    // {
    //     if (interstitialAd.IsLoaded())
    //         interstitialAd.Show();
    // }

public void ShowAd()
{
    if (interstitialAd != null&& interstitialAd.CanShowAd())
    {
        Debug.Log("Showing interstitial ad.");
        interstitialAd.Show();
    }
    else
    {
        Debug.LogError("Interstitial ad is not ready yet.");
    }
}
}
