using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdAfter : MonoBehaviour
{
    private InterstitialAd interstitialAd ;
    private string testUnitId = "ca-app-pub-3940256099942544/1033173712";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable(){
        interstitialAd = new InterstitialAd(testUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    public void ShowAd(){
        // if(interstitialAd.IsLoaded())
        //     interstitialAd.Show();
    }
}
