using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuClickPlayButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
	[SerializeField] private Image img;
	[SerializeField] private Sprite _default, pressed;
	[SerializeField] private AudioClip pressClip, unPressClip;
	[SerializeField] private AudioSource source;
    
public void OnPointerUp(PointerEventData eventData){
	img.sprite = _default;
	source.PlayOneShot(unPressClip);
}
public void OnPointerDown(PointerEventData eventData){
	img.sprite = pressed;
	source.PlayOneShot(pressClip);

}

public void wasClicked(){
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
}
