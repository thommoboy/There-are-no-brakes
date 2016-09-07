/***********************
 * Industrial_HorizontalSlider.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class Industrial_HorizontalSlider : MonoBehaviour {
	public float timeout = 7f;
	private float NextMove;
	public float speed = 0.1F;
	public float moveto;
	private Vector3 AltPos;
	private Vector3 Origin;
	private bool movingRight = true;
	private float currentLerpTime;
	private float lerpTime = 1f;
	
	void Start(){
		Origin = this.transform.position;
		AltPos = Origin;
		AltPos.z = moveto;
		NextMove = Time.time + timeout;
	}
	
	void Update(){
		if(Time.time > NextMove){
			movingRight = !movingRight;
			NextMove = Time.time + timeout;
			currentLerpTime = 0f;
		}
		
		currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
		float percentage = currentLerpTime / lerpTime;
		percentage = speed*percentage*percentage;
		if(movingRight){
			this.transform.position = Vector3.Lerp(this.transform.position, Origin, percentage);
		} else {
			this.transform.position = Vector3.Lerp(this.transform.position, AltPos, percentage);
		}
	}
	
	
	void OnTriggerStay(Collider other){
		if (other.tag == "Player" || other.tag == "Weight") {
			other.transform.parent = this.transform;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player" || other.tag == "Weight"){
			other.transform.parent = null;
		}
	}
}