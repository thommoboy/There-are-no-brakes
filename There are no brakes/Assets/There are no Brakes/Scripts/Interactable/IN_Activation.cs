/***********************
 * IN_Activation.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Activation : MonoBehaviour{
	public bool activated = false;
	public bool lever = false;
	public bool pressureplate = false;
	public bool lantern = false;
	private bool intrigger = false;
	private float timeout = 0.25F;
	private float nextInteract = 0.0F;
    private IN_TextTrigger_ConetentControl TextController;
	
	void Start(){
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
	}
	
	void Update(){
		if(intrigger){
			TextController.display = true;
			TextController.content = "Press [Interact] to use";
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(lever){
			if(other.tag == "Player"){
				intrigger = true;
				if(Time.time > nextInteract){
					if (other.name == "Player1"){
						if (Input.GetAxis("P1 Interact") > 0) {
							changeState();
						}
					}
					if (other.name == "Player2"){
						if (Input.GetAxis("P2 Interact") > 0) {
							changeState();
						}
					}
					if (other.name == "Player3"){
						if (Input.GetAxis("P3 Interact") > 0) {
							changeState();
						}
					}
				}
			}
		}
		if(lantern && !activated){
			if(other.tag == "Player"){
				intrigger = true;
				if (other.name == "Player1"){
					if (Input.GetAxis("P1 Interact") > 0) {
						changeState();
					}
				}
				if (other.name == "Player2"){
					if (Input.GetAxis("P2 Interact") > 0) {
						changeState();
					}
				}
				if (other.name == "Player3"){
					if (Input.GetAxis("P3 Interact") > 0) {
						changeState();
					}
				}
			}
		}
		if(pressureplate){
			if(other.tag == "Player" || other.tag == "Weight"){
				activated = true;
				this.transform.FindChild("Panel").gameObject.transform.localScale = new Vector3(73, 6, 73);
				this.transform.FindChild("Panel").gameObject.transform.localPosition = new Vector3(-0.0165445f, 0.031726f, 0.009995698f);
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player" || other.tag == "Weight"){
			if(lever){
				intrigger = false;
				TextController.display = false;
			}
			if(pressureplate){
				activated = false;
				this.transform.FindChild("Panel").gameObject.transform.localScale = new Vector3(73, 12, 73);
				this.transform.FindChild("Panel").gameObject.transform.localPosition = new Vector3(-0.0165445f, 0.07411726f, 0.009995698f);
			}
		}
	}
	
	void changeState(){
		activated = !activated;
		nextInteract = Time.time + timeout;
		if(lever){this.transform.Rotate(0, 180, 0);}
		if(lantern){intrigger = false;TextController.display = false;}
	}
}