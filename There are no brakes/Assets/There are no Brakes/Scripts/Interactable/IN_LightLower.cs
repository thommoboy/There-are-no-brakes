/***********************
 * IN_LightLower.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_LightLower : MonoBehaviour {
	public GameObject light1;
	public GameObject light2;

	void Start () {
	}
	
	void Update () {
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			light1.GetComponent<Light>().intensity = 0;
			light2.GetComponent<Light>().intensity = 0;
			RenderSettings.ambientIntensity = 0;
			RenderSettings.reflectionIntensity = 0.35f;
		}
	}
}
