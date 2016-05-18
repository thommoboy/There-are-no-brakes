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
	public bool gate = false;
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			intrigger = true;
			if(Input.GetKey(KeyCode.S)){
				WindWinch();
			} else if(Input.GetKey(KeyCode.DownArrow)) {
				WindWinch();
			} else {
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
		playsoundeffect();
		if(gate){
			if(target.transform.rotation.z < 0.5f){
				target.transform.Rotate(0, 0, Time.deltaTime*25);
			}
		} else {
			Vector3 platpos = target.transform.localPosition;
			if(up){
				platpos.y += movespeed;
				if(target.transform.position.y > maxheight){
				 up = false;
				}
			} else {
				platpos.y -= movespeed;
				if(target.transform.position.y < targetminheight){
				 up = true;
				}
			}
			target.transform.localPosition = Vector3.Lerp(target.transform.localPosition, platpos, Time.deltaTime);
		}
	}
	
	
	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Down] to use");
		}
	}
}