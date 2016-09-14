using UnityEngine;
using System.Collections;

public class PyramidLevelCamera : MonoBehaviour {
    public enum Player_name {player1,player2,player3,player2ALT }
    public Player_name playerName;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    private float height = 3f;
    private float distance = 25f;
	private bool zoomed = false;
    Vector3 ori_pos;
	private GameObject PlayerController;

	private float timeout = 0.4F;
	private float nextInteract = 0.0F;
	
	private bool allzoomed = false;
	private string directioncheck = "x+";
	
	private float currentLerpTime;
	private float lerpTime = 1.5f;

    // Use this for initialization
    void Start () {
        ori_pos = this.transform.position;
		PlayerController = GameObject.Find ("PlayerControllers");
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextInteract) {
			if (Input.GetKey (KeyCode.Space)){
				allzoomed = !allzoomed;
				currentLerpTime = 0f;
				zoomed = allzoomed;
				nextInteract = Time.time + timeout;
			}
		
			if (playerName == Player_name.player1) {
				if (Input.GetAxis ("Y_1") > 0.1f) {
					zoomed = !zoomed;
					currentLerpTime = 0f;
					nextInteract = Time.time + timeout;
				}

			}

			if (playerName == Player_name.player2) {
				if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x+"){
					if (Input.GetAxis ("Y_2") > 0.1f) {
						zoomed = !zoomed;
					currentLerpTime = 0f;
						nextInteract = Time.time + timeout;
					}
				} else {
					zoomed = false;
				}
			}

			if (playerName == Player_name.player3) {
				if (Input.GetAxis ("Y_3") > 0.1f) {
					zoomed = !zoomed;
					currentLerpTime = 0f;
					nextInteract = Time.time + timeout;
				}

			}
			
			if(playerName == Player_name.player2ALT) {
				if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x-"){
					if (Input.GetAxis ("Y_2") > 0.1f) {
						zoomed = !zoomed;
						currentLerpTime = 0f;
						nextInteract = Time.time + timeout;
					}
				} else {
					zoomed = false;
				}
			}
		}
		
		
		currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }
		float percentage = currentLerpTime / lerpTime;
		percentage = percentage*percentage;

		if (zoomed) {
			if (playerName == Player_name.player1)
			{
				this.transform.position = Vector3.Lerp(ori_pos, new Vector3(player1.transform.position.x, player1.transform.position.y + height, ori_pos.z + distance), percentage);
			}

			if (playerName == Player_name.player2)
			{
				this.transform.position = Vector3.Lerp(ori_pos, new Vector3(ori_pos.x - distance, player2.transform.position.y + height, player2.transform.position.z), percentage);
			}

			if (playerName == Player_name.player2ALT)
			{
				this.transform.position = Vector3.Lerp(ori_pos, new Vector3(ori_pos.x + distance, player2.transform.position.y + height, player2.transform.position.z), percentage);
			}

			if (playerName == Player_name.player3)
			{
				this.transform.position = Vector3.Lerp(ori_pos, new Vector3(player3.transform.position.x, player3.transform.position.y + height, ori_pos.z - distance), percentage);
			}
		} else {
			if (playerName == Player_name.player1)
			{
				this.transform.position = Vector3.Lerp(this.transform.position, ori_pos, percentage);
			}

			if (playerName == Player_name.player2 || playerName == Player_name.player2ALT)
			{
				this.transform.position = Vector3.Lerp(this.transform.position, ori_pos, percentage);

			}

			if (playerName == Player_name.player3)
			{
				this.transform.position = Vector3.Lerp(this.transform.position, ori_pos, percentage);
			}
		}

    }
}
