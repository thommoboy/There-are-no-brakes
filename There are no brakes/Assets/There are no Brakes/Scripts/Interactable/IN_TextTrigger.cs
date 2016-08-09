/***********************
 * IN_TextTrigger.cs
 * Originally Written by Nathan Brown
 * Modified By:
 *  Xinyu Feng
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_TextTrigger : MonoBehaviour {
	public string message1 = "";
	public string message2 = "";
	public string message3 = "";
    private IN_TextTrigger_ConetentControl TextController;
    private bool display = false;

	void Start () {
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
        
    }
	
	void Update () {
	}
	
	void OnTriggerExit(Collider other){
		// Checks for players leaving range
		if (other.tag == "Player") {
            TextController.display = false;
		}
	}
	
	void OnTriggerEnter(Collider other){
		// Checks for players in range
		if (other.tag == "Player") {
            // display message
            TextController.display = true;
            TextController.content = message1 + "\n\n" + message2 + "\n\n" + message3;

        }
	}

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player")
        {
            if (TextController.display == false)
            {
                TextController.display = true;
                TextController.content = message1 + "\n\n" + message2 + "\n\n" + message3;
            }
        }
    }

    /*
	public Vector3 textBoxSize = new Vector3(350,100,50);
	void OnGUI() {
		if(display){
            GUI.Box(new Rect((Screen.width - textBoxSize.x) / 2, textBoxSize.z, textBoxSize.x, textBoxSize.y),
                message1 + "\n\n" + message2 + "\n\n" + message3);
		}
	}
    */

}
