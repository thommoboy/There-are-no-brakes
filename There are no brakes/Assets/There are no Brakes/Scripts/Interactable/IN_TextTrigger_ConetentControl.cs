/***********************
 * IN_TextTrigger_ConetentControl
 * Originally Written by Xinyu Feng
 * Modified By:
 * 		Nathan Brown - changed position, added adjustable sizing
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_TextTrigger_ConetentControl : MonoBehaviour {

    public string content;
    public bool display;
    public int triggerCount;
	public int lineNum = 1;
	private int linespace = 30;
	private int height;
    public M_Pause pause;
    GUIStyle customGuiStyle;
    int tail = -1;
    string[] messages;
    int[] linesNum;
    public bool enlarge = false;
    ArrayList msgRecord = new ArrayList();
    int buttonWidth = 50;
    int buttonHeight = 50;
    Rect buttonRect;
    public float enlargeScale = 1.3f;
    // Use this for initialization
    void Start () {
        display = false;
        triggerCount = 0;
        messages = new string[10];
        linesNum = new int[10];
        enlargetextBoxSize = textBoxSize * enlargeScale;
    }

    public Vector3 textBoxSize = new Vector3(350, 100, 50);
    public Vector3 enlargetextBoxSize;
    void Update(){
		switch (lineNum){
			case 1:
				height = (int)textBoxSize.y - (2*linespace);
				break;
			case 2:
				height = (int)textBoxSize.y - linespace;
				break;
			case 3:
				height = (int)textBoxSize.y;
				break;
			case 4:
				height = (int)textBoxSize.y + linespace;
				break;
			default:
				height = (int)textBoxSize.y + (2*linespace);
				break;
		}
	}

    int normalFontSize = 16;
    void OnGUI()
    {
        if (display && !pause.isPause && !pause.IsGameOver())
        {
            if (!enlarge)
            {
                customGuiStyle = new GUIStyle(GUI.skin.box);
                customGuiStyle.normal.textColor = Color.white;
                customGuiStyle.fontSize = normalFontSize;
                GUI.Box(new Rect((Screen.width - textBoxSize.x) / 2, textBoxSize.z, textBoxSize.x, height), content, customGuiStyle);
            }
            else {
                buttonRect = new Rect((Screen.width - buttonWidth) / 2, enlargetextBoxSize.z + height * enlargeScale , buttonWidth,buttonHeight);
                Time.timeScale = 0;
                customGuiStyle = new GUIStyle(GUI.skin.box);
                customGuiStyle.normal.textColor = Color.white;
                customGuiStyle.fontSize = (int)(normalFontSize * enlargeScale);
                GUI.Box(new Rect((Screen.width - enlargetextBoxSize.x) / 2, enlargetextBoxSize.z, enlargetextBoxSize.x, height * enlargeScale), 
                    content, 
                    customGuiStyle);
                if (GUI.Button(buttonRect, "OK")) {
                    Time.timeScale = 1;
                    enlarge = false;
                }
                if (Input.GetKey(KeyCode.Return)) {
                    Time.timeScale = 1;
                    enlarge = false;
                }
            }
        }
    }
    
    /// <summary>
    /// add message in display queue with line number.
    /// </summary>
    /// <param name="msg"> message content that going to add in display queue. </param>
    /// <param name="lines"> line numbers of the message. </param>
    public void Display(string msg,int lines){
        if (msgRecord.IndexOf(msg) != -1)
        {
            msgRecord.Add(msg);
        }
        else if (tail>=0){
            enlarge = true;
        }
        tail += 1;
        messages[tail] = msg;
        linesNum[tail] = lines;
        content = msg;
        display = true;
    }

    /// <summary>
    /// delete message from display queue
    /// </summary>
    /// <param name="msg"> the message that going to be deleted in display queue. </param>
    public void cancelDisplay(string msg) {
        for (int i = 0; i <= tail; i++) {
            if (messages[i] == msg) {
                for (int j = i; j < tail; j++) {
                    messages[j] = messages[j + 1];
                    linesNum[j] = linesNum[j + 1];
                }
                tail -= 1;
                break;
            }
        }

        if (tail == -1)
        {
            display = false;
        }
        else {
            content = messages[tail];
        }
    }
}
