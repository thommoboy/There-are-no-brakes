/***********************
 * IN_Door.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Door : MonoBehaviour {
	public GameObject Trigger;
	private Vector3 doorPos;
	private Vector3 doorRot;
	public int openHeight = 5;
	public float rotatetime = 1f;
    private float currentLerpTime;
	public bool Tutorial = false;
	public bool Ancient = false;
	public bool Adventurer = false;
	public bool Industrial = false;
	private bool activationCheck = false;
	
	private AudioClip StoneDrag;

	void Start () {
		doorPos = this.transform.position;
		doorRot = this.transform.localEulerAngles;
		StoneDrag = Resources.Load("Sounds/stone drag") as AudioClip;
		GetComponent<AudioSource>().loop = true;
	}
	
	void Update () {
		currentLerpTime += Time.deltaTime;
        if (currentLerpTime > rotatetime) {
            currentLerpTime = rotatetime;
        }
		float perc = currentLerpTime / rotatetime;
		
		if(Ancient){
			if(Trigger.GetComponent<IN_Activation>().activated && openHeight != 99){
				currentLerpTime = 0f;
				perc = currentLerpTime / rotatetime;
				openHeight = 99;
			}
			if(openHeight == 99){
				this.transform.localEulerAngles = Vector3.Lerp(doorRot, new Vector3(0, 270, 180), perc);
				this.transform.position = Vector3.Lerp(doorPos, new Vector3(doorPos.x - 1.75f, doorPos.y, doorPos.z), perc);
				GameObject.Find("Arrow").GetComponent<Tutorial_MoveArrow> ().active = true;
			}
		} else if(Adventurer){
            /*

			if(Trigger.GetComponent<IN_Activation>().activated && openHeight != 99){
				currentLerpTime = 0f;
				perc = currentLerpTime / rotatetime;
				openHeight = 99;
			}
			if(openHeight == 99){
				this.transform.position = Vector3.Lerp(doorPos, new Vector3(doorPos.x - 15f, doorPos.y, doorPos.z), perc);
			}*/
			GetComponent<AudioSource>().clip = StoneDrag;
            
            perc = currentLerpTime / (rotatetime * 50);
            if (Trigger.GetComponent<IN_Activation>().activated && openHeight != 99){
                currentLerpTime = 0f;
                openHeight = 99;
            }

            if (Trigger.GetComponent<IN_Activation>().activated){
                this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(doorPos.x - 15f, doorPos.y, doorPos.z), perc);
				
				if(!GetComponent<AudioSource>().isPlaying && perc < 0.02f){
					GetComponent<AudioSource>().Play();
				}
				if(perc >= 0.02f){
					GetComponent<AudioSource>().Stop();
				}
            } else if(openHeight != 5){
                openHeight = 6;
                this.transform.position = Vector3.Lerp(this.transform.position, doorPos, 0.1f);
				GetComponent<AudioSource>().Stop();
            }

        } else if(Industrial){
			if(Trigger.GetComponent<IN_Activation>().activated && openHeight != 99 && openHeight != 95){
				currentLerpTime = 0f;
				perc = currentLerpTime / rotatetime;
				openHeight = 99;
			}
			if(!Trigger.GetComponent<IN_Activation>().activated && openHeight == 95){
				currentLerpTime = 0f;
				perc = currentLerpTime / rotatetime;
				openHeight = -99;
			}
			if(openHeight == 99){
				this.transform.position = Vector3.Lerp(doorPos, new Vector3(doorPos.x, doorPos.y - 18.81f, doorPos.z), perc);
			}
			if(openHeight == -99){
				this.transform.position = Vector3.Lerp(new Vector3(doorPos.x, doorPos.y - 18.81f, doorPos.z), doorPos, perc);
			}
			if(this.transform.position.y <= doorPos.y - 18.81f && openHeight == 99){
				openHeight = 95;
			}
		} else if(Tutorial) {

			if (Trigger.GetComponent<IN_Activation> ().activated != activationCheck) {
				currentLerpTime = 0f;
				perc = currentLerpTime / rotatetime;
			}
			if (Trigger.GetComponent<IN_Activation> ().activated) {
				//this.transform.localEulerAngles = Vector3.Lerp (doorRot, new Vector3 (0, 180, 0), perc);
				this.transform.position = Vector3.Lerp(doorPos, new Vector3(doorPos.x - 6f, doorPos.y, doorPos.z), perc);
			} else {
				//this.transform.localEulerAngles = Vector3.Lerp (new Vector3 (0, 180, 0), doorRot, perc);
				this.transform.position = Vector3.Lerp(new Vector3(doorPos.x - 6f, doorPos.y, doorPos.z), doorPos,  perc);
			}
			activationCheck = Trigger.GetComponent<IN_Activation> ().activated;
            

		} else {
			if (Trigger.GetComponent<IN_Activation> ().activated != activationCheck) {
				currentLerpTime = 0f;
				perc = currentLerpTime / rotatetime;
			}
			if (Trigger.GetComponent<IN_Activation> ().activated) {
				this.transform.localEulerAngles = Vector3.Lerp (doorRot, new Vector3 (0, 180, 0), perc);
				this.transform.position = Vector3.Lerp(doorPos, new Vector3(doorPos.x - 3f, doorPos.y, doorPos.z + 2.7f), perc);
			} else {
				this.transform.localEulerAngles = Vector3.Lerp (new Vector3 (0, 180, 0), doorRot, perc);
				this.transform.position = Vector3.Lerp(new Vector3(doorPos.x - 3f, doorPos.y, doorPos.z + 2.7f), doorPos,  perc);
			}
			activationCheck = Trigger.GetComponent<IN_Activation> ().activated;
		}
	}		
}
