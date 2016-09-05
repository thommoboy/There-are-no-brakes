using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ms_3D_CreditsText : MonoBehaviour {
    public TextAsset textFile;
    public float speed;
    int lines;
    bool isPlay = false;
    Vector3 ori_pos;
    public GameObject creditsMenu;
	// Use this for initialization
	void Start () {
        Text txt = GetComponent<Text>();
        string content = textFile.text;
        txt.text = content;
        lines = content.Split('\n').Length;
        ori_pos = transform.localPosition;
        isPlay = false;
    }

    void Update() {
        if (creditsMenu.transform.position.y <= 270)
        {
            StartPlay();
        }
        else {
            reset();
        }

        if (isPlay)
        {
            transform.localPosition = transform.localPosition + new Vector3(1.0f,0,0) * speed * Time.deltaTime;
        }
        
    }

    public void StartPlay() {
        isPlay = true;
    }

    public void reset() {
        isPlay = false;
        transform.localPosition = ori_pos;
    }

	

}
