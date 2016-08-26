/***********************
 * IN_Group_Checkpoint.cs
 * Originally Written by Nathan Brown
 * Modified By:
 *  Xinyu Feng:
 *      add door animation
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
    private IN_Door_Animation Door_Amime;
    private string door_statu;
	private float teleportDistance = 20f;
	void Start () {
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
        Door_Amime = this.GetComponent<IN_Door_Animation>();
        door_statu = "close";
    }
	
	void Update () {
		if(playernum == 3 && !switched){
			switched = true;
			Vector3 temp = GameObject.Find("Player1").transform.position;
			GameObject.Find("Player1").transform.position = new Vector3(temp.x,temp.y,temp.z+teleportDistance);
			temp = GameObject.Find("Player2").transform.position;
			GameObject.Find("Player2").transform.position = new Vector3(temp.x,temp.y,temp.z+teleportDistance);
			temp = GameObject.Find("Player3").transform.position;
			GameObject.Find("Player3").transform.position = new Vector3(temp.x,temp.y,temp.z+teleportDistance);
			temp = GameObject.Find("Main Camera").transform.position;
			GameObject.Find("Main Camera").transform.position = new Vector3(temp.x,temp.y,temp.z+(2*teleportDistance));
            Door_Amime.Open_door(0);
            if (final && !complete) {
				GameObject.Find("HUDmanager").GetComponent<P_HUD>().LevelCompleted();
				complete = true;
			}
		}
        /*
         * this checkpoint need to improve, should just switch the wall not the checkpoint
        if (playernum == 0) {
            door_statu = "close";
        }
        
        if (door_statu == "open")
            Door_Amime.Open_door(0);
        else
            Door_Amime.Close_door(0);
        */
        if (istriggered && !switched){
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

    public bool IsSwitch() {
        return switched;
    }

	void OnTriggerStay(Collider other){
		if(other.tag == "Player"){
			istriggered = true;
		}
	}
}
