/***********************
 * M_Pause.cs
 * Originally Written by Xinyu Feng
 * Modified By:
	Nathan Brown: Controller support
 ***********************/
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class M_Pause : MonoBehaviour {
    public bool isPause = false;
    Vector3 ori_pos;
    public Vector3 destination;
    public GameObject optionPanel;
    public GameObject gameOverPanel;
   //public GameObject gameOverText;
    public Camera GUIcamera;
    public GameObject[] buttonList;
    private string current_panel;
    private bool gameover = false;
	private bool controllerinput = false;
    private int mouseOver = -1;
    private Vector3 ori_scale;
    private Vector3 select_scale;
	
    // Use this for initialization
    void Start () {
        ori_pos = this.transform.localPosition;
        ori_scale = buttonList[0].transform.localScale;
        select_scale = ori_scale * 1.3f;
        current_panel = "";
        //destination = transform.localPosition;
    }


    
	// Update is called once per frame
	void Update () {
        
        if (!gameover && (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start_1") || Input.GetButtonDown("Start_2") || Input.GetButtonDown("Start_3"))) {
            if (isPause)
            {
                isPause = false;
                current_panel = "";
                this.Continue();
            }
            else {
                isPause = true;
                current_panel = "pause";
                Time.timeScale = 0;
            }
        }

        //get controller input
		if (isPause){

			controllerInput();
		}
        

        //check current panel
        if (current_panel == "pause")
            DownToScreen(this.gameObject);
        else
            UpToOffScreen(this.gameObject);

        if (current_panel == "option")
            Option();
        else
            UpToOffScreen(optionPanel);

        if (current_panel == "gameOver")
            DownToScreen(gameOverPanel);
        else
            UpToOffScreen(gameOverPanel);
        //get mouse click
        if (true)
        {
            //this.gameObject.SetActive(true);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = GUIcamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            GameObject hitThing;
            if (Physics.Raycast(ray, out hit, 1000.00f))
            {
                hitThing = hit.collider.gameObject;

                for (int i = 0; i < buttonList.Length; i++) {
                    if (hitThing == buttonList[i]) {
                        mouseOver = i;
                        break;
                    }
                }

                if (hitThing.tag == "MenuButton")
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log(hitThing.name);
                        clickButton(hitThing.name);
                    }
                }
            }
        }

        for (int i = 0; i < buttonList.Length; i++) {
            if (mouseOver == i)
            {
                buttonList[i].transform.localScale = Vector3.Lerp(buttonList[i].transform.localScale, select_scale, 0.1f);
            }
            else {
                buttonList[i].transform.localScale = Vector3.Lerp(buttonList[i].transform.localScale, ori_scale, 0.1f);
            }
        }
	}

    private void clickButton(string buttonName) {

        if (buttonName == "PauseMutton_Option")
        {
            current_panel = "option";
        }
        if (buttonName == "PauseMutton_Quit" || buttonName == "GameOverMutton_Quit")
        {
            Exit();
        }
        if (buttonName == "PauseMutton_Back")
        {
            Continue();
        }
        if (buttonName == "PauseMutton_Restart")
        {
            Time.timeScale = 1;
            Application.LoadLevel(Application.loadedLevel);
        }
        if (buttonName == "OptionMutton_Back")
        {
            current_panel = "pause";
        }
        if (buttonName == "GameOverMutton_Back")
        {
            //Application.LoadLevel(0);
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
    private float changeTime;
    private float gap = 0.5f;
    private void controllerInput() {
        float temp = 0.7f;
        if (Input.GetAxis("L_YAxis_1") > temp || Input.GetAxis("L_YAxis_2") > temp
            || Input.GetAxis("L_YAxis_3") > temp || Input.GetAxis("L_YAxis_4") > temp )
        {
            if (Time.realtimeSinceStartup > changeTime + gap) {
                mouseOver = (mouseOver + 1) % buttonList.Length;
                //Debug.Log((changeTime + gap) + "   " + Time.realtimeSinceStartup);
                changeTime = Time.realtimeSinceStartup;
            }
            
        }

        if (Input.GetAxis("L_YAxis_1") < -temp || Input.GetAxis("L_YAxis_2") < -temp
            || Input.GetAxis("L_YAxis_3") < -temp || Input.GetAxis("L_YAxis_4") < -temp)
        {
            if (mouseOver != -1 && Time.realtimeSinceStartup > changeTime + gap)
            {
                mouseOver = (mouseOver - 1) % buttonList.Length;
                changeTime = Time.realtimeSinceStartup;
            }
        }

        if (Input.GetButtonDown("A_1") || Input.GetButtonDown("A_2") || Input.GetButtonDown("A_3") || Input.GetButtonDown("A_4"))
        {
            clickButton(buttonList[mouseOver].name);
            mouseOver = -1;
        }

        if (Input.GetButtonDown("B_1") || Input.GetButtonDown("B_2") || Input.GetButtonDown("B_3") || Input.GetButtonDown("B_4"))
        {
            clickButton("PauseMutton_Back");
            mouseOver = -1;
        }

    }

    public void GameOver() {
        current_panel = "gameOver";
        gameover = true;
        //should pause game when game over?
        
        //isPause = true;
        Time.timeScale = 0;
        
    }

    public bool IsGameOver() {
        return gameover;
    }

    void Option() {
        DownToScreen(optionPanel);
       /* StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            DownToScreen(optionPanel);
        }, 1.0f));*/

    }
    void Continue() {
        Time.timeScale = 1;
        isPause = false;
        current_panel = "";
    }

    void DownToScreen(GameObject obj) {
        obj.transform.localPosition = Vector3.Lerp(obj.transform.localPosition, destination, 0.1f);
    }

    void UpToOffScreen(GameObject obj) {
        obj.transform.localPosition = Vector3.Lerp(obj.transform.localPosition, ori_pos, 0.1f);
    }

    void Exit() {
        Application.Quit();
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

public class DelayToInvoke : MonoBehaviour
{

    public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
}
