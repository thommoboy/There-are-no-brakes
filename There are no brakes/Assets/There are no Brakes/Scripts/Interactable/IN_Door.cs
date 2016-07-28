/***********************
 * IN_Door.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Door : MonoBehaviour {
	public GameObject Trigger;
	private Vector3 doorPos;
	public int openHeight = 5;

	void Start () {
		doorPos = this.transform.position;
	}
	
	void Update () {
		if(Trigger.GetComponent<IN_Activation>().activated){
			this.transform.position = new Vector3 (doorPos.x,doorPos.y+openHeight,doorPos.z);
		} else {
			this.transform.position = new Vector3 (doorPos.x,doorPos.y,doorPos.z);
		}
	}		
}
