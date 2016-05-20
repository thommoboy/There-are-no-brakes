using UnityEngine;
using System.Collections;

public class IN_Pulley_Trigger : MonoBehaviour
{
	public IN_Pulley IN_P;

	public enum Platform{Left, Right}

	public Platform IN_P_Platform;
	
	private int howMany = 0;

	void OnTriggerStay(Collider other)
	{
		if(IN_P_Platform == Platform.Left){
			if(howMany > 3){
				IN_P.LeftPlatformDown();
			}
		} else if(IN_P_Platform == Platform.Right){
			IN_P.RightPlatformDown();
		}
		
		//Debug.Log(howMany);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(IN_P_Platform == Platform.Left){
			howMany++; // increment counter
		Debug.Log(howMany);
		}
     }

	void OnTriggerExit(Collider other)
	{
		
		if(IN_P_Platform == Platform.Left){
			howMany--;
		Debug.Log(howMany);
		}
			/*IN_P.Origin = true;
		if(IN_P_Platform == Platform.Right)
			IN_P.Origin = true;
		*/
	}
}