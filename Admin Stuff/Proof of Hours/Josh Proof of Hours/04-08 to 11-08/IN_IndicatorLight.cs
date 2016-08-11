/***********************
 * IN_IndicatorLight.cs
 * Originally Written by Nathan Brown
 * Modified By: Josh Garvey --> Added lighing to indicators based on completion
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_IndicatorLight : MonoBehaviour {
	public GameObject Trigger;
	public GameObject IndLight;
	public bool Activated = false;

	void Start () {
		//IndLights = GameObject.FindGameObjectsWithTag("BrakeLight");
	}
	
	void Update () {
		Activated = Trigger.GetComponent<IN_Activation>().activated;
		
		if(Activated){
			IndLight.GetComponent<Light> ().color = Color.green;
//			for (int i = 0; i < IndLights.Length; i++) {
//				if (Trigger.name == "Pressureplate" && IndLights[i].name == "Point light (1)") {
//					IndLights [i].GetComponent<Light> ().color = Color.green;
//				}
//				if (Trigger.name == "Lever" && IndLights[i].name == "Point light (2)") {
//					IndLights [i].GetComponent<Light> ().color = Color.green;
//				}
//				if (Trigger.name == "Lever (1)" && IndLights[i].name == "Point light (3)") {
//					IndLights [i].GetComponent<Light> ().color = Color.green;
//				}
//			}

			this.transform.eulerAngles = new Vector3(0,180,0);
		} else {
			IndLight.GetComponent<Light> ().color = Color.red;
//			for (int i = 0; i < IndLights.Length; i++) {
//				if (Trigger.name == "Pressureplate" && IndLights [i].name == "Point light (1)") {
//					IndLights [i].GetComponent<Light> ().color = Color.red;
//				}
//				if (Trigger.name == "Lever" && IndLights [i].name == "Point light (2)") {
//					IndLights [i].GetComponent<Light> ().color = Color.red;
//				}
//				if (Trigger.name == "Lever (1)" && IndLights [i].name == "Point light (3)") {
//					IndLights [i].GetComponent<Light> ().color = Color.red;
//				}
//			}
			this.transform.eulerAngles = new Vector3(0,0,0);
		}
	}		
}
