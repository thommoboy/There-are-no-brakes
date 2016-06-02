/***********************
 * M_OnMouseExit.cs
 * Originally Written by Xinyu Feng
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class M_OnMouseExit : MonoBehaviour {


	public void MouseExit(string buttonName) {
		GameObject.Find(buttonName).gameObject.transform.GetChild (0).gameObject.transform.localScale =  new Vector3 ((float)1, (float)1,(float)1);
	}
}
