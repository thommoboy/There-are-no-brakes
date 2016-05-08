using UnityEngine;
using System.Collections;
 
public class HUD : MonoBehaviour {
	public GUIStyle HUDGUIStyle;
	private Vector2 size = new Vector2(375,60);
	public Vector2 pos1;
	private Vector2 pos2 = new Vector2(0,0);
	private float barDisplay1 = 0.015f; //whole game
	private float barDisplay2 = 0.7f; //current level
	private float bar1distance = 0; //whole game
	private float bar2distance = 0; //current level
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public int MaxLevelTime = 300; //time limit in seconds
	public int MaxGameTime = 3000; //time limit in seconds
	public int MaxLevelDistance = 1000; //distance in meters
	public int MaxGameDistance = 10000; //distance in meters
	private bool GameOver = false;
	
	void Start(){
		pos2 = new Vector2(Screen.width - (size.x + pos1.x),pos1.y);
		MaxLevelTime = (int)(MaxLevelTime * (1/barDisplay2));//corrects starting with bar not full/empty
	}
	
	void OnGUI() {
		if(GameOver){
			GUI.Box(new Rect(Screen.width/2-75,50,250,40), "GAME OVER");			
		} else {
			//left HUD bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos1.x, pos1.y, size.x, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), fullTex, HUDGUIStyle);
			 
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, size.x * barDisplay1, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), emptyTex, HUDGUIStyle);
			GUI.EndGroup();
			GUI.EndGroup();
			
			//show distance
			GUI.Box(new Rect(pos1.x,pos1.y, size.x, size.y), bar1distance + "m", HUDGUIStyle);
			
			
			//right HUD bar
			//draw the background:
			GUI.BeginGroup(new Rect(pos2.x, pos2.y, size.x, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), emptyTex, HUDGUIStyle);
			 
			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, size.x * barDisplay2, size.y), HUDGUIStyle);
			GUI.Box(new Rect(0,0, size.x, size.y), fullTex, HUDGUIStyle);
			GUI.EndGroup();
			GUI.EndGroup();
			
			//show distance
			GUI.Box(new Rect(pos2.x,pos2.y, size.x, size.y), bar2distance + "m", HUDGUIStyle);
		}
	}
	 
	void FixedUpdate() {
		//calculate the timers
		barDisplay1 += Time.deltaTime/MaxGameTime;
		barDisplay2 -= Time.deltaTime/MaxLevelTime;
		
		//calculate the distances
		bar1distance = (int)((1-barDisplay1)*MaxGameDistance);
		bar2distance = (int)((1-barDisplay2)*MaxLevelDistance);
		
		//trigger game over if either bar empties
		if(barDisplay1 <= 0){GameOver = true;}
		if(barDisplay2 <= 0){GameOver = true;}
		
		if(GameOver){Debug.Log("GAME OVER");}
	}
}