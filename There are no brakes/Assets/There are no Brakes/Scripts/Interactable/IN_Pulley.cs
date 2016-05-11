using UnityEngine;
using System.Collections;

public class IN_Pulley : MonoBehaviour
{
	//Hold the Objects
	public GameObject IN_P_PulleyLeft;
	public GameObject IN_P_PulleyRight;

	public GameObject IN_P_PlatformLeft;
	public GameObject IN_P_PlatformRight;

	public Vector3 IN_P_Origin_Left = new Vector3();
	public Vector3 IN_P_Origin_Right = new Vector3();
	
	public GameObject IN_P_GateLeft;
	public GameObject IN_P_GateRight;
	public int RotationRate = 25;

	public bool Origin = false;

	public void Start()
	{
		IN_P_Origin_Left = IN_P_PlatformLeft.transform.localPosition;
		IN_P_Origin_Right = IN_P_PlatformRight.transform.localPosition;
	}

	public void Update()
	{

		if(IN_P_PlatformLeft.transform.localPosition == IN_P_Origin_Left && IN_P_PlatformRight.transform.localPosition == IN_P_Origin_Right)
			Origin = false;

		if(Origin)
		{
			if(IN_P_PulleyRight.transform.localScale.y > 0 || IN_P_PulleyLeft.transform.localScale.y > 0)
			{
				//if (IN_P_PulleyRight.transform.localPosition.y != 2)
				//{
					/*
				//Left Rope
					Vector3 tempscale2 = IN_P_PulleyLeft.transform.localScale;
					tempscale2.y -= 1;
					IN_P_PulleyLeft.transform.localScale = tempscale2;

					//Right Rope
					Vector3 tempscale = IN_P_PulleyRight.transform.localScale;
					tempscale.y += 1;
					IN_P_PulleyRight.transform.localScale = tempscale;
					*/

					//Right Platform
					Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
					platpos.y -= 1.5f;
					IN_P_PlatformRight.transform.localPosition = Vector3.Lerp(IN_P_PlatformRight.transform.localPosition, IN_P_Origin_Right, Time.deltaTime);

					Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
					temppos.y -= 1;
					IN_P_PulleyRight.transform.localPosition = Vector3.Lerp(IN_P_PulleyRight.transform.localPosition, temppos, Time.deltaTime);

					//Left Platform
					Vector3 platpos2 = IN_P_PlatformLeft.transform.localPosition;
					platpos2.y += 1.5f;
					IN_P_PlatformLeft.transform.localPosition = Vector3.Lerp(IN_P_PlatformLeft.transform.localPosition, IN_P_Origin_Left, Time.deltaTime);

					Vector3 temppos2 = IN_P_PulleyLeft.transform.localPosition;
					temppos2.y += 1;
					IN_P_PulleyLeft.transform.localPosition = Vector3.Lerp(IN_P_PulleyLeft.transform.localPosition, temppos2, Time.deltaTime);
				//}
			}
		}
		
		
		//stop gates rotating too far
		Debug.Log(IN_P_GateRight.transform.rotation.z);
		if(IN_P_GateLeft.transform.rotation.z < 0){
			IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
		}
		if(IN_P_GateLeft.transform.rotation.z > 0.7f){
			IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
		}
		if(IN_P_GateRight.transform.rotation.z < 0){
			IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
		}
		if(IN_P_GateRight.transform.rotation.z > 0.7f){
			IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
		}
	}

	public void LeftPlatformDown()
	{
		if (IN_P_PulleyRight.transform.localScale.y > 0 || IN_P_PulleyLeft.transform.localScale.y > 0)
		{
			if (IN_P_PulleyRight.transform.localPosition.y >= 2) {

			}
			else
			{
				/*
				//Right Rope
				Vector3 tempscale = IN_P_PulleyRight.transform.localScale;
				tempscale.y -= 1;
				IN_P_PulleyRight.transform.localScale = tempscale;

				//Left Rope
				Vector3 tempscale2 = IN_P_PulleyLeft.transform.localScale;
				tempscale2.y += 1;
				IN_P_PulleyLeft.transform.localScale = tempscale2;
				*/
				Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
				temppos.y += 1;
				IN_P_PulleyRight.transform.localPosition = Vector3.Lerp(IN_P_PulleyRight.transform.localPosition, temppos, Time.deltaTime);

				//Right Platform
				Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
				platpos.y += 1.5f;
				IN_P_PlatformRight.transform.localPosition = Vector3.Lerp(IN_P_PlatformRight.transform.localPosition, platpos, Time.deltaTime);
				

				//Left Platform
				Vector3 platpos2 = IN_P_PlatformLeft.transform.localPosition;
				platpos2.y -= 1.5f;
				IN_P_PlatformLeft.transform.localPosition = Vector3.Lerp(IN_P_PlatformLeft.transform.localPosition, platpos2, Time.deltaTime);

				Vector3 temppos2 = IN_P_PulleyLeft.transform.localPosition;
				temppos2.y -= 1;
				IN_P_PulleyLeft.transform.localPosition = Vector3.Lerp(IN_P_PulleyLeft.transform.localPosition, temppos2, Time.deltaTime);
				
				//if gates exist rotate them
				if(IN_P_GateLeft != null){
					IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
				}
				if(IN_P_GateRight != null){
					IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
				}
			}
		}
	}

	public void RightPlatformDown()
	{
		if (IN_P_PulleyRight.transform.localScale.y > 0 || IN_P_PulleyLeft.transform.localScale.y > 0)
		{
			if (IN_P_PulleyLeft.transform.localPosition.y >= 2) {
				
			}
			else
			{
				/*
				//Left Rope
				Vector3 tempscale2 = IN_P_PulleyLeft.transform.localScale;
				tempscale2.y -= 1;
				IN_P_PulleyLeft.transform.localScale = tempscale2;

				//Right Rope
				Vector3 tempscale = IN_P_PulleyRight.transform.localScale;
				tempscale.y += 1;
				IN_P_PulleyRight.transform.localScale = tempscale;
				*/

				//Right Platform
				Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
				temppos.y -= 1;
				IN_P_PulleyRight.transform.localPosition = Vector3.Lerp(IN_P_PulleyRight.transform.localPosition, temppos, Time.deltaTime);

				Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
				platpos.y -= 1.5f;
				IN_P_PlatformRight.transform.localPosition = Vector3.Lerp(IN_P_PlatformRight.transform.localPosition, platpos, Time.deltaTime);

				//Left Platform
				Vector3 platpos2 = IN_P_PlatformLeft.transform.localPosition;
				platpos2.y += 1.5f;
				IN_P_PlatformLeft.transform.localPosition = Vector3.Lerp(IN_P_PlatformLeft.transform.localPosition, platpos2, Time.deltaTime);

				Vector3 temppos2 = IN_P_PulleyLeft.transform.localPosition;
				temppos2.y += 1;
				IN_P_PulleyLeft.transform.localPosition = Vector3.Lerp(IN_P_PulleyLeft.transform.localPosition, temppos2, Time.deltaTime);
				
				//if gates exist rotate them
				if(IN_P_GateLeft != null){
					IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
				}
				if(IN_P_GateRight != null){
					IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
				}

			}
		}
	}
}
	


/*
	void Update()
	{
		if(IN_P_PulleyRight.transform.localScale.y > 0 || IN_P_PulleyLeft.transform.localScale.y > 0)
		{
			if(IN_P_PulleyRight.transform.localScale.y == 1)
			{
				if(Input.GetKeyDown(KeyCode.DownArrow))
				{
					//Right Rope
					Vector3 tempscale = IN_P_PulleyRight.transform.localScale;
					tempscale.y += 1;
					IN_P_PulleyRight.transform.localScale = tempscale;

					Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
					temppos.y -= 1;
					IN_P_PulleyRight.transform.localPosition = temppos;

					//Right Platform
					Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
					platpos.y -= 1.5f;
					IN_P_PlatformRight.transform.localPosition = platpos;
				}
			}
			else
			{
				if(Input.GetKeyDown(KeyCode.UpArrow))
				{
					//Right Rope
					Vector3 tempscale = IN_P_PulleyRight.transform.localScale;
					tempscale.y -= 1;
					IN_P_PulleyRight.transform.localScale = tempscale;

					Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
					temppos.y += 1;
					IN_P_PulleyRight.transform.localPosition = temppos;

					//Right Platform
					Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
					platpos.y += 1.5f;
					IN_P_PlatformRight.transform.localPosition = platpos;

					//Left Platform
					Vector3 platpos2 = IN_P_PlatformLeft.transform.localPosition;
					platpos2.y -= 1.5f;
					IN_P_PlatformLeft.transform.localPosition = platpos2;

					//Left Rope
					Vector3 tempscale2 = IN_P_PulleyLeft.transform.localScale;
					tempscale2.y += 1;
					IN_P_PulleyLeft.transform.localScale = tempscale2;

					Vector3 temppos2 = IN_P_PulleyLeft.transform.localPosition;
					temppos2.y -= 1;
					IN_P_PulleyLeft.transform.localPosition = temppos2;
				}

				if(Input.GetKeyDown(KeyCode.DownArrow))
				{
					//Right Rope
					Vector3 tempscale = IN_P_PulleyRight.transform.localScale;
					tempscale.y += 1;
					IN_P_PulleyRight.transform.localScale = tempscale;

					Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
					temppos.y -= 1;
					IN_P_PulleyRight.transform.localPosition = temppos;

					//Right Platform
					Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
					platpos.y -= 1.5f;
					IN_P_PlatformRight.transform.localPosition = platpos;

					//Left Platform
					Vector3 platpos2 = IN_P_PlatformLeft.transform.localPosition;
					platpos2.y += 1.5f;
					IN_P_PlatformLeft.transform.localPosition = platpos2;

					//Left Rope
					Vector3 tempscale2 = IN_P_PulleyLeft.transform.localScale;
					tempscale2.y -= 1;
					IN_P_PulleyLeft.transform.localScale = tempscale2;

					Vector3 temppos2 = IN_P_PulleyLeft.transform.localPosition;
					temppos2.y += 1;
					IN_P_PulleyLeft.transform.localPosition = temppos2;
				}
			}
		}
	}
	*/

/*
	 * Possible Solution:
	 * 
	 *   function OnTriggerStay(other:Collider){
             
             if(other.gameObject.tag == "platform"){
             transform.parent = other.transform;
 
		      }
		     }
		 
		 function OnTriggerExit(other:Collider){
		     if(other.gameObject.tag == "platform"){
             transform.parent = null;
             
         }
     }
	 * 
	 * 
	 * or set the position relative to the platform:
	 * 
	 *  transform.position = other.transform.position;
 		transform.rotation = other.transform.rotation;
	 *
	 */