/***********************
 * IN_Anchor_Dropped.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

//script to make the camera zoom out, can react to player entering a trigger or interacting with an object
public class IN_trigger_zoomout : MonoBehaviour {

	private GameObject Camera;
	private bool Activated = false;
	private bool checking = true;
	public bool onactivate;
	// Use this for initialization
	void Start () {
		Camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if(checking && onactivate){
			Activated = this.GetComponent<IN_Activation>().activated;
			if(Activated){
				Camera.GetComponent<CameraZoom>().autoZoomout();
				checking = false;
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(checking && !onactivate){
			if (other.tag == "Player"){
				Camera.GetComponent<CameraZoom>().autoZoomout();
				checking = false;
			}
		}
	}
}
