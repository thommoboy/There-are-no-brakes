/***********************
 * IN_Anchor_Trigger.cs
 * Originally Written by Pierce Thompson
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Pulley : MonoBehaviour
{
	/// <summary>
	/// Hold the Objects
	/// </summary>
	public GameObject IN_P_PulleyLeft;
	public GameObject IN_P_PulleyRight;

	public GameObject IN_P_PlatformLeft;
	public GameObject IN_P_PlatformRight;

	public Vector3 IN_P_Origin_Left = new Vector3();
	public Vector3 IN_P_Origin_Right = new Vector3();
	
	public GameObject IN_P_GateLeft;
	/*public GameObject IN_P_GateRight;*/
	public int RotationRate = 25;
	
	public GameObject IN_P_RopeLeft;
	public GameObject IN_P_RopeRight;
	private float minrightrope;
	private float maxrightrope;
	private float minleftrope;
	private float maxleftrope;

	public bool Origin = false;

	/// <summary>
	/// Set the required variables to their respective values.
	/// </summary>
	public void Start()
	{
		IN_P_Origin_Left = IN_P_PlatformLeft.transform.localPosition;
		IN_P_Origin_Right = IN_P_PlatformRight.transform.localPosition;
		maxrightrope = IN_P_RopeRight.transform.localScale.y;
		minrightrope = maxrightrope * 0.5f;
		minleftrope = IN_P_RopeLeft.transform.localScale.y;
		maxleftrope = maxrightrope * 1.2f;
	}
	
	public void Update()
	{
		/// <summary>
		/// Reset the platform if required
		/// </summary>
		if(IN_P_PlatformLeft.transform.localPosition == IN_P_Origin_Left && IN_P_PlatformRight.transform.localPosition == IN_P_Origin_Right)
			Origin = false;

		if(Origin)
		{
			if(IN_P_PulleyRight.transform.localScale.y > 0 || IN_P_PulleyLeft.transform.localScale.y > 0)
			{
				/// <summary>
				/// Adjust the platforms height via a Vector3 Interpolation
				/// </summary>

				/// <summary>
				/// Adjust the right platform
				/// </summary>
				Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
				platpos.y -= 1.5f;
				IN_P_PlatformRight.transform.localPosition = Vector3.Lerp(IN_P_PlatformRight.transform.localPosition, IN_P_Origin_Right, Time.deltaTime);

				Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
				temppos.y -= 1;
				IN_P_PulleyRight.transform.localPosition = Vector3.Lerp(IN_P_PulleyRight.transform.localPosition, temppos, Time.deltaTime);

				/// <summary>
				/// Adjust the left platform
				/// </summary>
				Vector3 platpos2 = IN_P_PlatformLeft.transform.localPosition;
				platpos2.y += 1.5f;
				IN_P_PlatformLeft.transform.localPosition = Vector3.Lerp(IN_P_PlatformLeft.transform.localPosition, IN_P_Origin_Left, Time.deltaTime);

				Vector3 temppos2 = IN_P_PulleyLeft.transform.localPosition;
				temppos2.y += 1;
				IN_P_PulleyLeft.transform.localPosition = Vector3.Lerp(IN_P_PulleyLeft.transform.localPosition, temppos2, Time.deltaTime);
			}
		}
		
		/// <summary>
		/// Stop gates rotating too far
		/// </summary>
		if(IN_P_GateLeft.transform.rotation.z < 0)
			IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
		if(IN_P_GateLeft.transform.rotation.z > 0.5f)
			IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
	}

	public void LeftPlatformDown()
	{
		if (IN_P_PulleyRight.transform.localScale.y > 0 || IN_P_PulleyLeft.transform.localScale.y > 0)
		{
			if (IN_P_PulleyRight.transform.localPosition.y >= 2) {

			}
			else
			{
				/// <summary>
				/// Right rope
				/// </summary>
				Vector3 tempscale = IN_P_RopeRight.transform.localScale;
				tempscale.y -= 0.2f;
				if(minrightrope < IN_P_RopeRight.transform.localScale.y){
					IN_P_RopeRight.transform.localScale = Vector3.Lerp(IN_P_RopeRight.transform.localScale, tempscale, Time.deltaTime);
				}

				/// <summary>
				/// Left rope
				/// </summary>
				if(maxleftrope > IN_P_RopeLeft.transform.localScale.y){
					IN_P_RopeLeft.transform.localScale = new Vector3(IN_P_RopeLeft.transform.localScale.x, IN_P_RopeLeft.transform.localScale.y + 0.1f*Time.deltaTime, IN_P_RopeLeft.transform.localScale.z);
				}
				
				/// <summary>
				/// Right platform
				/// </summary>
				Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
				temppos.y += 1;
				IN_P_PulleyRight.transform.localPosition = Vector3.Lerp(IN_P_PulleyRight.transform.localPosition, temppos, Time.deltaTime);

				Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
				platpos.y += 1.5f;
				IN_P_PlatformRight.transform.localPosition = Vector3.Lerp(IN_P_PlatformRight.transform.localPosition, platpos, Time.deltaTime);
				
				GameObject.Find("weight").transform.localPosition = new Vector3(GameObject.Find("weight").transform.localPosition.x, GameObject.Find("weight").transform.localPosition.y + 0.02f, GameObject.Find("weight").transform.localPosition.z);
				

				/// <summary>
				/// Left Platform
				/// </summary>
				Vector3 platpos2 = IN_P_PlatformLeft.transform.localPosition;
				platpos2.y -= 1.5f;
				IN_P_PlatformLeft.transform.localPosition = Vector3.Lerp(IN_P_PlatformLeft.transform.localPosition, platpos2, Time.deltaTime);

				Vector3 temppos2 = IN_P_PulleyLeft.transform.localPosition;
				temppos2.y -= 1;
				IN_P_PulleyLeft.transform.localPosition = Vector3.Lerp(IN_P_PulleyLeft.transform.localPosition, temppos2, Time.deltaTime);
				
				//rotate gates
				IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
				//IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
				
				//move rope attached to gate
				Vector3 ropelength = GameObject.Find("adjustablerope5").transform.localScale;
				ropelength.y -= 0.3f;
				if(GameObject.Find("adjustablerope5").transform.localScale.y > 0.3f){
					GameObject.Find("adjustablerope5").transform.localScale = Vector3.Lerp(GameObject.Find("adjustablerope5").transform.localScale, ropelength, Time.deltaTime);
					GameObject.Find("adjustablerope5").transform.Rotate(Time.deltaTime*7, 0, 0);
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
				//Right Rope
				Vector3 tempscale = IN_P_RopeRight.transform.localScale;
				tempscale.y += 0.2f;
				if(maxrightrope > IN_P_RopeRight.transform.localScale.y){
					IN_P_RopeRight.transform.localScale = Vector3.Lerp(IN_P_RopeRight.transform.localScale, tempscale, Time.deltaTime);
				}

				//Left Rope
				if(minleftrope < IN_P_RopeLeft.transform.localScale.y){
					IN_P_RopeLeft.transform.localScale = new Vector3(IN_P_RopeLeft.transform.localScale.x, IN_P_RopeLeft.transform.localScale.y - 0.1f*Time.deltaTime, IN_P_RopeLeft.transform.localScale.z);
				}
				
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
				
				//rotate gates
				IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
				//IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
				
				//move rope attached to gate
				Vector3 ropelength = GameObject.Find("adjustablerope5").transform.localScale;
				ropelength.y += 0.3f;
				if(GameObject.Find("adjustablerope5").transform.localScale.y < 1){
					GameObject.Find("adjustablerope5").transform.localScale = Vector3.Lerp(GameObject.Find("adjustablerope5").transform.localScale, ropelength, Time.deltaTime);
					GameObject.Find("adjustablerope5").transform.Rotate(-Time.deltaTime*7, 0, 0);
				}
			}
		}
	}
}