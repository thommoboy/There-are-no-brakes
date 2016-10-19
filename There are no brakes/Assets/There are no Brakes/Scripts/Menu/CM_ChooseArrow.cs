using UnityEngine;
using System.Collections;

public class CM_ChooseArrow : MonoBehaviour {

    private bool locked;
    private float floatingSpeed = 5;
    private float amplitude = 0.004f;
    private int verticalPos;
    private Vector3 ori_pos;
    public bool isMainMenu = false;
	// Use this for initialization
	void Start () {
        locked = false;
        verticalPos = 0;
        ori_pos = this.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (locked) {
            if (!isMainMenu)
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, ori_pos.y + 100* amplitude * Mathf.Sin(floatingSpeed * Time.time), this.transform.localPosition.z) ;
            if (isMainMenu)
                this.transform.localPosition = new Vector3(ori_pos.x + amplitude *10 * Mathf.Sin(floatingSpeed * Time.time), this.transform.localPosition.y, this.transform.localPosition.z);
        }
	}

    public void switchLockStatu() {
        //Debug.Log(verticalPos);
        locked = !locked;
        if (locked && !isMainMenu) {
            ori_pos = this.transform.localPosition;
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
