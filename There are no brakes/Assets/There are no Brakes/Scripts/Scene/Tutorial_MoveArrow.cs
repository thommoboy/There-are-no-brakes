/***********************
 * Tutorial_MoveArrow.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class Tutorial_MoveArrow : MonoBehaviour {
	public bool active = false;
	private bool activecheck = false;
	private GameObject arrow;
	private int ArrowPos = 33;
	private int ArrowMove = 5;
	private bool movingRight = true;
	private float currentLerpTime;
	private float currentLerpTime2;
	private float lerpTime = 2f;
	private float timeout = 3f;

	// Use this for initialization
	void Start () {
		arrow = this.transform.FindChild("pieces").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(active != activecheck){
			activecheck = active;
			if (currentLerpTime >= lerpTime) {
				currentLerpTime = 0f;
			} else {
				currentLerpTime = lerpTime - currentLerpTime;
			}
		}
		
		currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
		float percentage = currentLerpTime / lerpTime;
		percentage = percentage*percentage;
		
		if(active){
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(ArrowPos,9,45), percentage);
			currentLerpTime2 += Time.deltaTime;
			if (currentLerpTime2 > lerpTime) {
				currentLerpTime2 = lerpTime;
			}
			float percentage2 = currentLerpTime2 / lerpTime;
			if(movingRight){
				arrow.transform.localPosition = Vector3.Lerp(new Vector3(0,0,-ArrowMove), new Vector3(0,0,ArrowMove), percentage2);
				if(arrow.transform.localPosition.z >= 5f){
					movingRight = false;
					currentLerpTime2 = 0f;
				}
			} else {
				arrow.transform.localPosition = Vector3.Lerp(new Vector3(0,0,ArrowMove), new Vector3(0,0,-ArrowMove), percentage2);
				if(arrow.transform.localPosition.z <= -5f){
					movingRight = true;
					currentLerpTime2 = 0f;
				}
			}
		} else {
			this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(59,9,45), percentage);
		}
	}
}
