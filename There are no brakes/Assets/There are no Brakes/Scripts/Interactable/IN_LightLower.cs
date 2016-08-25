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
	public GameObject HUDlight1;
	public GameObject HUDlight2;
	public GameObject HUDlight3;
	public GameObject HUDlight4;

	void Start () {
		HUDlight1.GetComponent<Light>().intensity = 0;
		HUDlight2.GetComponent<Light>().intensity = 0;
		HUDlight3.GetComponent<Light>().intensity = 0;
		HUDlight4.GetComponent<Light>().intensity = 0;
		RenderSettings.ambientLight = new Color(0.5f, 0.5f, 0.5f);
	}
	
	void Update () {
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			light1.GetComponent<Light>().intensity = 0;
			light2.GetComponent<Light>().intensity = 0;
			RenderSettings.ambientIntensity = 0;
			RenderSettings.reflectionIntensity = 0.35f;
			HUDlight1.GetComponent<Light>().intensity = 8;
			HUDlight2.GetComponent<Light>().intensity = 8;
			HUDlight3.GetComponent<Light>().intensity = 8;
			HUDlight4.GetComponent<Light>().intensity = 8;
		}
	}
}
