using UnityEngine;
using System.Collections;

public class Tutorial_ControlsPopUp : MonoBehaviour {

	public GameObject PopUp;
	private bool activated = false;
	private Vector3 camPos;
	// Use this for initialization
	void Start () {
		camPos = GameObject.Find ("GUI Camera").transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider other) {			
		if (other.tag == "Player" && !activated) {
			if (Input.GetKey("return")) {
				activated = true;
				PopUp.SetActive(false);
			}
			PopUp.transform.position = new Vector3(camPos.x - 15, camPos.y, camPos.z);
		}
	}
}
