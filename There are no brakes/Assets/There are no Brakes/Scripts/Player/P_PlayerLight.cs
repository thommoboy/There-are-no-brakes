using UnityEngine;
using System.Collections;

public class P_PlayerLight : MonoBehaviour {
	public GameObject light;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (light.name == "Light1") {
			light.transform.position = new Vector3(player1.transform.position.x+0.5f,player1.transform.position.y,player1.transform.position.z);
		} else if(light.name == "Light2"){
			light.transform.position = new Vector3(player2.transform.position.x+0.5f,player2.transform.position.y,player2.transform.position.z);;
		} else if(light.name == "Light3"){
			light.transform.position = new Vector3(player3.transform.position.x+0.5f,player3.transform.position.y,player3.transform.position.z);;
			light.transform.rotation = Quaternion.LookRotation (-player3.transform.right); //Industrialist
		}
	}
}
