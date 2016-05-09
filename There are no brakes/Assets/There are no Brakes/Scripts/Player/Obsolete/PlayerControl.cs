using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float jumpPower = 1000;
    bool onAir = true;
    int touchItem = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) {
            if (Input.GetKey(KeyCode.A)) {
                this.transform.Translate(Vector3.left * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D)) {
                this.transform.Translate(Vector3.right * Time.deltaTime);
            }

        }

        if (Input.anyKeyDown) {
            if (Input.GetKey(KeyCode.Space) && this.transform.position.y <= 0)
            {
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
            }
        }

	}

    void OnCollisionEnter(Collision other) {
        touchItem++;
        onAir = false;
    }


    void OnCollisionExit(Collision other) {
        touchItem--;
        if (touchItem == 0) onAir = true;
    }
}
