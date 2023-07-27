using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHorizontalSwither : MonoBehaviour
{
    private Text text;
    private int m_index = 0;
	public AudioClip pressClip;
	[SerializeField] private AudioSource source;
    public int index{
		get{
			return m_index;
		}
		set{
			m_index = value;
			text.text = data[m_index];
			LevelSettings.GetInstance().SetBallCount((index * 4) + 4);
			LevelSettings.GetInstance().SaveBallCountIndex(m_index);
		}
	}

    public int defaultValueIndex = 0;
    public List<string> data = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
	index = LevelSettings.GetInstance().LoadBallCountIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLeftClicked(){
		source.PlayOneShot(pressClip);
    		if(index == 0){
			index = data.Count - 1;
		}
		else{
			index--;
		}
    }
   
    public void OnRightClicked(){
		source.PlayOneShot(pressClip);
    		if((index + 1) >= data.Count){
			index = 0;
		}
    		else {
    			index++;
		}
	    }
}
