using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHorizontalSwither : MonoBehaviour
{
    private Text text;
    private int m_index = 0;

    public int index{
		get{
			return m_index;
		}
		set{
			m_index = value;
			text.text = data[m_index];
		}
	}

    public int defaultValueIndex = 0;
    public List<string> data = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        text = transform.Find("Text").GetComponent<Text>();
	   index = defaultValueIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLeftClicked(){
    		if(index == 0){
			index = data.Count - 1;
		}
		else{
			index--;
		}
    }
   
    public void OnRightClicked(){
    		if((index + 1) >= data.Count){
			index = 0;
		}
    		else {
    			index++;
		}
	    }
}
