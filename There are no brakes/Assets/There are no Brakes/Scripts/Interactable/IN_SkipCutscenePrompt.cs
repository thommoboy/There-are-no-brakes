/***********************
 * IN_SkipCutscenePrompt.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_SkipCutscenePrompt : MonoBehaviour{
	private bool active = false;
	private Vector3 movetopos;
	private Vector3 Origin;
	private float currentLerpTime = 99f;
	public float lerpTime = 0.6f;

	public void Start(){
		Origin = this.transform.position;
		movetopos = new Vector3 (-65, -70, 109);
	}

	public void Update(){
		if(Input.GetAxis("P1 Jump") > 0 || Input.GetAxis("A_1") > 0 || Input.GetAxis("P2 Jump") > 0 || Input.GetAxis("A_2") > 0 || Input.GetAxis("P3 Jump") > 0 || Input.GetAxis("A_3") > 0){
			active = true;
			currentLerpTime = 0f;		
		}
		if(Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0 || Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0 || Input.GetAxis("P3 Interact") > 0 || Input.GetAxis("B_3") > 0){
			active = true;
			currentLerpTime = 0f;
		}
	
		if(active){
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}
			float percentage = currentLerpTime / lerpTime;
			this.transform.position = Vector3.Lerp(Origin, movetopos, percentage);
		}
	}
}