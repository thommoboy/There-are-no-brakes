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
	private int RotateAngle = 305;
	private float RotateSpeed = 3.5f;

	void Start () {
		RotatePart = this.transform.FindChild("RotatingSection").gameObject;
	}
	
	void Update () {
		Activated = Trigger.GetComponent<IN_Activation>().activated;
		if(ActiveOnStart){
			Activated = !Activated;
		}
		
		if(Activated){
			RotatePart.transform.localEulerAngles = Vector3.Lerp(RotatePart.transform.localEulerAngles, new Vector3(0, 0, 359), RotateSpeed*Time.deltaTime);
		} else {
			RotatePart.transform.localEulerAngles = Vector3.Lerp(RotatePart.transform.localEulerAngles, new Vector3(0, 0, RotateAngle), RotateSpeed*Time.deltaTime);
		}
	}		
}
