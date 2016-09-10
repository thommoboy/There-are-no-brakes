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
	public string message4 = "";
	public string message5 = "";
    private IN_TextTrigger_ConetentControl TextController;
    private bool display = false;
	private int LineNum;
	public bool forcePause = false;
	public bool importantText = false;

	void Start () {
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
		LineNum = 5;
        if(message5 == ""){LineNum = 4;}
        if(message4 == ""){LineNum = 3;}
        if(message3 == ""){LineNum = 2;}
        if(message2 == ""){LineNum = 1;}
    }
	
	void Update () {
	}
	
	void OnTriggerExit(Collider other){
		// Checks for players leaving range
		if (other.tag == "Player") {
            TextController.display = false;
			TextController.importantTextControl = false;
		}
	}
	
	void OnTriggerEnter(Collider other){
		// Checks for players in range
		if (other.tag == "Player") {
            // display message
            TextController.display = true;
			if (!TextController.importantTextControl) {
				TextController.content = message1 + "\n\n" + message2 + "\n\n" + message3 + "\n\n" + message4 + "\n\n" + message5;
				TextController.lineNum = LineNum;
				if (importantText == true) {
					TextController.importantTextControl = true;
				}
				if (forcePause) {
					TextController.enlarge = true;
					forcePause = false;
				}
			}
        }
	}

    void OnTriggerStay(Collider other) {
		
		if (other.tag == "Player")
        {
//            if (TextController.display == false)
//            {
                TextController.display = true;
				if (!TextController.importantTextControl) {
					TextController.content = message1 + "\n\n" + message2 + "\n\n" + message3 + "\n\n" + message4 + "\n\n" + message5;
					TextController.lineNum = LineNum;
					if (importantText == true) {
						//Debug.Log (other.name);
						TextController.importantTextControl = true;
					}
				}
            //}
        }
    }
}
