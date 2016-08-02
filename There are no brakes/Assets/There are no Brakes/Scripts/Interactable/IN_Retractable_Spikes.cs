/***********************
 * IN_Retractable_Spikes.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Retractable_Spikes : MonoBehaviour {
	public GameObject Trigger;
	public bool ActiveOnStart = false;
	private bool Activated = false;
	private GameObject MovePart;
	private float MoveDistance = -0.0392f;
	private float MoveSpeed = 0.3f;

	void Start () {
		MovePart = this.transform.FindChild("Spikes").gameObject;
	}
	
	void Update () {
		Activated = Trigger.GetComponent<IN_Activation>().activated;
		if(ActiveOnStart){
			Activated = !Activated;
		}
		
		if(Activated){
			if(MovePart.transform.localPosition.y < 0){
				MovePart.transform.localPosition = new Vector3(0, MovePart.transform.localPosition.y + Time.deltaTime*MoveSpeed, 0);
			}
		} else {
			if(MovePart.transform.localPosition.y > MoveDistance){
				MovePart.transform.localPosition = new Vector3(0, MovePart.transform.localPosition.y - Time.deltaTime*MoveSpeed, 0);
			}
		}
	}		
}
