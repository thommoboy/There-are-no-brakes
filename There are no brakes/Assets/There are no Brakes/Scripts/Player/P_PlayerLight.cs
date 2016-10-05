/***********************
 * IN_IndicatorLight.cs
 * Originally Written by Josh Garvey
 * Modified by:
 ***********************/
 
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class P_PlayerLight : MonoBehaviour {
	//public GameObject light;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	// Use this for initialization
	void Start () {

	}
	public void lightEmUp(){
		if (this.name == "Light1") {
			this.transform.position = new Vector3 (player1.transform.position.x + 1.0f, player1.transform.position.y + 0.5f, player1.transform.position.z);
		} else if (this.name == "Light2") {
			this.transform.position = new Vector3 (player2.transform.position.x + 1.0f, player2.transform.position.y + 0.5f, player2.transform.position.z);
		} else if (this.name == "Light3") {
			this.transform.position = new Vector3 (player3.transform.position.x + 1.0f, player3.transform.position.y + 0.5f, player3.transform.position.z);
			this.transform.rotation = Quaternion.LookRotation (-player3.transform.right); //Industrialist
		}
	}
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Industrial Level") {
			lightEmUp ();
		}
		/*
		if (SceneManager.GetActiveScene().name == "Tutorial Level") {
			/if (GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraMultitarget> ().currentRoom == "Room3") { //Maincam.z < 10
				lightEmUp ();
			}
				

		} else {
			lightEmUp ();
		}
*/
	}
}