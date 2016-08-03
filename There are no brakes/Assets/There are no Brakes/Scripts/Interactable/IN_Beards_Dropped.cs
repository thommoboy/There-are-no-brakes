/***********************
 * IN_Beards_Dropped.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Beards_Dropped : MonoBehaviour{

	public void Start(){
	}

	private bool dropped = false;
	public void Update(){
		//check if dropped all the way
		if(GameObject.Find("Front_Beard").transform.position.y < 0 && GameObject.Find("Back_Beard").transform.position.y < 0){
			if(!dropped){
				//level comletion
				GameObject.Find("HUDmanager").GetComponent<P_HUD>().LevelCompleted();
				dropped = true;
			}
		}
	}
}