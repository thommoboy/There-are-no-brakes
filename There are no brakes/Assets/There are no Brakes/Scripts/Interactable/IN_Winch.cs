/***********************
 * IN_Winch.cs
 * Originally Written by 
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Winch : IN_InteractableObject{
	private float targetminheight;
	void Start(){
		targetminheight = target.transform.position.y;
	}
	
	private bool playingsound = false;
	void playsoundeffect(){
		if(!playingsound){
			GetComponent<AudioSource>().Play();
			playingsound = true;
		}
	}

	public GameObject target;
	public GameObject rope;
	public bool gate = false;
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			intrigger = true;
			if (other.name == "Player1"){
				if (Input.GetKey (KeyCode.DownArrow)) {
					WindWinch ();
				}
			}
			if (other.name == "Player2"){
				if (Input.GetKey (KeyCode.S)) {
					WindWinch ();
				}
			}
			if (other.name == "Player3"){
				if (Input.GetKey (KeyCode.K)) {
					WindWinch ();
				}
			}
			
			if (!Input.GetKey (KeyCode.DownArrow) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.K)) {
				GetComponent<AudioSource>().Stop();
				playingsound = false;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player"){
			intrigger = false;
			GetComponent<AudioSource>().Stop();
			playingsound = false;
		}
	}
	
	public float maxheight;
	public float movespeed = 1.5f;
	private bool up = true;
	void WindWinch(){
		if(gate){
			if(target.transform.rotation.z < 0.5f){
				this.transform.GetChild(3).Rotate(0, 0, -Time.deltaTime*150);
				playsoundeffect();
				Vector3 ropelength = rope.transform.localScale;
				target.transform.Rotate(0, 0, Time.deltaTime*25);
				ropelength.y -= movespeed/12.25f;
				rope.transform.localScale = Vector3.Lerp(rope.transform.localScale, ropelength, Time.deltaTime);
				rope.transform.Rotate(Time.deltaTime*4, 0, 0);
			} else {
				GetComponent<AudioSource>().Stop();
				playingsound = false;
			}
		} else {
			playsoundeffect();
			Vector3 platpos = target.transform.localPosition;
			Vector3 ropelength = rope.transform.localScale;
			if(up){
				this.transform.GetChild(3).Rotate(0, 0, -Time.deltaTime*150);
				platpos.y += movespeed;
				ropelength.y -= movespeed/1.65f;
				if(target.transform.position.y > maxheight){
				 up = false;
				}
			} else {
				this.transform.GetChild(3).Rotate(0, 0, Time.deltaTime*150);
				platpos.y -= movespeed;
				ropelength.y += movespeed/1.65f;
				if(target.transform.position.y < targetminheight){
				 up = true;
				}
			}
			target.transform.localPosition = Vector3.Lerp(target.transform.localPosition, platpos, Time.deltaTime);
			rope.transform.localScale = Vector3.Lerp(rope.transform.localScale, ropelength, Time.deltaTime);
		}
	}
	
	
	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Down] to use");
		}
	}
}