using UnityEngine;
using System.Collections;

public class Anchor : MonoBehaviour{
	private GameObject anchor;
	public int minHeight;
	
	public void Start(){
		anchor = GameObject.Find("Anchor");
	}
    
	public void FixedUpdate(){
		if(anchor.transform.position.y < minHeight){
			Debug.Log("Anchor fell!");
			//Level completion stuff here
		}
	}
}