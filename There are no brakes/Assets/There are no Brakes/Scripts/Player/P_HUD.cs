/***********************
 * P_HUD.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class P_HUD : MonoBehaviour {
	public GUIStyle HUDGUIStyle;
	private Vector2 size = new Vector2(375,60);
	public Vector2 pos1;
	private Vector2 pos2 = new Vector2(0,0);
	public float barDisplay1 = 0.015f; //whole game
	public float barDisplay2 = 0.9f; //current level
	private float bar1distance = 0; //whole game
	private float bar2distance = 0; //current level
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public Texture2D cloudIcon;
	public Texture2D trainIcon;
	public int MaxLevelTime = 300; //time limit in seconds
	public int MaxGameTime = 3000; //time limit in seconds
	private bool GameOver = false;
	public int PercentageRecoverOnLevelComplete = 15;
	private Vector3 traindefaultpos;
	private Vector3 clouddefaultpos;
	public float maxpos = 16;
	private float trainmaxpos;
	private float cloudmaxpos;
	public bool firstLevel = false;
	private int levelID = 0;
	
	void Start(){
		if(firstLevel){
			resetValues();
			levelID = Application.loadedLevel;
			saveLevelID(levelID);
		} else {
			barDisplay1 = remainingCloudTime();
			barDisplay2 = remainingTrainTime();
			levelID = loadLevelID();
		}
		pos2 = new Vector2(Screen.width - (size.x + pos1.x),pos1.y);
		traindefaultpos = GameObject.Find("HUDtrainIcon").transform.position;
		clouddefaultpos = GameObject.Find("HUDcloudIcon").transform.position;
		trainmaxpos = traindefaultpos.z - maxpos;
		cloudmaxpos = clouddefaultpos.z + maxpos;
	}
	 
	void FixedUpdate() {
		//calculate the timers
		barDisplay1 += Time.deltaTime/MaxGameTime;
		barDisplay2 -= Time.deltaTime/MaxLevelTime;
		
		//trigger game over if either bar empties
		if(barDisplay1 >= 1){GameOver = true;barDisplay1 = 1;GameLost();}
		if(barDisplay2 <= 0){GameOver = true;barDisplay2 = 0;GameLost();}
		
		//recover distance on level completion
		if(barDisplay2 < recoveredDistance){
			barDisplay2 += Time.deltaTime/MaxLevelTime * 10;
		} else {
			recoveredDistance = 0;
			recovering = false;
		}
		
		
		//render HUD as 3D Mesh objects
		float cloudpos = barDisplay1 * maxpos + clouddefaultpos.z;
		GameObject.Find("HUDcloudIcon").transform.position = new Vector3(clouddefaultpos.x,clouddefaultpos.y,cloudpos);
		float trainpos = barDisplay2 * maxpos + traindefaultpos.z - maxpos;
		GameObject.Find("HUDtrainIcon").transform.position = new Vector3(traindefaultpos.x,traindefaultpos.y,trainpos);
	}
	public M_Pause pauseCompoment;
	public void GameLost(){
        //pauseCompoment.GameOver();
        //Debug.Log("GAME OVER");
    }
	
	private bool recovering = false;
	private float recoveredDistance;
	public void LevelCompleted(){
		Debug.Log("LEVEL COMPLETED");
		StartCoroutine(loadnextlevel(10));
		recoveredDistance = barDisplay2 + (((float)PercentageRecoverOnLevelComplete)/100);
		recovering = true;
		saveRemainingCloudTime(barDisplay1);
		saveRemainingTrainTime(barDisplay2);
	}
	
	IEnumerator loadnextlevel(float time){
		yield return new WaitForSeconds(time);
		levelID++;
		saveLevelID(levelID);
		Application.LoadLevel (levelID);
	}
	
	public void resetValues(){
		barDisplay1 = 0.015f;
		barDisplay2 = 0.9f;
		saveRemainingCloudTime(barDisplay1);
		saveRemainingTrainTime(barDisplay2);
	}
	
	
	
    float remainingTrainTime() {
        return PlayerPrefs.GetFloat("RemainingTrainTime");
    }
    float remainingCloudTime() {
        return PlayerPrefs.GetFloat("RemainingCloudTime");
    }
    int loadLevelID() {
        return PlayerPrefs.GetInt("LevelID");
    }
	
    void saveRemainingTrainTime(float value) {
        PlayerPrefs.SetFloat("RemainingTrainTime", value);
    }
    void saveRemainingCloudTime(float value) {
        PlayerPrefs.SetFloat("RemainingCloudTime", value);
    }
    void saveLevelID(float value) {
        PlayerPrefs.SetFloat("LevelID", value);
    }
}