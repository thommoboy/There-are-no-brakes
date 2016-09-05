/***********************
 *  Tutorial_FlickerLight.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class Tutorial_FlickerLight : MonoBehaviour {
	private Light light;
	private float flickerSpeed = 1.0f;
	private float targetIntensity = 8.0f;
	// Use this for initialization
	void Start () {
		light = this.GetComponent<Light> ();
		light.intensity = 0;

	}
	
	// Update is called once per frame
	void Update () {
		light.intensity = Mathf.Lerp (light.intensity, targetIntensity, flickerSpeed*Time.deltaTime);
		if (light.intensity > 6) {
			targetIntensity = Random.Range (0.0f, 0.5f);
		} else if (light.intensity < 2) {
			targetIntensity = Random.Range (6.5f, 8.0f);
		}
	}
}
