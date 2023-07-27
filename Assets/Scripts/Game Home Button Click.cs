using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameHomeButtonClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
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
    // Debug.Log("UP");
}
public void OnPointerDown(PointerEventData eventData){
	source.PlayOneShot(pressClip);
    // Debug.Log("Down");
}

    public void HomeClicked(){
        source.PlayOneShot(pressClip);
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
