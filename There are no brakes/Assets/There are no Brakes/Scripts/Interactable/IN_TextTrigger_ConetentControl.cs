/***********************
 * IN_TextTrigger_ConetentControl
 * Originally Written by Xinyu Feng
 * Modified By:
 * 
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_TextTrigger_ConetentControl : MonoBehaviour {

    public string content;
    public bool display;
    public int triggerCount;
	// Use this for initialization
	void Start () {
        display = false;
        triggerCount = 0;
    }

    public Vector3 textBoxSize = new Vector3(350, 100, 50);
    void OnGUI()
    {
        if (display)
        {
            GUI.Box(new Rect((Screen.width - textBoxSize.x) / 2, textBoxSize.z, textBoxSize.x, textBoxSize.y),
                content);
        }
    }
}
