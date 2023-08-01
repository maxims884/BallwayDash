using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;
   
   // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Sound"))
  	    {
            int status = PlayerPrefs.GetInt("Sound");
		    LevelSettings.GetInstance().SetSoundStatus(status);
            if(status == 0){
                AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
                foreach (AudioSource a in allAudioSources)
                {
                    a.mute = true;
                }
            } else {
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
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
	if (Application.platform == RuntimePlatform.Android)
  	{
    		if (Input.GetKeyDown(KeyCode.Escape)) 
    		{
      			Application.Quit(); 
    		}
  	}
    }
}