/***********************
 * CameraSimpleFollow.cs
 * Created by Nathan Brown
 * Modified By:
 * 
 ***********************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSimpleFollow : MonoBehaviour {
	public GameObject followThis;
	private Vector3 camPos;
	
	void Start () {
	}
	
	void Update () {
		camPos = this.transform.position;
		this.transform.position = new Vector3 (camPos.x,camPos.y,followThis.transform.position.z);
	}
}
