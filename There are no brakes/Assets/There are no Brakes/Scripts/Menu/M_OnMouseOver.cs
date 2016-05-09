using UnityEngine;
using System.Collections;

public class M_OnMouseOver : MonoBehaviour {
	
	// Use this for initialization
	public void MouseOver(string buttonName) {
		GameObject.Find(buttonName).gameObject.transform.GetChild (0).gameObject.transform.localScale =  new Vector3 ((float)1.2, (float)1.2,(float)1.2);
	}

}
