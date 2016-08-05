/***********************
 * IN_IndicatorLight.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_IndicatorLight : MonoBehaviour {
	public GameObject Trigger;
	public bool ActiveOnStart = false;
	private bool Activated = false;

	void Start () {
	}
	
	void Update () {
		Activated = Trigger.GetComponent<IN_Activation>().activated;
		if(ActiveOnStart){
			Activated = !Activated;
		}
		
		if(Activated){
			this.transform.eulerAngles = new Vector3(0,180,0);
		} else {
			this.transform.eulerAngles = new Vector3(0,0,0);
		}
	}		
}
