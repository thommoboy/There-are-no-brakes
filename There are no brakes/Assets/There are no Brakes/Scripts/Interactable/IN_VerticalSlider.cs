/***********************
 * IN_VerticalSlider.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class IN_VerticalSlider : MonoBehaviour {
	public float moveto;
	private Vector3 AltPos;
	private Vector3 Origin;
	private bool movingUp = false;
	private float currentLerpTime = 99f;
	public float lerpTime = 1f;
	public GameObject Trigger1;
	public GameObject Trigger2;
	public GameObject Trigger3;
	public GameObject Trigger4;
	public GameObject Trigger5;
	private bool moveUpCheck = false;
	
	private AudioClip Hydraulics;
	
	void Start(){
		Origin = this.transform.position;
		AltPos = Origin;
		AltPos.y = moveto;
		Hydraulics = Resources.Load("Sounds/hydraulics") as AudioClip;
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().clip = Hydraulics;
	}
	
	void Update(){
		movingUp = false;
		if(Trigger1.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		if(Trigger2 != null && Trigger2.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		if(Trigger3 != null && Trigger3.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		if(Trigger4 != null && Trigger4.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		if(Trigger5 != null && Trigger5.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		
		if(movingUp != moveUpCheck){
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = 0f;
			} else {
				currentLerpTime = lerpTime - currentLerpTime;
			}
		}
		moveUpCheck = movingUp;
		
		currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
			GetComponent<AudioSource>().Stop();
        } else {
			if(!GetComponent<AudioSource>().isPlaying){
				GetComponent<AudioSource>().Play();
			}
		}
		float percentage = currentLerpTime / lerpTime;
		if(!movingUp){
			this.transform.position = Vector3.Lerp(AltPos, Origin, percentage);
		} else {
			this.transform.position = Vector3.Lerp(Origin, AltPos, percentage);
		}
	}
}