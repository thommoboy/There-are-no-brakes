/***********************
 * IN_Pyramid_Latch.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class IN_Pyramid_Latch : MonoBehaviour {
	public bool Activated = false;
	public float MoveSpeed = 4.5f;
	private float RotateSpeed = 3.5f;
	private GameObject BackBeard;
	private GameObject FrontBeard;
	
	void Start(){
		FrontBeard = GameObject.Find("Front_Beard");
		BackBeard = GameObject.Find("Back_Beard");
	}
	
	void Update(){
		if(Activated){
			if(this.transform.parent.name == "Latch_Back"){
				this.transform.parent.transform.localEulerAngles = Vector3.Lerp(this.transform.parent.transform.localEulerAngles, new Vector3(0, 270, 1), RotateSpeed*Time.deltaTime);
				BackBeard.transform.position = new Vector3(BackBeard.transform.position.x, BackBeard.transform.position.y - (MoveSpeed*Time.deltaTime), BackBeard.transform.position.z - (MoveSpeed/1.5f)*Time.deltaTime);
			} else {
				this.transform.parent.transform.localEulerAngles = Vector3.Lerp(this.transform.parent.transform.localEulerAngles, new Vector3(0, 90, 1), RotateSpeed*Time.deltaTime);
				FrontBeard.transform.position = new Vector3(FrontBeard.transform.position.x, FrontBeard.transform.position.y - (MoveSpeed*Time.deltaTime), FrontBeard.transform.position.z + (MoveSpeed/1.5f)*Time.deltaTime);
			}
		}
	}
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){//no player 2 check needed
			if (other.name == "Player1" && GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P1OnGround){
				if (Input.GetKey (KeyCode.DownArrow)) {
					Activated = true;
				}
			}
			if (other.name == "Player3" && GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P3OnGround){
				if (Input.GetKey (KeyCode.K)) {
					Activated = true;
				}
			}
		}
	}
	
	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Interact] to use");
		}
	}
}