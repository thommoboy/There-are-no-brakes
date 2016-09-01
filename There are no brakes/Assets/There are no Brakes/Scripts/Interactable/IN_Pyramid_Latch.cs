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
    private IN_TextTrigger_ConetentControl TextController;
	
	void Start(){
		FrontBeard = GameObject.Find("Front_Beard");
		BackBeard = GameObject.Find("Back_Beard");
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
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
			TextController.display = false;
		}
	}
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){//no player 2 check needed
			if (other.name == "Player1" && GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P1OnGround){
				Activated = true;
			}
			if (other.name == "Player3" && GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P3OnGround){
				Activated = true;
			}
		}
	}
}