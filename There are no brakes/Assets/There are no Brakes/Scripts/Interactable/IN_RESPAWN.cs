/***********************
 * IN_RESPAWN.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_RESPAWN : MonoBehaviour {
	public bool isSpawnPoint = false;
	static Vector3 P1respawnPOS;
	static Vector3 P2respawnPOS;
	static Vector3 P3respawnPOS;
	static Vector3 WeightRespawnPOS;
	public bool destroyObjects = false;

	void Start () {
		P1respawnPOS = GameObject.Find("Player1").transform.position;
		P2respawnPOS = GameObject.Find("Player2").transform.position;
		P3respawnPOS = GameObject.Find("Player3").transform.position;
		WeightRespawnPOS = GameObject.Find ("weight").transform.position;
	}
	
	void OnTriggerEnter(Collider other) {
		// if its a damaging object respawn the player
		if(!isSpawnPoint){
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
			} else if (other.tag == "Weight" /*&& destroyObjects*/) {
				if (destroyObjects) {
					Destroy (other.gameObject);
				} else {
					other.transform.position = WeightRespawnPOS;
				}
			}
		// if its a spawn point update the players spawn position
		} else {
			if (other.name == "Player1") {
				P1respawnPOS = new Vector3 (other.transform.position.x, this.transform.position.y, this.transform.position.z);
			}
			if (other.name == "Player2") {
				P2respawnPOS = new Vector3 (other.transform.position.x, this.transform.position.y, this.transform.position.z);
			}
			if (other.name == "Player3") {
				P3respawnPOS = new Vector3 (other.transform.position.x, this.transform.position.y, this.transform.position.z);
			}
		}
	}
}
