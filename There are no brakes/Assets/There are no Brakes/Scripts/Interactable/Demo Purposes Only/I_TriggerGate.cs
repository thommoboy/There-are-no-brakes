/***********************
 * IN_Anchor_Trigger.cs
 * Originally Written by Pierce Thompson
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class I_TriggerGate : MonoBehaviour
{
	public bool Triggered = false;
	public GameObject Gate;
	public float StopHeight = -2;

	void Update ()
	{
		/// <summary>
		/// If the gate has been Triggered then Interpolate it's position based on the local position.
		/// </summary>
		if(Triggered)
		{
			if (Gate.transform.localPosition.y >= StopHeight)
			{
				Vector3 platpos = Gate.transform.localPosition;
				platpos.y -= 1.5f;
				Gate.transform.localPosition = Vector3.Lerp (Gate.transform.localPosition, platpos, Time.deltaTime);
			}
		}
	}

	/// <summary>
	/// If a player enteres the Trigger, set the boolean to be true.
	/// </summary>
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Triggered = true;
		}
	}
}
