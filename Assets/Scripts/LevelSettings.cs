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
    private int BestScore = 0;
    private bool IsChangedScore = false;
    private int CurrentLevelIndex = 0;
    private bool IsLevelCompleted = false;
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
	    CurrentLevelIndex = index;
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

    public void ResetScore(){
	    OldUpdatedCollisedBalls = 0;
	    UpdatedCollisedBalls = 0;
	    CurrentScore = 0;
	    OldCount = 0;
    }	

    public void SetUpdatedCollisedBalls(int count){
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

    public void SetBestScore(int score){
	BestScore = score; 
    }

    public int GetBestScore(){
	return BestScore;
    }

    public void LoadBestScore(){
    	if (PlayerPrefs.HasKey("BestScoreIndex" + CurrentLevelIndex))
  	{
		BestScore = PlayerPrefs.GetInt("BestScoreIndex" + CurrentLevelIndex);
      	}
  	else{
		BestScore = 0;
	}
    }

    public void CheckBestScore(){
	if(BestScore < CurrentScore) 
	{
		BestScore = CurrentScore;
		PlayerPrefs.SetInt("BestScoreIndex" + CurrentLevelIndex, BestScore);
	}
    }

    public void LevelComplete(){
	    Debug.Log("Level Complete");
    }

    public void SetIsLevelCompleted(bool complete){
	    IsLevelCompleted = complete; 
    }

    public bool GetIsLevelCompleted(){
	    return IsLevelCompleted;
    }
}
