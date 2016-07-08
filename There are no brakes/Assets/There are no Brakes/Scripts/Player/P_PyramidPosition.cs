/***********************
 * P_PyramidPosition.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class P_PyramidPosition : MonoBehaviour {
	public string Direction = "x+";
	private int PryamidWidth = 53;
	private Vector3 PlayerPos;
	private float PosUpdate;
	
	void Start(){
	}
	
	void Update(){
		PlayerPos = this.transform.position;
		if(Direction == "x+"){
			PosUpdate = PryamidWidth - PlayerPos.y;
			this.transform.position = new Vector3(PosUpdate,PlayerPos.y,PlayerPos.z);
		} else if(Direction == "x-"){
			
		} else if(Direction == "z+"){
			PosUpdate = PryamidWidth - PlayerPos.y;
			this.transform.position = new Vector3(PlayerPos.x,PlayerPos.y,PosUpdate);
		} else {
			
		}
	}
}