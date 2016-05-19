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
	//public GameObject IN_P_GateRight;
	public int RotationRate = 25;
	
	public GameObject IN_P_RopeLeft;
	public GameObject IN_P_RopeRight;
	private float minrightrope;
	private float maxrightrope;
	private float minleftrope;
	private float maxleftrope;

	public bool Origin = false;

	public void Start()
	{
		IN_P_Origin_Left = IN_P_PlatformLeft.transform.localPosition;
		IN_P_Origin_Right = IN_P_PlatformRight.transform.localPosition;
		maxrightrope = IN_P_RopeRight.transform.localScale.y;
		minrightrope = maxrightrope * 0.8f;
		minleftrope = IN_P_RopeLeft.transform.localScale.y;
		maxleftrope = maxrightrope * 1.1f;
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
		//Debug.Log(IN_P_GateLeft.transform.rotation.z);
		if(IN_P_GateLeft.transform.rotation.z < 0){
			IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
		}
		if(IN_P_GateLeft.transform.rotation.z > 0.5f){
			IN_P_GateLeft.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
		}/*
		if(IN_P_GateRight.transform.rotation.z < 0){
			IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*RotationRate);
		}
		if(IN_P_GateRight.transform.rotation.z > 0.5f){
			IN_P_GateRight.transform.Rotate(0, 0, Time.deltaTime*-RotationRate);
		}*/
	}

	public void LeftPlatformDown()
	{
		if (IN_P_PulleyRight.transform.localScale.y > 0 || IN_P_PulleyLeft.transform.localScale.y > 0)
		{
			if (IN_P_PulleyRight.transform.localPosition.y >= 2) {

			}
			else
			{
				
				//Right Rope
				Vector3 tempscale = IN_P_RopeRight.transform.localScale;
				tempscale.y -= 0.7f;
				if(minrightrope < IN_P_RopeRight.transform.localScale.y){
					IN_P_RopeRight.transform.localScale = Vector3.Lerp(IN_P_RopeRight.transform.localScale, tempscale, Time.deltaTime);
				}

				//Left Rope
				if(maxleftrope > IN_P_RopeLeft.transform.localScale.y){
					IN_P_RopeLeft.transform.localScale = new Vector3(IN_P_RopeLeft.transform.localScale.x, IN_P_RopeLeft.transform.localScale.y + 0.3f*Time.deltaTime, IN_P_RopeLeft.transform.localScale.z);
				}
				
				//Right Platform
				Vector3 temppos = IN_P_PulleyRight.transform.localPosition;
				temppos.y += 1;
				IN_P_PulleyRight.transform.localPosition = Vector3.Lerp(IN_P_PulleyRight.transform.localPosition, temppos, Time.deltaTime);

				Vector3 platpos = IN_P_PlatformRight.transform.localPosition;
				platpos.y += 1.5f;
				IN_P_PlatformRight.transform.localPosition = Vector3.Lerp(IN_P_PlatformRight.transform.localPosition, platpos, Time.deltaTime);
				
				GameObject.Find("weight").transform.localPosition = new Vector3(GameObject.Find("weight").transform.localPosition.x, GameObject.Find("weight").transform.localPosition.y + 0.02f, GameObject.Find("weight").transform.localPosition.z);
				

				//Left Platform
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
				ropelength.y -= 0.2f;
				if(GameObject.Find("adjustablerope5").transform.localScale.y > 0.2f){
					GameObject.Find("adjustablerope5").transform.localScale = Vector3.Lerp(GameObject.Find("adjustablerope5").transform.localScale, ropelength, Time.deltaTime);
					GameObject.Find("adjustablerope5").transform.Rotate(Time.deltaTime*5, 0, 0);
				}
				Debug.Log(GameObject.Find("adjustablerope5").transform.localScale);
				Debug.Log(GameObject.Find("adjustablerope5").transform.rotation);
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
				tempscale.y += 0.7f;
				if(maxrightrope > IN_P_RopeRight.transform.localScale.y){
					IN_P_RopeRight.transform.localScale = Vector3.Lerp(IN_P_RopeRight.transform.localScale, tempscale, Time.deltaTime);
				}

				//Left Rope
				if(minleftrope < IN_P_RopeLeft.transform.localScale.y){
					IN_P_RopeLeft.transform.localScale = new Vector3(IN_P_RopeLeft.transform.localScale.x, IN_P_RopeLeft.transform.localScale.y - 0.3f*Time.deltaTime, IN_P_RopeLeft.transform.localScale.z);
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