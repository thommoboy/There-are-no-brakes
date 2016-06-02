/***********************
 * M_OnClick.cs
 * Originally Written by Xinyu Feng
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class M_OnClick : MonoBehaviour {
	bool optionActivity;
	bool startActivity;
	public GameObject optionCanvas;
	public GameObject playerMenuCanvas;
	// Use this for initialization
	void start(){
		optionActivity = false;
		startActivity = false;
	}

	public void optionClick(){
		if (optionActivity) {
			optionActivity = false;
			optionCanvas.SetActive (optionActivity);
			return;
		}
		hideRightMenu ();
		optionActivity = true;
		optionCanvas.SetActive (optionActivity);
	}

	public void startClick(){
		if (startActivity) {
			startActivity = false;
			playerMenuCanvas.SetActive (startActivity);
			return;
		}
		hideRightMenu();
		startActivity = true;
		playerMenuCanvas.SetActive (startActivity);
	}

	public void quitClick(){
		Application.Quit ();
	}

	private void hideRightMenu(){
		if (optionActivity)  optionActivity = false;
		optionCanvas.SetActive (optionActivity);

		if (startActivity)   startActivity = false;
		playerMenuCanvas.SetActive (startActivity);

	}
}
