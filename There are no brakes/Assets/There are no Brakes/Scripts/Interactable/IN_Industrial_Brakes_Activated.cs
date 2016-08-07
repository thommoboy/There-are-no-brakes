/***********************
 * IN_Industrial_Brakes_Activated.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Industrial_Brakes_Activated : MonoBehaviour {
	public GameObject Trigger;
	private bool dropped = false;

	void Start () {
	}
	
	void Update () {
		if(GameObject.Find("IndicatorLightL").GetComponent<IN_IndicatorLight>().Activated && GameObject.Find("IndicatorLightC").GetComponent<IN_IndicatorLight>().Activated && GameObject.Find("IndicatorLightR").GetComponent<IN_IndicatorLight>().Activated){
			GameObject.Find("brake1").GetComponent<IN_Industrial_Brake>().Activated = true;
			GameObject.Find("brake2").GetComponent<IN_Industrial_Brake>().Activated = true;
			GameObject.Find("brake3").GetComponent<IN_Industrial_Brake>().Activated = true;
			GameObject.Find("brake4").GetComponent<IN_Industrial_Brake>().Activated = true;
		} else {
			GameObject.Find("brake1").GetComponent<IN_Industrial_Brake>().Activated = false;
			GameObject.Find("brake2").GetComponent<IN_Industrial_Brake>().Activated = false;
			GameObject.Find("brake3").GetComponent<IN_Industrial_Brake>().Activated = false;
			GameObject.Find("brake4").GetComponent<IN_Industrial_Brake>().Activated = false;
		}
		
		//check if dropped all the way
		if(Trigger.transform.position.y < -10){
			if(!dropped){
				//level comletion
				GameObject.Find("HUDmanager").GetComponent<P_HUD>().LevelCompleted();
				dropped = true;
			}
		}
	}		
}
