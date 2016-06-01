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
	
	void Start(){
		pos2 = new Vector2(Screen.width - (size.x + pos1.x),pos1.y);
		MaxLevelTime = (int)(MaxLevelTime * (1/barDisplay2));//corrects for starting with bar not full
		traindefaultpos = GameObject.Find("HUDtrainIcon").transform.position;
		clouddefaultpos = GameObject.Find("HUDcloudIcon").transform.position;
		trainmaxpos = traindefaultpos.z - maxpos;
		cloudmaxpos = clouddefaultpos.z + maxpos;
	}
	
	void OnGUI() {
		if(GameOver){
			GUI.Box(new Rect(Screen.width/2-75,50,250,40), "GAME OVER");			
		}/* else { //render HUD as GUI objects
			//left HUD bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos1.x, pos1.y, size.x, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), fullTex, HUDGUIStyle);
			 
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, size.x * barDisplay1, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), emptyTex, HUDGUIStyle);
			GUI.EndGroup();
			GUI.EndGroup();
			
			//right HUD bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos2.x, pos2.y, size.x, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), emptyTex, HUDGUIStyle);
			 
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, size.x * barDisplay2, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), fullTex, HUDGUIStyle);
			GUI.EndGroup();
			GUI.EndGroup();
			
			//render icons
			GUI.Box(new Rect(pos1.x + size.x*barDisplay1 - 50,pos1.y-4, 100, 68), cloudIcon, HUDGUIStyle);
			GUI.Box(new Rect(pos2.x + size.x*barDisplay2 - 50,pos2.y, 100, 68), trainIcon, HUDGUIStyle);
		}*/
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
	
	public void GameLost(){
		Debug.Log("GAME OVER");
	}
	
	private bool recovering = false;
	private float recoveredDistance;
	public void LevelCompleted(){
		Debug.Log("LEVEL COMPLETED");
		StartCoroutine(loadnextlevel(20));
		recoveredDistance = barDisplay2 + (((float)PercentageRecoverOnLevelComplete)/100);
		recovering = true;
	}
	
	IEnumerator loadnextlevel(float time){
		yield return new WaitForSeconds(time);
	 
		Application.LoadLevel (0);
	}
}