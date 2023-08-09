using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class WinScreenRetryButtonClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public AudioClip pressClip;
	public AudioSource source;
    public AdAfter ad;

    private bool isButtonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        RegisterEventHandlers(ad.GetInterstitialAd()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData){

    }

    public void OnPointerDown(PointerEventData eventData){
	    if(LevelSettings.GetInstance().GetSoundStatus() == 1) source.PlayOneShot(pressClip);
    }

    public void Retry(){
       
        LevelSettings.GetInstance().IncreaseAdCount();
        if(LevelSettings.GetInstance().GetAdCount() % 3 == 0) {
            isButtonPressed = true;
            ad.ShowAd();
        } else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void RegisterEventHandlers(InterstitialAd ad)
{
    // Raised when the ad closed full screen content.
    ad.OnAdFullScreenContentClosed += () =>
    {
        if(isButtonPressed){
            Debug.Log("Interstitial ad full screen content closed.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isButtonPressed = false;
        }
    };
    // Raised when the ad failed to open full screen content.
    ad.OnAdFullScreenContentFailed += (AdError error) =>
    {
        if(isButtonPressed){
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isButtonPressed = false;
        }
    };
}

}
