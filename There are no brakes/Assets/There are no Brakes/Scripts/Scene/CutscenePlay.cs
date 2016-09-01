/***********************
 * Tutorial_FakeDarkness.cs
 * Originally Written by Nathan Brown
 * Modified By:
	Xinyu Feng - alternate loading method
 ***********************/
 
using UnityEngine;
using System.Collections;

public class CutscenePlay : MonoBehaviour {
	public MovieTexture cutscene;
	public bool VideoLoadAlt = false;
	public bool isFirst = false;

    WWW request;
    string url;
	
    // Use this for initialization
    void Start () {
		if(VideoLoadAlt){
			url = "file:///" + Application.dataPath + "/Resources/Cutscene.ogv";
			request = new WWW(url);
			cutscene = (MovieTexture)request.movie;
		}
        GetComponent<Renderer>().material.mainTexture = cutscene as MovieTexture;
		cutscene.Play();


	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(url);
		if (isFirst) {
			if (!cutscene.isPlaying || Input.GetKey("return") || Input.GetAxis("Back_1") > 0.1f || Input.GetAxis("Back_2") > 0.1f || Input.GetAxis("Back_3") > 0.1f) {
				//cutscene.Play();
				Application.LoadLevel ("Tutorial Level");
			}	
		} else {
			cutscene.loop = true;
		}

	}
}
