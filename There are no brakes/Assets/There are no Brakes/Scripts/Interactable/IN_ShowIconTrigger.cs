/***********************
 * IN_ShowIconTrigger.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_ShowIconTrigger : MonoBehaviour {
	public int playerID = 0;
	private GameObject controller;

	void Start () {
		controller = GameObject.Find("PlayerControllers");
	}
	
	void Update () {
	}
	
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			controller.GetComponent<IN_ShowIcon>().ShowIcon(playerID);
		}
	}
}
