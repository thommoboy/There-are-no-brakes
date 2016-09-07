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
	private float height = 9f;
	
	void Start () {
	}
	
	void Update () {
		camPos = this.transform.position;
		this.transform.position = new Vector3 (camPos.x,followThis.transform.position.y+height,followThis.transform.position.z);
	}
}
