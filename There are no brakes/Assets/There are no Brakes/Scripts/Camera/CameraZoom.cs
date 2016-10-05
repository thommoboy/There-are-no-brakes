using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	private CameraMultitarget cmt;
	private GameObject ZoomCamera;

	private GameObject Camera1;
	private GameObject Camera2;
	private GameObject Camera3;
	[HideInInspector]
	public string CurrentRoom = "";

	private float ZoomSpeed = 1.0f;
	private float zoomTimeOut = 1.0f;
	private float nextZoomTime = 0.0f;
	[HideInInspector]
	public bool zoomed = false;
	// Use this for initialization
	void Start () {
		if (cmt == null)
			cmt = GetComponent<CameraMultitarget>();

		ZoomCamera = this.gameObject;

		Camera1 = GameObject.Find ("Cam1");
		Camera2 = GameObject.Find ("Cam2");
		Camera3 = GameObject.Find ("Cam3");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (nextZoomTime < 0.0f) {
			nextZoomTime = 0.0f;
		}

		if (nextZoomTime > 0.0f) {
			nextZoomTime -= Time.deltaTime;
		}

		if (!zoomed) {
			if ((Input.GetKey (KeyCode.Space)) && nextZoomTime == 0.0f) {
				zoomed = true;
				if (CurrentRoom == "Room1") {
					cmt.OriginPos = new Vector3 (Camera1.transform.position.x, Camera1.transform.position.y, Camera1.transform.position.z);
					cmt.OriginRot = new Quaternion (Camera1.transform.rotation.x, Camera1.transform.rotation.y, Camera1.transform.rotation.z, Camera1.transform.rotation.w);
				}

				if (CurrentRoom == "Room2") {
					cmt.OriginPos = new Vector3 (Camera2.transform.position.x, Camera2.transform.position.y, Camera2.transform.position.z);
					cmt.OriginRot = new Quaternion (Camera2.transform.rotation.x, Camera2.transform.rotation.y, Camera2.transform.rotation.z, Camera2.transform.rotation.w);
				}

				if (CurrentRoom == "Room3") {
					cmt.OriginPos = new Vector3 (Camera3.transform.position.x, Camera3.transform.position.y, Camera3.transform.position.z);
					cmt.OriginRot = new Quaternion (Camera3.transform.rotation.x, Camera3.transform.rotation.y, Camera3.transform.rotation.z, Camera3.transform.rotation.w);
				}

				cmt.Zoomed = true;
				nextZoomTime = zoomTimeOut;
			}
		}
		if (zoomed) {
			if ((Input.GetKey (KeyCode.Space)) && nextZoomTime == 0.0f) {
				zoomed = false;
				cmt.Zoomed = false;
				nextZoomTime = zoomTimeOut;
			}
		}
	}
}
