/***********************
 * Tutorial_FakeDarkness.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class Tutorial_FakeDarkness : MonoBehaviour {
	public GameObject Trigger;
	private Vector3 originalPos;
	public Vector3 moveToPos;
	
	void Start(){
		originalPos = this.transform.position;
	}
	
	void Update(){
		if(Trigger.GetComponent<IN_Activation>().activated){
			this.transform.position = new Vector3 (moveToPos.x,moveToPos.y,moveToPos.z);
		} else {
			this.transform.position = new Vector3 (originalPos.x,originalPos.y,originalPos.z);
		}		
	}
}