using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu(){
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RetryLevel(){
	    // LevelSettings.GetInstance().ResetScore();
	    // // LevelSettings.GetInstance().LoadBestScore();
	    // // LevelSettings.GetInstance().SetIsLevelCompleted(false);
	    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
