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
		normalFontSize = Mathf.Min(Mathf.FloorToInt(Screen.width * FontSize/1000), Mathf.FloorToInt(Screen.height * FontSize/1000));
    }

    public Vector3 textBoxSize = new Vector3(600, 100, 100);
    public Vector3 enlargetextBoxSize;
    void Update(){
		height = Mathf.FloorToInt(lineNum * normalFontSize * 2.5f);
	}

    int FontSize = 30;
    int normalFontSize = 30;
    void OnGUI()
    {
		normalFontSize = Mathf.Min(Mathf.FloorToInt(Screen.width * FontSize/1000), Mathf.FloorToInt(Screen.height * FontSize/1000));
        if (display && !pause.isPause && !pause.IsGameOver())
        {
            if (!enlarge)
            {
                customGuiStyle = new GUIStyle(GUI.skin.box);
                customGuiStyle.padding = new RectOffset(4,4,Mathf.FloorToInt(0.8f*normalFontSize),4);
                customGuiStyle.normal.textColor = Color.white;
                customGuiStyle.fontSize = normalFontSize;
                GUI.Box(new Rect(0, Screen.height - height, Screen.width, height), content, customGuiStyle);
            }
            else {
                buttonRect = new Rect((Screen.width - buttonWidth) / 2, enlargetextBoxSize.z + height * enlargeScale*100 , buttonWidth,buttonHeight);
                Time.timeScale = 0;
                customGuiStyle = new GUIStyle(GUI.skin.box);
                customGuiStyle.normal.textColor = Color.white;
                customGuiStyle.fontSize = (int)(normalFontSize * enlargeScale);
                GUI.Box(new Rect(0, Screen.height - height, Screen.width, height * enlargeScale), 
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
