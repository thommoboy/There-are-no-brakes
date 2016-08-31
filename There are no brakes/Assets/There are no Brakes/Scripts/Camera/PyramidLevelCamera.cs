using UnityEngine;
using System.Collections;

public class PyramidLevelCamera : MonoBehaviour {
    public enum Player_name {player1,player2,player3 }
    public Player_name playerName;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    private float height = 9f;
    public float distance = 9f;
    Vector3 ori_pos;

    // Use this for initialization
    void Start () {
        ori_pos = this.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        if (playerName == Player_name.player1)
        {
            if (Input.GetAxis("Y_1") < 0.1f) {
                Vector3 camPos = this.transform.position;
                this.transform.position = new Vector3(player1.transform.position.x + distance, player1.transform.position.y + height, player1.transform.position.z);
            }

        }

        if (playerName == Player_name.player2)
        {
            if (Input.GetAxis("Y_2") < 0.1f)
            {
                Vector3 camPos = this.transform.position;
                this.transform.position = new Vector3(player2.transform.position.x + distance, player2.transform.position.y + height, player2.transform.position.z);
            }

        }

        if (playerName == Player_name.player3)
        {
            if (Input.GetAxis("Y_3") < 0.1f)
            {
                Vector3 camPos = this.transform.position;
                this.transform.position = new Vector3(player3.transform.position.x + distance, player3.transform.position.y + height, player3.transform.position.z);
            }

        }

    }
}
