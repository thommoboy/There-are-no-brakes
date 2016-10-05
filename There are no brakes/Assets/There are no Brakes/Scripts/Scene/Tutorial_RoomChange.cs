using UnityEngine;
using System.Collections;

public class Tutorial_RoomChange : MonoBehaviour {
	//public GameObject Room1;
	//public GameObject Room2;
	//public string currentRoom = "Room1";
	// Use this for initialization
	public bool Entered = false;


	void Start () {
		//Room1 = GameObject.Find ("Cam1");
		//Room2 = GameObject.Find ("Cam2");
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraZoom>().CurrentRoom == "Room3")
		{
			GameObject.Find("Light1").GetComponent<P_PlayerLight> ().lightEmUp();
			GameObject.Find("Light2").GetComponent<P_PlayerLight> ().lightEmUp();
			GameObject.Find("Light3").GetComponent<P_PlayerLight> ().lightEmUp();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
				GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraZoom> ().CurrentRoom = this.name;
				Entered = true;
				//GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<P_PlayerLight>().lightEmUp();
				//Debug.Log ("Through the door");
//			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraMultitarget>().currentRoom = this.name;
			} /*else if (this.name == "RoomTrig2"){
				currentRoom = "room3";
			}*/
				
	}
}

