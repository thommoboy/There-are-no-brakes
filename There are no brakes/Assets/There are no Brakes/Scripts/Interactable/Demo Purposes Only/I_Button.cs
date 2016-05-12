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
			if(Gate.transform.localPosition.y >= StopHeight)
			{
				Vector3 platpos = Gate.transform.localPosition;
				platpos.y -= 1.5f;
				Gate.transform.localPosition = Vector3.Lerp (Gate.transform.localPosition, platpos, Time.deltaTime);
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