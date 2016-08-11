/***********************
 * P_LevelReset.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class P_LevelReset : MonoBehaviour {
    public GameObject[] ObjectsToReset;
	private Vector3[] ResetPositions;
	private Vector3[] ResetScales;
	private Quaternion[] ResetRotations;

	void Start () {
		ResetPositions = new Vector3[ObjectsToReset.Length];
		ResetScales = new Vector3[ObjectsToReset.Length];
		ResetRotations = new Quaternion[ObjectsToReset.Length];
		for (int i = 0; i < ObjectsToReset.Length; i++){
			ResetPositions[i] = ObjectsToReset[i].transform.position;
			ResetScales[i] = ObjectsToReset[i].transform.localScale;
			ResetRotations[i] = ObjectsToReset[i].transform.rotation;
		}
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			ResetLevel();
		}
	}
	
	public void ResetLevel(){
		for (int i = 0; i < ObjectsToReset.Length; i++){
			if(ObjectsToReset[i].GetComponent<Rigidbody>() != null){
				ObjectsToReset[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
				ObjectsToReset[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			if(ObjectsToReset[i].GetComponent<IN_Activation>() != null){
				ObjectsToReset[i].GetComponent<IN_Activation>().activated = false;
			}
			ObjectsToReset[i].transform.position = ResetPositions[i];
			ObjectsToReset[i].transform.localScale = ResetScales[i];
			ObjectsToReset[i].transform.rotation = ResetRotations[i];
		}		
	}
}
