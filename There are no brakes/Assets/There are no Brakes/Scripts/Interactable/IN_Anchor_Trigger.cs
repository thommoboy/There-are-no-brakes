using UnityEngine;
using System.Collections;

public class IN_Anchor_Trigger : MonoBehaviour
{
	public IN_Anchor IN_P;

	public enum Platform{Left, Right}

	public Platform IN_P_Platform;

	public bool Blocked = false;

	public void Update()
	{
		if(!Blocked)
			IN_P.RightPlatformDown();
	}

	void OnTriggerStay(Collider other)
	{
		Debug.Log ("Entered");
		/*
		if(IN_P_Platform == Platform.Left)
			IN_P.LeftPlatformDown();
		else if(IN_P_Platform == Platform.Right)
			IN_P.RightPlatformDown();
			*/

		Blocked = true;
	}

	void OnTriggerExit(Collider other)
	{
		Blocked = false;
		/*
		if(IN_P_Platform == Platform.Left)
			IN_P.Origin = true;
		if(IN_P_Platform == Platform.Right)
			IN_P.Origin = true;
		*/
	}
}