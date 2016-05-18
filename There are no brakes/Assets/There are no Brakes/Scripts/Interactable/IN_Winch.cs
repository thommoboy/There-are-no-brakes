using UnityEngine;
using System.Collections;

public class IN_Winch : IN_InteractableObject{
	private float targetminheight;
	void Start(){
		targetminheight = target.transform.position.y;
	}

	public GameObject target;
	public bool gate = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			if(Input.GetKey(KeyCode.S)){
				WindWinch();
			}
			if(Input.GetKey(KeyCode.DownArrow)) {
				WindWinch();
			}
		}
	}
	
	public float maxheight;
	public float movespeed = 1.5f;
	private bool up = true;
	void WindWinch(){
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
}