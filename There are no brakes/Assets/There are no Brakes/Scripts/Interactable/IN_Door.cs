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
	public bool Ancient = false;
	public bool Adventurer = false;
	public bool Industrial = false;

	void Start () {
		doorPos = this.transform.position;
		doorRot = this.transform.localEulerAngles;
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
			}
		} else if(Adventurer){
			if(Trigger.GetComponent<IN_Activation>().activated && openHeight != 99){
				currentLerpTime = 0f;
				perc = currentLerpTime / rotatetime;
				openHeight = 99;
			}
			if(openHeight == 99){
				this.transform.position = Vector3.Lerp(doorPos, new Vector3(doorPos.x - 8f, doorPos.y, doorPos.z), perc);
			}
		} else if(Industrial){
		} else {
			if(Trigger.GetComponent<IN_Activation>().activated){
				this.transform.position = new Vector3 (doorPos.x,doorPos.y+openHeight,doorPos.z);
			} else {
				this.transform.position = new Vector3 (doorPos.x,doorPos.y,doorPos.z);
			}
		}
	}		
}
