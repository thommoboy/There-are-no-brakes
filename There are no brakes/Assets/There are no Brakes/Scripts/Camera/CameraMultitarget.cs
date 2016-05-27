using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMultitarget : MonoBehaviour {
	
	/// <summary>
	/// The target objects.
	/// </summary>
	/// 
	public List<GameObject> targetObjects = new List<GameObject>();

	public Vector3 orbitRotation;

	/// <summary>
	/// the closest the camera will be, from here the objects won't get framed.
	/// </summary>	
	public float minDistanceToTarget = 10;
	
	/// <summary>
	/// the maximum distance to focus objects. After this distance objects won't get framed.
	/// </summary>	
	public float maxDistanceToTarget = 100;
	

	/// <summary>
	/// The screen safe area to keep your objects in, it's a percent of the fov.
	/// </summary>	
	public float screenSafeArea = 200.0f;
	
	/// <summary>
	/// the easing function that will be used to interpolate positions.
	/// </summary>
	public float positionInterpolationSpeed = 5f;
	
	/// <summary>
	/// the speed it will interpolate to the look at point desired.
	/// </summary>
	public float targetInterpolationSpeed = 2f;

	/// <summary>
	/// The orthographic safe area multiplier to reduce the amount of safe area. More will result in 
	/// less space when adjusting the safe area amount.
	/// </summary>
	public float orthographicSafeAreaMulti = 4f;


	public Vector3 camPosition;
	
	/// <summary>
	/// Private variables for the script functionality.
	/// </summary>
	#region private
	private Vector3 lookAt;
	private Vector3 currentLookAt;
	private Vector3 posAt;
	private Vector3 currentPosAt;
	private Transform trtemp;
	
	private Vector3 scrMin = Vector3.zero;
	private Vector3 scrMax = Vector3.zero;
	private float extraSpeed = 1.0f;
		
	private Vector3 cameraDirection;
	private Bounds currentBounds;

	public Vector3 origin;
	public Quaternion originalRot;

	#endregion
	
	// Use this for initialization
	void Start () {
		origin = transform.position;
		originalRot = transform.rotation;

		camPosition = transform.position;
	
		// places the camera at the initial position, relative to the look at vector.
		posAt = camPosition;
		Bounds b = GetElementsBounds();
		
		
		//cameraDirection = b.center - posAt;
		cameraDirection = posAt - b.center;
		cameraDirection = cameraDirection.normalized;
		
		lookAt = b.center;
		currentPosAt = posAt;
		currentLookAt = lookAt;

		orbitRotation = Quaternion.identity.eulerAngles;
	}
	
	private Bounds GetElementsBounds()
	{
		Bounds bounds = new Bounds(Vector3.zero, Vector3.one);
	
		if (targetObjects.Count > 0)
		{						
			bool inited = false;
			// we get the maximum and minimum bounds of the elements we want to fit in the camera.			
			foreach(GameObject tr in targetObjects)
			{				
				if (tr.GetComponent<CameraMultiTargetObjective>().enableTracking)
				{
					if (!inited)
					{
						bounds = new Bounds (tr.transform.position, tr.GetComponent<Renderer>().bounds.size);;
						inited = true;
					}else
					{
						bounds.Encapsulate(tr.GetComponent<Renderer>().bounds);			
					}
				}				
			}
		}
		
		return bounds;		
	}
	
	void OnDrawGizmos()
	{
		
		// target debug info.
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(currentLookAt, 0.5f);
		
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(lookAt, 0.6f);
				
		Gizmos.DrawLine(currentLookAt, lookAt);
		
		// bounds debug info.
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(currentBounds.center, currentBounds.size);
	}
	
	// Update is called once per frame
	void FixedUpdate () {	
		currentBounds = GetElementsBounds();
		
		// we stablish our lookAt point to the center of that bounds.
		lookAt = currentBounds.center;
		
		float boundsSizeSphere = currentBounds.size.magnitude / 2;
		Camera c = GetComponent<Camera>();
		float hFov = Mathf.Atan(Mathf.Tan(c.fieldOfView * Mathf.Deg2Rad / 2f) * c.aspect) * Mathf.Rad2Deg;
		float fov = Mathf.Min (c.fieldOfView, hFov) - ((screenSafeArea / 100) * c.fieldOfView);		
		float distance = boundsSizeSphere / (Mathf.Sin(fov * Mathf.Deg2Rad/2));
		
		// we get the distance at which we need to position our camera.
		if (!Input.GetKey(KeyCode.Space)) {
			distance = Mathf.Max (minDistanceToTarget, Mathf.Min (distance, maxDistanceToTarget));
			
			// we interpolate to the new desired positions.	
			Vector3 currentCameraDirection = Quaternion.Euler (orbitRotation) * cameraDirection;
			currentLookAt = Vector3.Lerp (currentLookAt, lookAt, targetInterpolationSpeed * Time.fixedDeltaTime);
			posAt = Vector3.Lerp (posAt, currentLookAt + (currentCameraDirection * distance), positionInterpolationSpeed * Time.fixedDeltaTime);

			if (c.orthographic) {
				c.orthographicSize = boundsSizeSphere + (screenSafeArea / orthographicSafeAreaMulti);
			}

			c.transform.position = Vector3.Lerp (new Vector3(c.transform.position.x, c.transform.position.y - 0.2f, c.transform.position.z), posAt, 0.1f);

			//c.transform.LookAt (currentLookAt);
		} else {
			//Debug.Log ("Zoom Out");
			c.transform.position = Vector3.Lerp (c.transform.position, origin, 0.05f);
			//c.transform.rotation = Quaternion.Lerp (c.transform.rotation, originalRot, 0.05f);
		}
	}
}
