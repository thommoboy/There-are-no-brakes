/***********************
 * IN_IndicatorLight.cs
 * Originally Written by Josh Garvey
 * Modified By:
 ***********************/
 
using UnityEngine;
using System.Collections;

public class IN_ProximityLight : MonoBehaviour {
	public GameObject light;
	//private GameObject[] players;


	public float intensityModifier = 10.0f; //directly proportionate to the average/max intensity of the light
	public float ambientIntensity = 3.0f; //after initial activation, this will be the lighting so long as no player is nearby
	//public float proxRange = 4.0f; //range at which the light will activate

	bool revealed = false;

	// Use this for initialization
	void Start () {
		//players = GameObject.FindGameObjectsWithTag ("Player");
		light.GetComponent<Light> ().intensity = 0;
		RenderSettings.ambientLight = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.Log (revealed);
		//If the player is within proxRange of light, activate it and dim it depending on proximity (intensity will temporarily increase again if player comes back to it
//		for (int i = 0; i < players.Length; i++){
//			float distanceToLight = Vector3.Distance (players[i].transform.position, light.transform.position);
//			bool occupied = false;
////			if (light.name == "Proximity Light (7)") {
////				Debug.Log (distanceToLight > proxRange);
////				Debug.Log (distanceToLight);
////			}
//			if (distanceToLight < proxRange) {
//				light.GetComponent<Light> ().intensity = (intensityModifier) / (distanceToLight);
//				revealed = true;
//				occupied = true;
//			}
//
//			if (distanceToLight > proxRange && revealed == true) {
//				//if a light has been passed and revealed, leave it on at a lower intensity
//				//occupied = false;
//				//Debug.Log ("Test");
//				light.GetComponent<Light> ().intensity = ambientIntensity;
//			}
//		}
	}

	void OnTriggerStay (Collider other){
		if (other.tag == "Player") {
			float distanceToLight = Vector3.Distance (other.transform.position, light.transform.position);
			light.GetComponent<Light> ().intensity = intensityModifier / distanceToLight;
			revealed = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Player" && revealed == true) {
			light.GetComponent<Light> ().intensity = ambientIntensity;
		}
	}
}
