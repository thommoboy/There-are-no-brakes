/***********************
 * Tutorial_ArrowHide.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class Tutorial_ArrowHide : MonoBehaviour {
	private bool P1 = false;
	private bool P2 = false;
	private bool P3 = false;
	private bool stayoff = false;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update(){
		if((P1 && P2) || (P1 && P3) || (P2 && P3) || stayoff){
			GameObject.Find("Arrow").GetComponent<Tutorial_MoveArrow> ().active = false;
			stayoff = true;
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if(other.name == "Player1"){
			P1 = true;
		}
		if(other.name == "Player2"){
			P2 = true;
		}
		if(other.name == "Player3"){
			P3 = true;
		}
	}
	void OnTriggerExit (Collider other) {
		if(other.name == "Player1"){
			P1 = false;
		}
		if(other.name == "Player2"){
			P2 = false;
		}
		if(other.name == "Player3"){
			P3 = false;
		}
	}
}
