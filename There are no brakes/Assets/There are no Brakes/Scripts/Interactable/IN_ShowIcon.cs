/***********************
 * IN_ShowIcon.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_ShowIcon : MonoBehaviour {
	private float timeout = 4f;
	private float timer1;
	private float timer2;
	private float timer3;
	private GameObject Icon1;
	private GameObject Icon2;
	private GameObject Icon3;
	private GameObject highlight1;
	private GameObject highlight2;
	private GameObject highlight3;
	private Vector3 player1;
	private Vector3 player2;
	private Vector3 player3;
	private GameObject PlayerController;

	void Start () {
		Icon1 = GameObject.Find("Icon1");
		Icon2 = GameObject.Find("Icon2");
		Icon3 = GameObject.Find("Icon3");
		highlight1 = GameObject.Find("highlight (1)");
		highlight2 = GameObject.Find("highlight (2)");
		highlight3 = GameObject.Find("highlight (3)");
		player1 = GameObject.Find("Player1").transform.position;
		player2 = GameObject.Find("Player2").transform.position;
		player3 = GameObject.Find("Player3").transform.position;
		timer1 = 0;
		timer2 = 0;
		timer3 = 0;
		PlayerController = GameObject.Find ("PlayerControllers");
	}
	
	void Update () {
		if(Input.GetAxis("X_1") > 0.1f){
			ShowIcon(1);
		}
		if(Input.GetAxis("X_2") > 0.1f){
			ShowIcon(2);
		}
		if(Input.GetAxis("X_3") > 0.1f){
			ShowIcon(3);
		}
		if(Input.GetKey("b")){
			ShowIcon(0);
		}
		
		if(Time.time < timer1){
			if(!Icon1.GetComponent<Renderer>().enabled){
				if(PlayerController.GetComponent<P_Movement> ().P1Direction == "x+"){
					GameObject.Find("Player1").transform.rotation = Quaternion.Euler(0, 180, 0);
				} else {
					GameObject.Find("Player1").transform.rotation = Quaternion.Euler(0, 270, 0);
					highlight1.transform.rotation = Quaternion.Euler(0, 90, 90);
				}
			}
			highlight1.GetComponent<Renderer>().enabled = true;
			Icon1.GetComponent<Renderer>().enabled = true;
		} else {
			highlight1.GetComponent<Renderer>().enabled = false;
			Icon1.GetComponent<Renderer>().enabled = false;
		}
		if(Time.time < timer2){
			if(!Icon2.GetComponent<Renderer>().enabled){
				if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x+"){
					GameObject.Find("Player2").transform.rotation = Quaternion.Euler(0, 180, 0);
				} else {
					GameObject.Find("Player2").transform.rotation = Quaternion.Euler(0, 0, 0);
					highlight2.transform.rotation = Quaternion.Euler(0, 0, 90);
				}
			}
			highlight2.GetComponent<Renderer>().enabled = true;
			Icon2.GetComponent<Renderer>().enabled = true;
		} else {
			highlight2.GetComponent<Renderer>().enabled = false;
			Icon2.GetComponent<Renderer>().enabled = false;
		}
		if(Time.time < timer3){
			if(!Icon3.GetComponent<Renderer>().enabled){
				if(PlayerController.GetComponent<P_Movement> ().P3Direction == "x+"){
					GameObject.Find("Player3").transform.rotation = Quaternion.Euler(0, 180, 0);
				} else {
					GameObject.Find("Player3").transform.rotation = Quaternion.Euler(0, 90, 0);
					highlight3.transform.rotation = Quaternion.Euler(0, 270, 90);
				}
			}
			highlight3.GetComponent<Renderer>().enabled = true;
			Icon3.GetComponent<Renderer>().enabled = true;
		} else {
			highlight3.GetComponent<Renderer>().enabled = false;
			Icon3.GetComponent<Renderer>().enabled = false;
		}
		
		player1 = GameObject.Find("Player1").transform.position;
		player2 = GameObject.Find("Player2").transform.position;
		player3 = GameObject.Find("Player3").transform.position;
		if(PlayerController.GetComponent<P_Movement> ().P1Direction == "x+"){
			highlight1.transform.position = new Vector3(player1.x-0.2f, player1.y+0.2f, player1.z);
		} else {
			highlight1.transform.position = new Vector3(player1.x, player1.y+0.2f, player1.z+0.2f);
		}
		if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x+"){
			highlight2.transform.position = new Vector3(player2.x-0.2f, player2.y+0.2f, player2.z);
		} else {
			highlight2.transform.position = new Vector3(player2.x+0.2f, player2.y+0.2f, player2.z);
		}
		if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x+"){
			highlight3.transform.position = new Vector3(player3.x-0.2f, player3.y+0.2f, player3.z);
		} else {
			highlight3.transform.position = new Vector3(player3.x, player3.y+0.2f, player3.z-0.2f);
		}
	}
	
	public void ShowIcon(int playerID){
		if(playerID == 1){
			timer1 = Time.time + timeout;
		} else if(playerID == 2){
			timer2 = Time.time + timeout;
		} else if(playerID == 3){
			timer3 = Time.time + timeout;
		} else {
			timer1 = Time.time + timeout;
			timer2 = Time.time + timeout;
			timer3 = Time.time + timeout;
		}
	}
}
