/***********************
 * IN_ShowIcon.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_ShowIcon : MonoBehaviour {
	private float timeout = 4f;
	private float timer1;
	private float timer2;
	private float timer3;
	private GameObject Icon1;
	private GameObject Icon2;
	private GameObject Icon3;
	private GameObject Icon4;
	private GameObject Icon5;
	private GameObject Icon6;

	void Start () {
		Icon1 = GameObject.Find("Icon1");
		Icon2 = GameObject.Find("Icon2");
		Icon3 = GameObject.Find("Icon3");
		Icon4 = GameObject.Find("Icon4");
		Icon5 = GameObject.Find("Icon5");
		Icon6 = GameObject.Find("Icon6");
		timer1 = 0;
		timer2 = 0;
		timer3 = 0;
	}
	
	void Update () {
		if(Input.GetAxis("X_1") > 0.1f){
			ShowIcon(1);
		}
		if(Input.GetAxis("X_2") > 0.1f){
			ShowIcon(2);
		}
		if(Input.GetAxis("X_3") > 0.1f){
			ShowIcon(3);
		}
		if(Input.GetKey("b")){
			ShowIcon(0);
		}
		
		if(Time.time < timer1){
			Icon1.GetComponent<Renderer>().enabled = true;
			Icon2.GetComponent<Renderer>().enabled = true;
		} else {
			Icon1.GetComponent<Renderer>().enabled = false;
			Icon2.GetComponent<Renderer>().enabled = false;
		}
		if(Time.time < timer2){
			Icon3.GetComponent<Renderer>().enabled = true;
			Icon4.GetComponent<Renderer>().enabled = true;
		} else {
			Icon3.GetComponent<Renderer>().enabled = false;
			Icon4.GetComponent<Renderer>().enabled = false;
		}
		if(Time.time < timer3){
			Icon5.GetComponent<Renderer>().enabled = true;
			Icon6.GetComponent<Renderer>().enabled = true;
		} else {
			Icon5.GetComponent<Renderer>().enabled = false;
			Icon6.GetComponent<Renderer>().enabled = false;
		}
	}
	
	public void ShowIcon(int playerID){
		if(playerID == 1){
			timer1 = Time.time + timeout;
		} else if(playerID == 2){
			timer2 = Time.time + timeout;
		} else if(playerID == 3){
			timer3 = Time.time + timeout;
		} else {
			timer1 = Time.time + timeout;
			timer2 = Time.time + timeout;
			timer3 = Time.time + timeout;
		}
	}
}
