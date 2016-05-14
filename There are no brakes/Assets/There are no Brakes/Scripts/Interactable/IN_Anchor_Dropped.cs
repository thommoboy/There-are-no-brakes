using UnityEngine;
using System.Collections;

public class IN_Anchor_Dropped : MonoBehaviour{
	private float anchorHeight;
	public int dropDistance = 40;

	public void Start(){
		anchorHeight = GameObject.Find("Anchor").transform.position.y;
	}

	private bool dropped = false;
	public void Update(){
		//Debug.Log(GameObject.Find("Anchor").transform.position.y);
		if(GameObject.Find("Anchor").transform.position.y < anchorHeight - dropDistance){
			if(!dropped){
				//Debug.Log("Anchor Dropped");
				//level comletion
				GameObject.Find("HUDmanager").GetComponent<P_HUD>().LevelCompleted();
				dropped = true;
			}
		}
	}
}