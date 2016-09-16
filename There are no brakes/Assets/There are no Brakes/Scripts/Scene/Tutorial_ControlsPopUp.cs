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
		if(activated){
			if (Input.GetKey("return") || Input.GetAxis("Back_1") > 0.1f || Input.GetAxis("Back_2") > 0.1f || Input.GetAxis("Back_3") > 0.1f) {
				Time.timeScale = 1;
				PopUp.SetActive(false);
			}
		}
	}

	void OnTriggerEnter(Collider other) {			
		if (other.tag == "Player") {
			activated = true;
			PopUp.transform.position = new Vector3(camPos.x - 15, camPos.y, camPos.z);
			Time.timeScale = 0;
		}
	}
}
