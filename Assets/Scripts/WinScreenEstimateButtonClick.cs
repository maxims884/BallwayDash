using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class WinScreenEstimateButtonClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public AudioClip pressClip;
	public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void Estimate(){
       
    }
}
