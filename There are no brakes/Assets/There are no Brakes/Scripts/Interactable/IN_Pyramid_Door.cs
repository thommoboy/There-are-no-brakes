/***********************
 * IN_Pyramid_Door.cs
 * Originally Written by Nathan Brown
 * Modified By:
 *      Xinyu Feng:         Animation of using the door.
 ***********************/
using UnityEngine;
using System.Collections;
 
public class IN_Pyramid_Door : MonoBehaviour {
	public float timeout = 2.0F;
    public float movingSpeed = 2f;
    public GameObject Player;
    private float nextInteract = 0.0F;
	private GameObject playercontroller;
    private bool entering = false;
    private GameObject usingDoorPlayer;
    private float destination_x;
    private float direction;

    public GameObject Door_left_1;
    public GameObject Door_left_2;
    public GameObject Door_right_1;
    public GameObject Door_right_2;
    public GameObject playerController;
    private float door_left_pos_z;
    private float door_right_pos_z;
    void Start(){
		playercontroller = GameObject.Find("PlayerControllers");
        door_left_pos_z = Door_left_1.transform.localPosition.z;
        door_right_pos_z = Door_right_1.transform.localPosition.z;

    }
	
	void Update(){
        if (entering)
        {
            //moving player
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
            Player.GetComponent<Animator>().Play("Walk");
            usingDoorPlayer.transform.localPosition = Vector3.MoveTowards(usingDoorPlayer.transform.localPosition,
                new Vector3(destination_x, usingDoorPlayer.transform.localPosition.y, usingDoorPlayer.transform.localPosition.z), movingSpeed * Time.deltaTime);
            moveDoor(-3.2f, 3.35f);
            if (Mathf.Abs(usingDoorPlayer.transform.position.x) >= Mathf.Abs(destination_x))
            {
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().SoundFXOutput.Stop();
                Player.GetComponent<Animator>().Play("Idle");
                usingDoorPlayer.transform.Rotate(0, -(direction * 90), 0);
                entering = false;
                usingDoorPlayer.GetComponent<P_PyramidPosition>().usingdoor = false;
                playerController.GetComponent<P_Movement>().P2Uncontroled = false;
            }
        }
        else {
            //close door
            moveDoor(door_left_pos_z, door_right_pos_z);
        }
	}

    void moveDoor(float left_pos, float right_pos) {
        float door_speed = 1f;
        //moving door
        //to z- direction
        Door_left_1.transform.localPosition = Vector3.MoveTowards(Door_left_1.transform.localPosition,
            new Vector3(Door_left_1.transform.localPosition.x, Door_left_1.transform.localPosition.y, left_pos), door_speed * Time.deltaTime);
        Door_left_2.transform.localPosition = Vector3.MoveTowards(Door_left_2.transform.localPosition,
            new Vector3(Door_left_2.transform.localPosition.x, Door_left_2.transform.localPosition.y, left_pos), door_speed * Time.deltaTime);
        //to z+
        Door_right_1.transform.localPosition = Vector3.MoveTowards(Door_right_1.transform.localPosition,
            new Vector3(Door_right_1.transform.localPosition.x, Door_right_1.transform.localPosition.y, right_pos), door_speed * Time.deltaTime);
        Door_right_2.transform.localPosition = Vector3.MoveTowards(Door_right_2.transform.localPosition,
            new Vector3(Door_right_2.transform.localPosition.x, Door_right_2.transform.localPosition.y, right_pos), door_speed * Time.deltaTime);
    }

	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			intrigger = true;
            if (Time.time > nextInteract){
				if (other.name == "Player1"){
					if (Input.GetKey (KeyCode.DownArrow)) {
						movePlayer(other);
					}
				}
				if (other.name == "Ancient"){
					if (Input.GetKey (KeyCode.S)) {
						movePlayer(other);
                    }
                }
				if (other.name == "Player3"){
					if (Input.GetKey (KeyCode.K)) {
						movePlayer(other);
					}
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player"){
			intrigger = false;
		}
	}
	
	void movePlayer(Collider other){
		nextInteract = Time.time + timeout;
		if(other.GetComponent<P_PyramidPosition>().Direction == "x+"){
			other.GetComponent<P_PyramidPosition>().Direction = "x-";
			playercontroller.GetComponent<P_Movement>().P2Direction = "x-";
		} else {
			other.GetComponent<P_PyramidPosition>().Direction = "x+";
			playercontroller.GetComponent<P_Movement>().P2Direction = "x+";
		}
		//other.transform.position = new Vector3 (-other.transform.position.x,other.transform.position.y,other.transform.position.z);
        destination_x = -other.transform.position.x;
        if (other.transform.position.x > 0)
            direction = -1;
        else
            direction = 1;
        entering = true;
        usingDoorPlayer = other.gameObject;
        usingDoorPlayer.transform.Rotate(0,(direction*90),0);
        usingDoorPlayer.GetComponent<P_PyramidPosition>().usingdoor = true;
        playerController.GetComponent<P_Movement>().P2Uncontroled = true;
    }
	
    


	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Interact] to use");
		}
	}
}