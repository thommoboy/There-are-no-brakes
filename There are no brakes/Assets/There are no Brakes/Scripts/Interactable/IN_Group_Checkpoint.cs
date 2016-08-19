/***********************
 * IN_Group_Checkpoint.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Group_Checkpoint : MonoBehaviour {
	public bool final = false;
	private bool complete = false;
	private bool switched = false;
	private int playernum = 0;
	private bool istriggered = false;
	private string message1 = "Need all 3 players to continue.";
    private IN_TextTrigger_ConetentControl TextController;

	void Start () {
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
	}
	
	void Update () {
		if(playernum == 3 && !switched){
			switched = true;
			this.transform.Rotate(0, 180, 0);
			if (final && !complete) {
				GameObject.Find("HUDmanager").GetComponent<P_HUD>().LevelCompleted();
				complete = true;
			}
		}
		if(istriggered && !switched){
            TextController.display = true;
            TextController.content = message1;
            TextController.lineNum = 1;
		}
	}
		
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			playernum++;
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			playernum--;
			istriggered = false;
			TextController.display = false;
		}
	}
	
	void OnTriggerStay(Collider other){
		if(other.tag == "Player"){
			istriggered = true;
		}
	}
}
