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
	public int MaxLevelDistance = 1000; //distance in meters
	public int MaxGameDistance = 10000; //distance in meters
	private bool GameOver = false;
	public int PercentageRecoverOnLevelComplete = 15;
	private float traindefaultpos;
	private float clouddefaultpos;
	public float maxpos = 16;
	private float trainmaxpos;
	private float cloudmaxpos;
	
	void Start(){
		pos2 = new Vector2(Screen.width - (size.x + pos1.x),pos1.y);
		MaxLevelTime = (int)(MaxLevelTime * (1/barDisplay2));//corrects for starting with bar not full
		traindefaultpos = GameObject.Find("HUDtrainIcon").transform.position.z;
		clouddefaultpos = GameObject.Find("HUDcloudIcon").transform.position.z;
		trainmaxpos = traindefaultpos - maxpos;
		cloudmaxpos = clouddefaultpos + maxpos;
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
			
			//show distances
			if(barDisplay1 < 0.5){
				GUI.Box(new Rect(pos1.x + (size.x*barDisplay1),pos1.y, size.x - (size.x*barDisplay1), size.y), bar1distance + "m", HUDGUIStyle);
			} else {
				GUI.Box(new Rect(pos1.x,pos1.y, size.x*barDisplay1, size.y), bar1distance + "m", HUDGUIStyle);
			}
			if(barDisplay2 < 0.5){
				GUI.Box(new Rect(pos2.x + (size.x*barDisplay2),pos2.y, size.x - (size.x*barDisplay2), size.y), bar2distance + "m", HUDGUIStyle);
			} else {
				GUI.Box(new Rect(pos2.x,pos2.y, size.x*barDisplay2, size.y), bar2distance + "m", HUDGUIStyle);
			}
			
			//render icons
			GUI.Box(new Rect(pos1.x + size.x*barDisplay1 - 50,pos1.y-4, 100, 68), cloudIcon, HUDGUIStyle);
			GUI.Box(new Rect(pos2.x + size.x*barDisplay2 - 50,pos2.y, 100, 68), trainIcon, HUDGUIStyle);
		}*/
	}
	 
	void FixedUpdate() {
		//calculate the timers
		barDisplay1 += Time.deltaTime/MaxGameTime;
		barDisplay2 -= Time.deltaTime/MaxLevelTime;
		
		//calculate the distances
		bar1distance = (int)((1-barDisplay1)*MaxGameDistance);
		bar2distance = (int)((1-barDisplay2)*MaxLevelDistance);
		
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
		float cloudpos = barDisplay1 * maxpos + clouddefaultpos;
		GameObject.Find("HUDcloudIcon").transform.position = new Vector3(2.9f,33.6f,cloudpos);
		float trainpos = barDisplay2 * maxpos + traindefaultpos - maxpos;
		GameObject.Find("HUDtrainIcon").transform.position = new Vector3(24.13f,44,trainpos);
	}
	
	public void GameLost(){
		Debug.Log("GAME OVER");
	}
	
	private bool recovering = false;
	private float recoveredDistance;
	public void LevelCompleted(){
		Debug.Log("LEVEL COMPLETED");
		recoveredDistance = barDisplay2 + (((float)PercentageRecoverOnLevelComplete)/100);
		recovering = true;
	}
}