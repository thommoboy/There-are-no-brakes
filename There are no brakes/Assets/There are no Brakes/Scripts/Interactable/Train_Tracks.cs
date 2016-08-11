using UnityEngine;
using System.Collections;

public class Train_Tracks : MonoBehaviour {
    public float speed;
    public enum Derection {forward,back,left,right }
    public Derection TracksMoveDerection;
    public GameObject[] tracks;
    private Vector3[] ori_pos;
    private Vector3 dect;
    private float sum;
    private int head = 0;
    // Use this for initialization
    void Start () {
        ori_pos = new Vector3[tracks.Length];
        for (int i = 0; i < tracks.Length; i++) {
            ori_pos[i] = tracks[i].transform.localPosition;
        }

        switch (TracksMoveDerection) {
            case Derection.forward:
                dect = Vector3.forward;
                break;
            case Derection.back:
                dect = Vector3.back;
                break;
            case Derection.left:
                dect = Vector3.left;
                break;
            case Derection.right:
                dect = Vector3.right;
                break;
            default:
                break;
        }
        sum = 0;
        tracksNum = tracks.Length;
    }
    int tracksNum;
	// Update is called once per frame
	void Update () {
        //Debug.Log(head + "  head x:  " + tracks[head].transform.localPosition.x);
        if (tracks[head].transform.localPosition.x >= (ori_pos[0].x + ori_pos[0].x - ori_pos[1].x))
        {
            tracks[head].transform.localPosition = ori_pos[tracksNum - 1];
            head = (head + 1) % tracksNum;
        }

        for (int i = 0; i < tracks.Length; i++)
        {
            tracks[i].transform.localPosition = tracks[i].transform.localPosition + dect * speed * Time.deltaTime;
        }
        

    }
}
