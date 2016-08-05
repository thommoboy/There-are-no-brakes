/***********************
 * IN_VerticalSlider.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class IN_VerticalSlider : MonoBehaviour {
	public float speed = 0.1F;
	public float moveto;
	private Vector3 AltPos;
	private Vector3 Origin;
	private bool movingUp = false;
	private float currentLerpTime;
	private float lerpTime = 1f;
	public GameObject Trigger1;
	public GameObject Trigger2;
	public GameObject Trigger3;
	private bool moveUpCheck = false;
	
	void Start(){
		Origin = this.transform.position;
		AltPos = Origin;
		AltPos.y = moveto;
	}
	
	void Update(){
		movingUp = false;
		if(Trigger1.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		if(Trigger2.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		if(Trigger3.GetComponent<IN_Activation>().activated){
			movingUp = !movingUp;
		}
		
		if(movingUp != moveUpCheck){
			currentLerpTime = 0f;
		}
		moveUpCheck = movingUp;
		
		currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
		float percentage = currentLerpTime / lerpTime;
		percentage = speed*percentage*percentage;
		if(!movingUp){
			this.transform.position = Vector3.Lerp(this.transform.position, Origin, percentage);
		} else {
			this.transform.position = Vector3.Lerp(this.transform.position, AltPos, percentage);
		}
	}
}