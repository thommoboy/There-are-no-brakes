/***********************
 * IN_RESPAWN.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_RESPAWN : MonoBehaviour {
	public bool isTutorial = false;
	public GameObject spawnPoint;
	private Vector3 P1respawnPOS;
	private Vector3 P2respawnPOS;
	private Vector3 P3respawnPOS;
	public bool destroyObjects = false;

	void Start () {
		P1respawnPOS = GameObject.Find("Player1").transform.position;
		P2respawnPOS = GameObject.Find("Player2").transform.position;
		P3respawnPOS = GameObject.Find("Player3").transform.position;
		if (isTutorial) {
			P1respawnPOS = spawnPoint.transform.position;
			P2respawnPOS = spawnPoint.transform.position;
			P3respawnPOS = spawnPoint.transform.position;
		}
	}
	
	void Update () {
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (other.name == "Player1") {
				other.transform.position = P1respawnPOS;
			}
			if (other.name == "Player2") {
				other.transform.position = P2respawnPOS;
			}
			if (other.name == "Player3") {
				other.transform.position = P3respawnPOS;
			}
		} else if (other.tag == "Weight" && destroyObjects) {
			Destroy (other.gameObject);
		}
	}
}
