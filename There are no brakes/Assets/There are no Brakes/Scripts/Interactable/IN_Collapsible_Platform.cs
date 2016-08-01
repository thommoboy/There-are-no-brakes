/***********************
 * IN_Collapsible_Platform.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Collapsible_Platform : MonoBehaviour {
	public GameObject Trigger;
	public bool ActiveOnStart = false;
	private bool Activated = false;
	private GameObject RotatePart;
	private float RotateAngle = 0.4f;
	private int RotateSpeed = 150;

	void Start () {
		RotatePart = this.transform.FindChild("RotatingSection").gameObject;
	}
	
	void Update () {
		Activated = Trigger.GetComponent<IN_Activation>().activated;
		if(ActiveOnStart){
			Activated = !Activated;
		}
		
		if(Activated){
			if(RotatePart.transform.rotation.z < 0f){
				RotatePart.transform.Rotate(0, 0, RotateSpeed*Time.deltaTime);
			}
		} else {
			if(RotatePart.transform.rotation.z > -RotateAngle){
				RotatePart.transform.Rotate(0, 0, -RotateSpeed*Time.deltaTime);
			}
		}
	}		
}
