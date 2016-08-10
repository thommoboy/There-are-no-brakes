/***********************
 * IN_Anchor_Trigger.cs
 * Originally Written by Pierce Thompson
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Pulley_Trigger : MonoBehaviour
{
	public IN_Pulley IN_P;
	public enum Platform{Left, Right}
	public Platform IN_P_Platform;
	private int howMany = 0;

	/// <summary>
	/// If an object stays the Collision then Lower the platform that is attatched.
	/// </summary>
	void Update()
	{
        if (IN_P_Platform == Platform.Left)
            if (howMany > 1)
            {
               // IN_P.Origin = false;
                IN_P.LeftPlatformDown();
            }
            else //if (IN_P_Platform == Platform.Right)
            {
                IN_P.RightPlatformDown();
            }
                
	}

    

	/// <summary>
	/// If an object enters the Collision then Increment the player count.
	/// </summary>
	void OnTriggerEnter(Collider other)
	{
		if(IN_P_Platform == Platform.Left)
			howMany++; // increment counter
    }

	/// <summary>
	///   If an object exits the Collision then increment the value negatively.
	/// </summary>
	void OnTriggerExit(Collider other)
	{
		if(IN_P_Platform == Platform.Left)
			howMany--;
	}
}