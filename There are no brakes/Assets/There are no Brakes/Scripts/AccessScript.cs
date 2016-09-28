using UnityEngine;
using System.Collections;

public class AccessScript : MonoBehaviour {
	public AudioClip sound;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			AudioManager.PlayAudio (this.gameObject, sound);
	}
}
