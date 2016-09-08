/***********************
 * P_HUD.cs
 * Originally Written by Nathan Brown
 * Modified By:
 *  Xinyu Feng:
 *      Edit game over event
 *      Pass remaining time data to next screen
 ***********************/
using UnityEngine;
using System.Collections;
 
public class P_HUD : MonoBehaviour {
	//public GUIStyle HUDGUIStyle;
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
	public int MaxLevelTime = 900; //time limit in seconds
	private int MaxGameTime = 3900; //time limit in seconds
	private bool GameOver = false;
	public int PercentageRecoverOnLevelComplete = 15;
	private Vector3 traindefaultpos;
	private Vector3 clouddefaultpos;
	public float maxpos = 16;
	private float trainmaxpos;
	private float cloudmaxpos;
	public float trainspeed = 1f;
	public bool firstLevel = false;
	public int levelID = 0;
	private float timeCheck = 0;

	public GameObject text;
	private Vector3 levCompTextPos;
	private float speed = 0;

	private bool levelComplete = false;
	void Start(){
		//levCompTextPos = text.transform.position;
		if(firstLevel){
			resetValues();
			levelID = Application.loadedLevel;
			saveLevelID(levelID);
			saveLevel1Time(0);
			saveLevel2Time(0);
			saveLevel3Time(0);
		} else {
			barDisplay1 = remainingCloudTime();
			barDisplay2 = remainingTrainTime();
			trainspeed = getTrainSpeed();
			levelID = loadLevelID();
		}
		pos2 = new Vector2(Screen.width - (size.x + pos1.x),pos1.y);
		traindefaultpos = GameObject.Find("HUDtrainIcon").transform.position;
		clouddefaultpos = GameObject.Find("HUDcloudIcon").transform.position;
		trainmaxpos = traindefaultpos.z - maxpos;
		cloudmaxpos = clouddefaultpos.z + maxpos;
		timeCheck = Time.time;
	}
	 
	void FixedUpdate() {
		if (levelComplete) {
			speed += Time.deltaTime;
			//text.transform.position = new Vector3(levCompTextPos.x, Mathf.Lerp(levCompTextPos.y, levCompTextPos.y - 35, speed),levCompTextPos.z);
		}
		//calculate the timers
		if(!firstLevel){
			barDisplay1 += (Time.deltaTime/MaxGameTime)*trainspeed;
			barDisplay2 -= Time.deltaTime/MaxLevelTime;
		}
		
		//trigger game over if either bar empties
		if(barDisplay1 >= 1){GameOver = true;barDisplay1 = 1;GameLost();}
		if(barDisplay2 <= 0){GameOver = true;barDisplay2 = 0;GameLost();}
		
		//recover distance on level completion
		if(barDisplay2 < recoveredDistance){
			barDisplay2 += Time.deltaTime/MaxLevelTime * 10;
		} else {
			recoveredDistance = 0;
		}
		
		
		//render HUD as 3D Mesh objects
		float cloudpos = barDisplay1 * maxpos + clouddefaultpos.z;
		GameObject.Find("HUDcloudIcon").transform.position = new Vector3(clouddefaultpos.x,clouddefaultpos.y,cloudpos);
		float trainpos = barDisplay2 * maxpos + traindefaultpos.z - maxpos;
		GameObject.Find("HUDtrainIcon").transform.position = new Vector3(traindefaultpos.x,traindefaultpos.y,trainpos);
	}
	public M_Pause PauseCompoment;
	public void GameLost(){
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("GameOver");
        PauseCompoment.GameOver();
        Debug.Log("GAME OVER");
    }
	
	private float recoveredDistance = 0;
	public void LevelCompleted(){
		Debug.Log("LEVEL COMPLETED");
		levelComplete = true;
        //Vector3 guiPos = GameObject.Find ("GUI Camera").transform.position;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("LevelComplete");
		GameObject.Find ("Pause").GetComponent<M_Pause> ().LevelComplete ();

        StartCoroutine(loadnextlevel(5));
		if(!firstLevel){
			recoveredDistance = barDisplay2 + (((float)PercentageRecoverOnLevelComplete)/100);
		}
	}
	
	IEnumerator loadnextlevel(float time){
		yield return new WaitForSeconds(time);
		if(!firstLevel){
			trainspeed += 1f;
		}
		if(levelID == 3){
			saveLevel1Time(Time.time - timeCheck);
		} else if(levelID == 4){
			saveLevel2Time(Time.time - timeCheck);
		} else if(levelID == 5){
			saveLevel3Time(Time.time - timeCheck);
		}
		levelID++;
		saveLevelID(levelID);
		saveRemainingCloudTime(barDisplay1);
		saveRemainingTrainTime(barDisplay2);
		saveTrainSpeed(trainspeed);
		Application.LoadLevel (levelID);
	}
	
	public void resetValues(){
		barDisplay1 = 0.015f;
		barDisplay2 = 0.9f;
		trainspeed = 1f;
		saveRemainingCloudTime(barDisplay1);
		saveRemainingTrainTime(barDisplay2);
		saveTrainSpeed(trainspeed);
	}
	
	
	
    float remainingTrainTime() {
        return PlayerPrefs.GetFloat("RemainingTrainTime");
    }
    float remainingCloudTime() {
        return PlayerPrefs.GetFloat("RemainingCloudTime");
    }
    float getTrainSpeed() {
        return PlayerPrefs.GetFloat("TrainSpeed");
    }
    int loadLevelID() {
        return PlayerPrefs.GetInt("LevelID");
    }
    public float getLevel1Time() {
        return PlayerPrefs.GetFloat("Level1Time");
    }
    public float getLevel2Time() {
        return PlayerPrefs.GetFloat("Level2Time");
    }
    public float getLevel3Time() {
        return PlayerPrefs.GetFloat("Level3Time");
    }
	
    void saveRemainingTrainTime(float value) {
        PlayerPrefs.SetFloat("RemainingTrainTime", value);
    }
    void saveRemainingCloudTime(float value) {
        PlayerPrefs.SetFloat("RemainingCloudTime", value);
    }
    void saveTrainSpeed(float value) {
        PlayerPrefs.SetFloat("TrainSpeed", value);
    }
    void saveLevelID(int value) {
        PlayerPrefs.SetInt("LevelID", value);
    }
    void saveLevel1Time(float value) {
        PlayerPrefs.SetFloat("Level1Time", value);
    }
    void saveLevel2Time(float value) {
        PlayerPrefs.SetFloat("Level2Time", value);
    }
    void saveLevel3Time(float value) {
        PlayerPrefs.SetFloat("Level3Time", value);
    }
    public int getMaxTime() {
        return MaxGameTime;
    }
}