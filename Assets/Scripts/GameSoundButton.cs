using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameSoundButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public AudioClip pressClip;
	public AudioSource source;
    public Image img;
	public Sprite on, off;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Sound"))
  	    {
            int status = PlayerPrefs.GetInt("Sound");
		    LevelSettings.GetInstance().SetSoundStatus(status);
            if(status == 0){
                img.sprite = off;
                AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
                foreach (AudioSource a in allAudioSources)
                {
                    a.mute = true;
                }
            } else {
                img.sprite = on;
                AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
                foreach (AudioSource a in allAudioSources)
                {
                    a.mute = false;
                }
            }
      	} else {
            LevelSettings.GetInstance().SetSoundStatus(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void OnPointerUp(PointerEventData eventData){
    // Debug.Log("UP");
}
public void OnPointerDown(PointerEventData eventData){
	source.PlayOneShot(pressClip);
    // Debug.Log("Down");
}

public void SoundClicked(){
    if(img.sprite == off) {
        img.sprite = on;
        PlayerPrefs.SetInt("Sound", 1);

        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in allAudioSources)
        {
            a.mute = false;
        }

    } else 
    {
        img.sprite = off;
        PlayerPrefs.SetInt("Sound", 0);
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in allAudioSources)
        {
            a.mute = true;
        }
    }    
}
}
