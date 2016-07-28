/***********************
 * IN_TextTrigger.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_TextTrigger : MonoBehaviour {
	public string message1 = "";
	public string message2 = "";
	public string message3 = "";
	private bool display = false;

	void Start () {
	}
	
	void Update () {
	}
	
	void OnTriggerExit(Collider other){
		// Checks for players leaving range
		if (other.tag == "Player") {
			display = false;
		}
	}
	
	void OnTriggerStay(Collider other){
		// Checks for players in range
		if (other.tag == "Player") {
			// display message
			display = true;
		}
	}
	
	public Vector3 textBoxSize = new Vector3(350,100,50);
	void OnGUI() {
		if(display){
			if(message2 == ""){
				GUI.Box(new Rect((Screen.width-textBoxSize.x)/2,textBoxSize.z,textBoxSize.x,textBoxSize.y), message1);
			} else if(message3 == ""){
				GUI.Box(new Rect((Screen.width-textBoxSize.x)/2,textBoxSize.z,textBoxSize.x,textBoxSize.y), message1 + "\n\n" + message2);
			} else {
				GUI.Box(new Rect((Screen.width-textBoxSize.x)/2,textBoxSize.z,textBoxSize.x,textBoxSize.y), message1 + "\n\n" + message2 + "\n\n" + message3);
			}
		}
	}
		
}
