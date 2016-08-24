using UnityEngine;
using System.Collections;

public class CutscenePlay : MonoBehaviour {
	public MovieTexture cutscene;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = cutscene as MovieTexture;
		cutscene.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(!cutscene.isPlaying){
		Application.LoadLevel ("Tutorial Level");
		}	
	}
}
