/***********************
 * CameraPreviewObjective.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class CameraPreviewObjective : MonoBehaviour {
	
	public GameObject[] CamPositions;
	private Vector3[] Pos;
	
	private int currentCam = -1;
	
	private float currentLerpTime;
	public float lerpTime = 1f;
	public float delayTime = 1f;
	private float NextMoveTime;
	
	public bool pyramid = false;
	private GameObject icons;
	
    // Use this for initialization
    void Start () {
		Pos = new Vector3[CamPositions.Length+1];
		for (int i = 0; i < CamPositions.Length; i++) {
			Pos[i] = CamPositions[i].transform.position;
        }
		Pos[CamPositions.Length] = CamPositions[0].transform.position;
		
		this.transform.position = Pos[0];
		currentLerpTime = 0f;
		NextMoveTime = delayTime;
		if(pyramid){
			icons = GameObject.Find("Player Screen Indicators");
			icons.SetActive (false);
		}
        Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(currentCam != -1){
			currentLerpTime += Time.unscaledDeltaTime;
			if (currentLerpTime > lerpTime) {
				currentLerpTime = lerpTime;
			}
			float percentage = currentLerpTime / lerpTime;		
			
			this.transform.position = Vector3.Lerp(Pos[currentCam], Pos[currentCam+1], percentage);
			
			
			if(percentage >= 1f && NextMoveTime == 999999999999999f){
				NextMoveTime = Time.realtimeSinceStartup + delayTime;
			}
		}
		
		if(Time.realtimeSinceStartup > NextMoveTime){
			currentLerpTime = 0f;
			currentCam++;
			NextMoveTime = 999999999999999f;
		}
		
		if(currentCam >= CamPositions.Length){
			Time.timeScale = 1;
			if(pyramid){
				icons.SetActive (true);
			}
			Destroy(this.gameObject);
		}
    }
}
