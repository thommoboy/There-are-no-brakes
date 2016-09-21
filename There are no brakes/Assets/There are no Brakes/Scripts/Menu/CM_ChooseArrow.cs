using UnityEngine;
using System.Collections;

public class CM_ChooseArrow : MonoBehaviour {

    private bool locked;
    private float floatingSpeed = 5;
    private float amplitude = 0.4f;
    private int verticalPos;
    private Vector3 ori_pos;
	// Use this for initialization
	void Start () {
        locked = false;
        verticalPos = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (locked) {
            this.transform.position =new Vector3(this.transform.position.x, ori_pos.y + amplitude * Mathf.Sin(floatingSpeed * Time.time), this.transform.position.z) ;
        }
	}

    public void switchLockStatu() {
        locked = !locked;
        if (locked) {
            ori_pos = this.transform.position;
        }
    }

    public int getVerticalPos() {
        return verticalPos;
    }

    public void changeVerticalPos(int position) {
        verticalPos = position;
    }

    public bool getLocked() {
        return locked;
    }
}
