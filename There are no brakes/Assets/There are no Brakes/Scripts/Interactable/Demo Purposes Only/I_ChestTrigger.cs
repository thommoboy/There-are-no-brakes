using UnityEngine;
using System.Collections;

public class I_ChestTrigger : MonoBehaviour {
	public bool InTrigger = false;
	public bool ChestOpened = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (InTrigger) {
			if (Input.GetKeyDown (KeyCode.E)) {
				ChestOpened = true;
			}
		}

	}

	void OnGUI()
	{
		if(InTrigger && !ChestOpened)
		{
			GUI.Label(new Rect (Screen.width / 2, Screen.height / 2, 500, 50), "Press [E] To Use");
		}

		if (ChestOpened) {
			GUI.Label(new Rect (Screen.width / 2, Screen.height / 2, 500, 50), "You gain something");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			InTrigger = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			InTrigger = false;
			ChestOpened = false;
		}
	}
}
