using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuModal : MonoBehaviour
{
    public GameObject window;
    private Animator animator;
    public AudioClip pressClip;
	public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
	animator = window.GetComponent<Animator>();  
	
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show(){
	window.SetActive(true);
	if(animator != null)
	{
		animator.ResetTrigger("close");
//		animator.SetTrigger("open");
	}
    	
    }

    public void hide(){
	source.PlayOneShot(pressClip);
	if(animator != null)
	{
//		animator.ResetTrigger("open");
		animator.SetTrigger("close");

	}
    }

    public void AnimationFinished(){
	window.SetActive(false);
    }
}
