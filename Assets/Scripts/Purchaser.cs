using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class Purchaser : MonoBehaviour
{
    public GameObject NoAdButton;
    public void OnPurchaseCompleted(Product product){
        RemoveAd();
    }

    private void RemoveAd(){
        Debug.Log("Remove ad.");
        PlayerPrefs.SetInt("removead",1);
        NoAdButton.SetActive(false);
    }
}
