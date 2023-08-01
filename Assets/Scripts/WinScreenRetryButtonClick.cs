using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinScreenRetryButtonClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
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

    public void Retry(){
       	LevelSettings.GetInstance().ResetScore();
	    // LevelSettings.GetInstance().LoadBestScore();
	    // LevelSettings.GetInstance().SetIsLevelCompleted(false);
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
