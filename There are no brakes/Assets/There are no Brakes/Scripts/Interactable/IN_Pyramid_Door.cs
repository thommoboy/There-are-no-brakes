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
    private IN_TextTrigger_ConetentControl TextController;

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
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
    }
	
	void Update(){
		if(intrigger){
			//TextController.display = true;
			//TextController.content = "Press [Interact] to use";
            //TextController.lineNum = 1;
			this.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.shader = Shader.Find("TSF/BaseOutline1");
			this.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.shader = Shader.Find("TSF/BaseOutline1");
			this.transform.GetChild(0).transform.GetChild(2).GetComponent<Renderer>().material.shader = Shader.Find("TSF/BaseOutline1");
			this.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().material.shader = Shader.Find("TSF/BaseOutline1");
			this.transform.GetChild(1).transform.GetChild(1).GetComponent<Renderer>().material.shader = Shader.Find("TSF/BaseOutline1");
			this.transform.GetChild(1).transform.GetChild(2).GetComponent<Renderer>().material.shader = Shader.Find("TSF/BaseOutline1");
		} else {
			this.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().material.shader = Shader.Find("Standard");
			this.transform.GetChild(0).transform.GetChild(1).GetComponent<Renderer>().material.shader = Shader.Find("Standard");
			this.transform.GetChild(0).transform.GetChild(2).GetComponent<Renderer>().material.shader = Shader.Find("Standard");
			this.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().material.shader = Shader.Find("Standard");
			this.transform.GetChild(1).transform.GetChild(1).GetComponent<Renderer>().material.shader = Shader.Find("Standard");
			this.transform.GetChild(1).transform.GetChild(2).GetComponent<Renderer>().material.shader = Shader.Find("Standard");
		}
		
        if (entering)
        {
            Debug.Log("enter");
            //moving player
           // GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
            Player.GetComponent<Animator>().Play("Walk");
            usingDoorPlayer.transform.localPosition = Vector3.MoveTowards(usingDoorPlayer.transform.localPosition,
                new Vector3(destination_x, usingDoorPlayer.transform.localPosition.y, usingDoorPlayer.transform.localPosition.z), movingSpeed * Time.deltaTime);
            //open/close first door
            if (Time.time >= firstDoorCloseTime)
                moveDoor(-direction, door_left_pos_z, door_right_pos_z);
            else
                moveDoor(-direction, -3.2f, 3.35f);
            //open second foor if time reached
            if (Time.time >= secondDoorOpenTime)
                moveDoor(direction, -3.2f, 3.35f);
            //player reach desination
            if (Mathf.Abs(usingDoorPlayer.transform.position.x) >= Mathf.Abs(destination_x))
            {
				//GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().stopPlaying();
                Player.GetComponent<Animator>().Play("Idle");
                usingDoorPlayer.transform.Rotate(0, -(direction * 90), 0);
                entering = false;
                usingDoorPlayer.GetComponent<P_PyramidPosition>().usingdoor = false;
                playerController.GetComponent<P_Movement>().P2Uncontroled = false;
            }
        }
        else {
            //close second door
            moveDoor(direction, door_left_pos_z, door_right_pos_z);
            //moveDoor(-direction, door_left_pos_z, door_right_pos_z);
        }
	}
    public float firstDelayTime = 1.0f;
    public float secondDelayTime = 1.5f;
    private float firstDoorCloseTime;
    private float secondDoorOpenTime;
    void moveDoor(float door,float left_pos, float right_pos) {
        float door_speed = 1f;
        //moving door
        //to z- direction
        if (door == 1) {
            Door_left_1.transform.localPosition = Vector3.MoveTowards(Door_left_1.transform.localPosition,
            new Vector3(Door_left_1.transform.localPosition.x, Door_left_1.transform.localPosition.y, left_pos), door_speed * Time.deltaTime);
            Door_right_1.transform.localPosition = Vector3.MoveTowards(Door_right_1.transform.localPosition,
            new Vector3(Door_right_1.transform.localPosition.x, Door_right_1.transform.localPosition.y, right_pos), door_speed * Time.deltaTime);
        }

        if (door == -1) {
            Door_left_2.transform.localPosition = Vector3.MoveTowards(Door_left_2.transform.localPosition,
            new Vector3(Door_left_2.transform.localPosition.x, Door_left_2.transform.localPosition.y, left_pos), door_speed * Time.deltaTime);
            Door_right_2.transform.localPosition = Vector3.MoveTowards(Door_right_2.transform.localPosition,
                new Vector3(Door_right_2.transform.localPosition.x, Door_right_2.transform.localPosition.y, right_pos), door_speed * Time.deltaTime);

        }
    }

	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			if (other.name == "Player2"){
				intrigger = true;
				if (Time.time > nextInteract){
					if (Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) {
						movePlayer(other);
                    }
                }
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player"){
			intrigger = false;
			TextController.display = false;
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
        playercontroller.GetComponent<P_Movement>().P2Uncontroled = true;
        firstDoorCloseTime = Time.time + firstDelayTime;
        secondDoorOpenTime = Time.time + secondDelayTime;
    }
}