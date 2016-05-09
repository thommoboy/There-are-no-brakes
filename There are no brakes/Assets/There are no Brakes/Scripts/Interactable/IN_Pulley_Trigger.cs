using UnityEngine;
using System.Collections;

public class IN_Pulley_Trigger : MonoBehaviour
{
	public IN_Pulley IN_P;

	public enum Platform{Left, Right}

	public Platform IN_P_Platform;

	void OnTriggerStay(Collider other)
	{
		if(IN_P_Platform == Platform.Left)
			IN_P.LeftPlatformDown();
		else if(IN_P_Platform == Platform.Right)
			IN_P.RightPlatformDown();
	}

	void OnTriggerExit(Collider other)
	{
		/*
		if(IN_P_Platform == Platform.Left)
			IN_P.Origin = true;
		if(IN_P_Platform == Platform.Right)
			IN_P.Origin = true;
		*/
	}
}