/***********************
 * IN_Industrial_Brake.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Industrial_Brake : MonoBehaviour {
	public bool Activated = false;
	private GameObject RotatePart1;
	private GameObject RotatePart2;
	public int RotateAngle = 270;
	public float RotateSpeed = 3.5f;

	void Start () {
		RotatePart1 = this.transform.FindChild("Rotate1").gameObject;
		RotatePart2 = this.transform.FindChild("Rotate2").gameObject;
	}
	
	void Update () {
		if(Activated){
			RotatePart1.transform.localEulerAngles = Vector3.Lerp(RotatePart1.transform.localEulerAngles, new Vector3(0, 0, RotateAngle), RotateSpeed*Time.deltaTime);
			RotatePart2.transform.localEulerAngles = Vector3.Lerp(RotatePart2.transform.localEulerAngles, new Vector3(0, 0, RotateAngle), RotateSpeed*Time.deltaTime);
		} else {
			RotatePart1.transform.localEulerAngles = Vector3.Lerp(RotatePart1.transform.localEulerAngles, new Vector3(0, 0, 359), RotateSpeed*Time.deltaTime);
			RotatePart2.transform.localEulerAngles = Vector3.Lerp(RotatePart2.transform.localEulerAngles, new Vector3(0, 0, 359), RotateSpeed*Time.deltaTime);
		}
	}		
}
