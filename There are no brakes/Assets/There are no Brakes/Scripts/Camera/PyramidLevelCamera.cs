using UnityEngine;
using System.Collections;

public class PyramidLevelCamera : MonoBehaviour {
    public enum Player_name {player1,player2,player3 }
    public Player_name playerName;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    private float height = 4f;
    public float distance = 9f;
	private bool zoomed = false;
	private float defaultsize;
    Vector3 ori_pos;

	private float timeout = 0.4F;
	private float nextInteract = 0.0F;

    // Use this for initialization
    void Start () {
        ori_pos = this.transform.position;
		defaultsize = this.GetComponent<Camera> ().orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextInteract) {
			if (playerName == Player_name.player1) {
				if (Input.GetAxis ("Y_1") > 0.1f || Input.GetKey (KeyCode.Space)) {
					zoomed = !zoomed;
					nextInteract = Time.time + timeout;
				}

			}

			if (playerName == Player_name.player2) {
				if (Input.GetAxis ("Y_2") > 0.1f || Input.GetKey (KeyCode.Space)) {
					zoomed = !zoomed;
					nextInteract = Time.time + timeout;
				}

			}

			if (playerName == Player_name.player3) {
				if (Input.GetAxis ("Y_3") > 0.1f || Input.GetKey (KeyCode.Space)) {
					zoomed = !zoomed;
					nextInteract = Time.time + timeout;
				}

			}
		}


		if (zoomed) {
			if (playerName == Player_name.player1)
			{
				this.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y + height, this.transform.position.z);
				this.GetComponent<Camera> ().orthographicSize = distance;
			}

			if (playerName == Player_name.player2)
			{
				this.transform.position = new Vector3(this.transform.position.x, player2.transform.position.y + height, player2.transform.position.z);
				this.GetComponent<Camera> ().orthographicSize = distance;

			}

			if (playerName == Player_name.player3)
			{
				this.transform.position = new Vector3(player3.transform.position.x, player3.transform.position.y + height, this.transform.position.z);
				this.GetComponent<Camera> ().orthographicSize = distance;

			}
		} else {
			if (playerName == Player_name.player1)
			{
				this.transform.position = ori_pos;
				this.GetComponent<Camera> ().orthographicSize = defaultsize;
			}

			if (playerName == Player_name.player2)
			{
				this.transform.position = ori_pos;
				this.GetComponent<Camera> ().orthographicSize = defaultsize;

			}

			if (playerName == Player_name.player3)
			{
				this.transform.position = ori_pos;
				this.GetComponent<Camera> ().orthographicSize = defaultsize;

			}
		}

    }
}
