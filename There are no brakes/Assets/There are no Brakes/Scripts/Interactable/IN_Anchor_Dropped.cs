/***********************
 * IN_Anchor_Dropped.cs
 * Originally Written by 
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Anchor_Dropped : MonoBehaviour{
	private float anchorHeight;
	public int dropDistance = 35;
	private Vector3 lineStart;
	private Vector3 lineEnd;

	public void Start(){
		anchorHeight = GameObject.Find("Anchor").transform.position.y;
		lineStart = GameObject.Find("ChainTop").transform.position;
		this.GetComponent<LineRenderer>().SetPosition(1, lineStart);
	}

	private bool dropped = false;
	public void Update(){
		//set chain from anchor
		lineEnd = new Vector3(this.transform.position.x+2, this.transform.position.y+11, this.transform.position.z-5);
		this.GetComponent<LineRenderer>().SetPosition(0, lineEnd);
		float lineDistance = Vector3.Distance(lineStart, lineEnd);
		this.GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(lineDistance/2,1);
		//set chain from stopper
		Vector3 otherChainPos = GameObject.Find("ChainBack").transform.position;
		GameObject.Find("ChainBack").GetComponent<LineRenderer>().SetPosition(0, otherChainPos);
		GameObject.Find("ChainBack").GetComponent<LineRenderer>().SetPosition(1, lineStart);
		float otherLineDistance = Vector3.Distance(lineStart, otherChainPos);
		GameObject.Find("ChainBack").GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(otherLineDistance/2,1);
		//check if dropped all the way
		if(GameObject.Find("Anchor").transform.position.y < anchorHeight - dropDistance){
			if(!dropped){
				//level comletion
				GameObject.Find("HUDmanager").GetComponent<P_HUD>().LevelCompleted();
				dropped = true;
			}
		}
	}
}