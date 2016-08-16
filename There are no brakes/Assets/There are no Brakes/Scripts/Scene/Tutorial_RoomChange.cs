using UnityEngine;
using System.Collections;

public class Tutorial_RoomChange : MonoBehaviour {
	//public GameObject Room1;
	//public GameObject Room2;
	//public string currentRoom = "Room1";
	// Use this for initialization
	void Start () {
		//Room1 = GameObject.Find ("Cam1");
		//Room2 = GameObject.Find ("Cam2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//Debug.Log ("Through the door");
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraMultitarget>().currentRoom = this.name;
		} /*else if (this.name == "RoomTrig2"){
				currentRoom = "room3";
			}*/
				
	}
}

