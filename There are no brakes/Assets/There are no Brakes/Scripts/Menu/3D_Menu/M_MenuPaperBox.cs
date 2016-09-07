/***********************
 * M_MenuPaperBox.cs
 * Originally Written by Xinyu Feng
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class M_MenuPaperBox : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		//this.GetComponent<Animation> ().Play ("PaperBoxAnimation");
		//GetComponent<Animator>().StopPlayback();
		animator = this.GetComponent<Animator> ();

		animator.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.Mouse1)) {
			StartCoroutine ("delayExecute");
			GameObject.Find ("MenuButtonManager").GetComponent<M_3DMenuButton> ().started = true;
			animator.enabled = true;
		}*/
	}

	IEnumerator delayExecute(){
		//print (Time.time);
		yield return new WaitForSeconds (5);
		//print (Time.time);

	}
}
