using UnityEngine;
using System.Collections;

public class I_Button : MonoBehaviour
{
	public bool InTrigger = false;
	public bool Destroyed = false;
	public GameObject Wall;

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