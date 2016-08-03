/***********************
 * IN_RESPAWN.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_RESPAWN : MonoBehaviour {
	private Vector3 P1respawnPOS;
	private Vector3 P2respawnPOS;
	private Vector3 P3respawnPOS;

	void Start () {
		P1respawnPOS = GameObject.Find("Player1").transform.position;
		P2respawnPOS = GameObject.Find("Player2").transform.position;
		P3respawnPOS = GameObject.Find("Player3").transform.position;
	}
	
	void Update () {
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			if (other.name == "Player1"){
				other.transform.position = P1respawnPOS;
			}
			if (other.name == "Player2"){
				other.transform.position = P2respawnPOS;
			}
			if (other.name == "Player3"){
				other.transform.position = P3respawnPOS;
			}
		}
	}
}
