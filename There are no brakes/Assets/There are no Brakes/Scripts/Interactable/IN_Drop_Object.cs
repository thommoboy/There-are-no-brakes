/***********************
 * IN_Drop_Object.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class IN_Drop_Object : MonoBehaviour {

	public bool isPyramidLevel = false;
	
	static Vector3 WeightRespawnPOS;
	void Start(){
		WeightRespawnPOS = GameObject.Find ("weight").transform.position;		
	}

	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			other.transform.FindChild("Player").gameObject.GetComponent<P_PickUp>().DropObject(true);
		}
		if(other.tag == "Weight" && isPyramidLevel){
			other.transform.position = WeightRespawnPOS;
		}
	}
}