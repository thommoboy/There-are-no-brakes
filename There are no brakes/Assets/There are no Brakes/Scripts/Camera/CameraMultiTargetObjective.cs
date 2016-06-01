/***********************
 * Multiple Target Tracking and Framing Camera
 * CameraMultitargetObjective.cs
 * Originally Written by Rainbirth SLU
 * Modified By:
 * Pierce Thompson
 ***********************/
using UnityEngine;
using System.Collections;

/// <summary>
/// Camera multi target objective.
/// 
/// This script makes one object transform available to the Multitarget camera.
/// Just drop this script to the Transform you want to register to the camera and it will track it automatically.
/// 
/// </summary>
public class CameraMultiTargetObjective : MonoBehaviour {
	
	public bool enableTracking = true;
	
	private bool prevEnabled;
	
	// We assign the transform of the gameobject to the camera track list if the main camera is a multitarget camera.
	void Start () {	
		AddTracking();
	}	
	
	// When we destroy the object we remove the tracking element from the camera.
	void OnDestroy() 
	{
		RemoveTracking();
	}
	
	/// <summary>
	/// Activates the tracking,  can be used with Messages so you can enable or disable the tracking by sending a message to the object.
	/// </summary>	
	void AddTracking()
	{
		CameraMultitarget camera = Camera.main.GetComponent<CameraMultitarget>();
		
		if (camera != null)
		{
			camera.targetObjects.Add( gameObject );		
		}		
	}
	
	/// <summary>
	/// Deactivates the tracking,  can be used with Messages so you can enable or disable the tracking by sending a message to the object.
	/// </summary>
	void RemoveTracking()
	{
		if (Camera.main) 
		{
			CameraMultitarget camera = Camera.main.GetComponent<CameraMultitarget>();
			if (camera != null)
			{
				camera.targetObjects.Remove( gameObject);
			}
		}
	}
	
	
	void Update()
	{
	}
}
