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
	public int defaultLightLevel = 1;
	public int maxLightLevel = 6;
	public bool Activated = false;

	void Start () {
	}
	
	void Update () {
		Activated = Trigger.GetComponent<IN_Activation>().activated;
		
		if(Activated){
			IndLight.GetComponent<Light> ().color = Color.green;
			IndLight.GetComponent<Light> ().intensity = maxLightLevel;
		} else {
			IndLight.GetComponent<Light> ().color = Color.red;
			IndLight.GetComponent<Light> ().intensity = defaultLightLevel;
		}
	}		
}
