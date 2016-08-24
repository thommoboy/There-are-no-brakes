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
	// Use this for initialization
	void Start () {
        display = false;
        triggerCount = 0;
    }

    public Vector3 textBoxSize = new Vector3(350, 100, 50);
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
	
    void OnGUI()
    {
        if (display && !pause.isPause)
        {
            customGuiStyle = new GUIStyle(GUI.skin.box);
            customGuiStyle.normal.textColor = Color.white;
            GUI.Box(new Rect((Screen.width - textBoxSize.x) / 2, textBoxSize.z, textBoxSize.x, height ), content, customGuiStyle);
        }
    }
}
