using UnityEngine;
using System.Collections;

public class SwapPlayers : MonoBehaviour {
    P_Movement movement;
    string[] derections = new string[4];
	// Use this for initialization
	void Start () {
        movement = GameObject.Find("PlayerControllers").GetComponent<P_Movement>();
        movement.Player1 = GameObject.Find("Player" + PlayerPrefs.GetInt("player1choose"));
        movement.Player1Anim = movement.Player1.transform.GetChild(0).gameObject;

        movement.Player2 = GameObject.Find("Player" + PlayerPrefs.GetInt("player2choose"));
        movement.Player2Anim = movement.Player2.transform.GetChild(0).gameObject;
        movement.Player3 = GameObject.Find("Player" + PlayerPrefs.GetInt("player3choose"));
        movement.Player3Anim = movement.Player3.transform.GetChild(0).gameObject;

        derections[1] = movement.P1Direction;
        derections[2] = movement.P2Direction;
        derections[3] = movement.P3Direction;

        movement.P1Direction = derections[PlayerPrefs.GetInt("player1choose")];
        movement.P2Direction = derections[PlayerPrefs.GetInt("player2choose")];
        movement.P3Direction = derections[PlayerPrefs.GetInt("player3choose")];

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
