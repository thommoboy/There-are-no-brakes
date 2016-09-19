/***********************
 * Train_Wheels.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
 using UnityEngine;
using System.Collections;

public class Train_Wheels : MonoBehaviour {
    private float speed = 999;
    // Use this for initialization
    void Start () {
    }
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(Vector3.down * Time.deltaTime * speed);
    }
}
