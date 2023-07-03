using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings 
{
    public static LevelSettings instance; 

    private int BallCount = 4;
    private int UpdatedCollisedBalls = 0;  
    private int OldUpdatedCollisedBalls = 0; 
    private int CurrentScore = 0;
    private int OldCount = 0;

    private bool IsChangedScore = false;

    private LevelSettings(){}
    public static LevelSettings GetInstance() {
        if(instance == null)
		instance = new LevelSettings();
    	return instance;
    }

    public void SetBallCount(int count){
	BallCount = count;
    }

    public int GetBallCount(){
	return BallCount;
    }

    public void SaveBallCountIndex(int index){
    	PlayerPrefs.SetInt("BallCountIndex", index);
    }

    public int LoadBallCountIndex(){
    	if (PlayerPrefs.HasKey("BallCountIndex"))
  	{
		int index = PlayerPrefs.GetInt("BallCountIndex");
		return index; 
      	}
  	else{
    		Debug.LogError("There is no save data!");
		return 0;
	}
    }

	
    public void SetUpdatedCollisedBalls(int count){
	//if(OldUpdatedCollisedBalls != count) OldUpdatedCollisedBalls = UpdatedCollisedBalls;
	if(OldCount < count) {
		OldUpdatedCollisedBalls = UpdatedCollisedBalls;
		OldCount = count;
		SetChangedScore(true);
	}
	UpdatedCollisedBalls = count;
    }

    public int GetUpdatedCollisedBalls(){
	return UpdatedCollisedBalls;
    }

    public int GetOldUpdatedCollisedBalls(){
	return OldUpdatedCollisedBalls;
    }

    public void SetCurrentScore(int score){
	CurrentScore = score; 
    }

    public void AddCurrentScore(int addScore){
	CurrentScore += addScore; 
    }

    public int GetCurrentScore(){
	return CurrentScore;
    }

    public void SetChangedScore(bool isChanged){
	IsChangedScore = isChanged; 
    }

    public bool GetChangedScore(){
	return IsChangedScore;
    }

}
