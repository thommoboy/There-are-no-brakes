using UnityEngine;
using System.Collections;

public class Adventurer_RopeRender : MonoBehaviour {
	public GameObject gOTransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 lineEnd = new Vector3(gOTransform.transform.position.x, gOTransform.transform.position.y, gOTransform.transform.position.z);
		Vector3 lineStart = this.transform.position;
		this.GetComponent<LineRenderer>().SetPosition(0, lineStart);
		this.GetComponent<LineRenderer>().SetPosition(1, lineEnd);
	}
}
