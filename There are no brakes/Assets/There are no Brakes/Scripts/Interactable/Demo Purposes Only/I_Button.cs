/***********************
 * IN_Anchor_Trigger.cs
 * Originally Written by Pierce Thompson
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class I_Button : MonoBehaviour
{
	public bool InTrigger = false;
	public bool Destroyed = false;
	public GameObject Wall;
	public GameObject Gate;
	public float StopHeight = -2;

	void Update()
	{
		if(InTrigger)
		{
			if(!Destroyed)
			{
				if(Input.GetKeyDown(KeyCode.E))
				{
					DestroyImmediate (Wall);
					Destroyed = true;
				}
			}
		}

		if(Destroyed)
		{
			if(Gate.transform.rotation.z < 0.5f){
				Gate.transform.Rotate(0, 0, Time.deltaTime*25);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			InTrigger = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(other.tag == "Weight"){
			if(Gate.transform.rotation.z < 0.5f){
				Gate.transform.Rotate(0, 0, Time.deltaTime*25);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			InTrigger = false;
		}
	}

	void OnGUI()
	{
		if(InTrigger)
		{
			GUI.Label(new Rect (Screen.width / 2, Screen.height / 2, 500, 50), "Press [E] To Use");
		}
	}
}