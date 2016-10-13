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
	public bool goldlever = false;
	private bool intrigger = false;
	private float timeout = 0.4F;
	private float nextInteract = 0.0F;
    private IN_TextTrigger_ConetentControl TextController;
	
	private AudioClip Leversound;
	private AudioClip ButtonOnsound;
	private AudioClip ButtonOffsound;
	
	void Start(){
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
		Leversound = Resources.Load("Sounds/switch") as AudioClip;
		ButtonOnsound = Resources.Load("Sounds/button-press") as AudioClip;
		ButtonOffsound = Resources.Load("Sounds/button-release") as AudioClip;
	}
	
	void Update(){
		if(intrigger){
			//TextController.display = true;
			//TextController.content = "Press [Interact] to use";
            //TextController.lineNum = 1;
			this.transform.GetChild(0).GetComponent<Renderer>().material.shader = Shader.Find("TSF/BaseOutline1");
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(lever){
			if(other.tag == "Player"){
				intrigger = true;
				if(Time.time > nextInteract){
					if (other.name == "Player1"){
						if (Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) {
							changeState();
						}
					}
					if (other.name == "Player2"){
						if (Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) {
							changeState();
						}
					}
					if (other.name == "Player3"){
						if (Input.GetAxis("P3 Interact") > 0 || Input.GetAxis("B_3") > 0) {
							changeState();
						}
					}
				}
			}
		}
		if(goldlever){
			if(other.tag == "Player" && !activated){
				intrigger = true;
				if(Time.time > nextInteract){
					if (other.name == "Player1" && GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P1OnGround){
						if (Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) {
							changeState();
						}
					}
					if (other.name == "Player2" && GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P2OnGround){
						if (Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) {
							changeState();
						}
					}
					if (other.name == "Player3" && GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P3OnGround){
						if (Input.GetAxis("P3 Interact") > 0 || Input.GetAxis("B_3") > 0) {
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
					if (Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) {
						changeState();
					}
				}
				if (other.name == "Player2"){
					if (Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) {
						changeState();
					}
				}
				if (other.name == "Player3"){
					if (Input.GetAxis("P3 Interact") > 0 || Input.GetAxis("B_3") > 0) {
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
	void OnTriggerEnter(Collider other) {
		if(pressureplate){
			if((other.tag == "Player" || other.tag == "Weight") && !activated){
				M_AudioManager.PlayAudioSelf(ButtonOnsound);
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player" || other.tag == "Weight"){
			this.transform.GetChild(0).GetComponent<Renderer>().material.shader = Shader.Find("Standard");
			if(lever || goldlever){
				intrigger = false;
				TextController.display = false;
			}
			if(pressureplate){
				activated = false;
				this.transform.FindChild("Panel").gameObject.transform.localScale = new Vector3(73, 12, 73);
				this.transform.FindChild("Panel").gameObject.transform.localPosition = new Vector3(-0.0165445f, 0.07411726f, 0.009995698f);
				
				M_AudioManager.PlayAudioSelf(ButtonOffsound);
			}
		}
	}
	
	void changeState(){
		activated = !activated;
		nextInteract = Time.time + timeout;
		if(lever || goldlever){
			this.transform.Rotate(0, 180, 0);
			M_AudioManager.PlayAudioSelf(Leversound);
		}
		if(lantern){intrigger = false;TextController.display = false;}
	}
}