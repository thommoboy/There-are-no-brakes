using UnityEngine;
using System.Collections;

public class CutscenePlay : MonoBehaviour {
	public MovieTexture cutscene;
    WWW request;
    string url;
    // Use this for initialization
    void Start () {
        url = "file:///" + Application.dataPath + "/Resources/Cutscene.ogv";
        request = new WWW(url);
        //cutscene = (MovieTexture)Resources.Load("Cutscene.ogv",MovieTexture);
        cutscene = (MovieTexture)request.movie;
		GetComponent<Renderer>().material.mainTexture = cutscene as MovieTexture;
		cutscene.Play();


	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(url);

        if (!cutscene.isPlaying){
            //cutscene.Play();
            Application.LoadLevel ("Tutorial Level");
		}	

	}
}
