/***********************
 * M_MoveForward.cs
 * Originally Written by Xinyu Feng
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class M_MoveForward : MonoBehaviour {
    bool moving = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (moving) {
            this.transform.position = this.transform.position + Vector3.forward * 8;
        }
	}

    public void startMove(int delayTime) {
        StartCoroutine(delayExecute(delayTime));
    }

    IEnumerator delayExecute(int time)
    {
       // print("camera start moving at : " + time);
        yield return new WaitForSeconds(time);
        this.moving = true;
    }
}
