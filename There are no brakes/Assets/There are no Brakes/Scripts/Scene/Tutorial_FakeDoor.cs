/***********************
 * Tutorial_FakeDoor.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class Tutorial_FakeDoor : MonoBehaviour {
	private float timeout = 0.5F;
	private float nextInteract = 0.0F;
	public GameObject teleportTarget;
    private IN_TextTrigger_ConetentControl TextController;
    public GameObject door_0_left;
    public GameObject door_0_right;
    public GameObject door_1_left;
    public GameObject door_1_right;

    private Vector3 ori_1_left;
    private Vector3 ori_1_right;

    public Vector3 point_1;
    public Vector3 point_2;
    public float speed;
    public float door_speed;

    private string stage = "";
    private float distance = 2.0f;

	void Start(){
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
        ori_1_left = door_1_left.transform.position;
        ori_1_right = door_1_right.transform.position;

    }
	
	void Update(){
		if(intrigger){
			TextController.display = true;
			TextController.content = "Press [Interact] to use";
		}

        if (stage == "point1") {
            GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P2Uncontroled = true;
            
            player.transform.position = Vector3.MoveTowards(player.transform.position, point_1, speed * Time.deltaTime);

            door_0_left.transform.position = Vector3.Lerp(door_0_left.transform.position, destination_left, door_speed);
            door_0_right.transform.position = Vector3.Lerp(door_0_right.transform.position, destination_right, door_speed);
        }

        if (stage == "point2")
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, point_2, speed/2 * Time.deltaTime);
            door_0_left.transform.position = Vector3.Lerp(door_0_left.transform.position, destination_left, door_speed);
            door_0_right.transform.position = Vector3.Lerp(door_0_right.transform.position, destination_right, door_speed);
        }

        if (stage == "teleportTarget")
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, teleportTarget.transform.position, speed * Time.deltaTime);
            door_1_left.transform.position = Vector3.Lerp(door_1_left.transform.position, destination_left, door_speed);
            door_1_right.transform.position = Vector3.Lerp(door_1_right.transform.position, destination_right, door_speed);
            if (player.transform.position.x >= teleportTarget.transform.position.x ||
                player.transform.localPosition.x >= -1.41)
            {
                stage = "closing";
                destination_left = door_1_left.transform.position - Vector3.back * distance;
                destination_right = door_1_right.transform.position - Vector3.forward * distance;
                GameObject.Find("PlayerControllers").GetComponent<P_Movement>().P2Uncontroled = false;
            }
        }

        if (stage == "closing") {
            //Debug.Log("closing");
            door_1_left.transform.position = Vector3.Lerp(door_1_left.transform.position, ori_1_left, door_speed);
            door_1_right.transform.position = Vector3.Lerp(door_1_right.transform.position, ori_1_right, door_speed);
            if (door_1_right.transform.position.z - ori_1_right.z <= 0.01f) {
                stage = "";
                //Debug.Log("finish");
            }
        }

    }
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			if (other.name == "Player2"){
				intrigger = true;
				if(Time.time > nextInteract && stage!= "closing"){
					if (Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) {
						movePlayer(other);
					}
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			if (other.name == "Player2"){
				nextInteract = Time.time + timeout;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player"){
			intrigger = false;
			TextController.display = false;
		}
	}
    private GameObject player;
    private Vector3 destination_left;
    private Vector3 destination_right;
    void movePlayer(Collider other){
		//make player drop anything theyre carrying before going through door
		other.transform.FindChild("Player").gameObject.GetComponent<P_PickUp>().DropObject(true);
        player = other.gameObject;
        //other.transform.position = teleportTarget.transform.position;
        //move to point 1

        destination_left = door_0_left.transform.position + Vector3.back * distance;
        destination_right = door_0_right.transform.position + Vector3.forward * distance;
        //Debug.Log("point1");
        stage = "point1";

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            //Debug.Log("point2");
            stage = "point2";
            destination_left = door_0_left.transform.position - Vector3.back * distance;
            destination_right = door_0_right.transform.position - Vector3.forward * distance;
        }, 1.5f));

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
           // Debug.Log("teleportTarget");
            destination_left = door_1_left.transform.position + Vector3.back * distance;
            destination_right = door_1_right.transform.position + Vector3.forward * distance;
            stage = "teleportTarget";
        }, 2.5f));
        /*
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            destination_left = door_1_left.transform.position - Vector3.back * distance;
            destination_right = door_1_right.transform.position - Vector3.forward * distance;
            stage = "closing";
        }, 6.0f));
        */
    }
}