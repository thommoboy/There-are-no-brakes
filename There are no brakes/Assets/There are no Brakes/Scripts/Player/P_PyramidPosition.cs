/***********************
 * P_PyramidPosition.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class P_PyramidPosition : MonoBehaviour {
	// Direction from player to players camera eg if player moves along z axis it will be x+ or x-
	public string Direction = "x+";
	// HALF of pyramids actual width aka 'radius'
	private int PryamidWidth = 52;
	// Height of pyramid from base to point
	private float PyramidHeight = 52;
	private float RelativeAdjust;
	private Vector3 PlayerPos;
	private float PosUpdate;
	
	void Start(){
		RelativeAdjust = PryamidWidth / PyramidHeight;
	}
	
	void Update(){
		PlayerPos = this.transform.position;
		if(Direction == "x+"){
			PosUpdate = PryamidWidth - (PlayerPos.y*RelativeAdjust);
			this.transform.position = new Vector3(PosUpdate,PlayerPos.y,PlayerPos.z);
		} else if(Direction == "x-"){
			PosUpdate =  (PlayerPos.y*RelativeAdjust) - PryamidWidth;
			this.transform.position = new Vector3(PosUpdate,PlayerPos.y,PlayerPos.z);
		} else if(Direction == "z+"){
			PosUpdate = PryamidWidth - (PlayerPos.y*RelativeAdjust);
			this.transform.position = new Vector3(PlayerPos.x,PlayerPos.y,PosUpdate);
		} else {
			PosUpdate =  (PlayerPos.y*RelativeAdjust) - PryamidWidth;
			this.transform.position = new Vector3(PlayerPos.x,PlayerPos.y,PosUpdate);
		}
	}
}