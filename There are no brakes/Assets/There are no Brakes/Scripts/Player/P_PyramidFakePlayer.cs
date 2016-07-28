/***********************
 * P_PyramidFakePlayer.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class P_PyramidFakePlayer : MonoBehaviour {
	// script just to test out pyramid level with only 1 controllable player
	private Vector3 PlayerPOS;
	private Vector3 thisPOS;
	
	void Start(){
	}
	
	void Update(){
		PlayerPOS = GameObject.Find("Player1").transform.position;
		if(this.name == "FAKEplayer3"){
			this.transform.position = new Vector3(-PlayerPOS.z,PlayerPOS.y,PlayerPOS.x);
		} else {
			this.transform.position = new Vector3(PlayerPOS.z,PlayerPOS.y,-PlayerPOS.x);
		}
	}
}