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
    private string current_panel;
    private bool gameover = false;
    // Use this for initialization
    void Start () {
        ori_pos = this.transform.localPosition;
        current_panel = "";
        //destination = transform.localPosition;
    }


    
	// Update is called once per frame
	void Update () {
        //right click to test game over
        //mid lick to text game complete
        
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            GameOver();
        }

        if (Input.GetMouseButtonDown(2)){
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && !gameover ) {
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
                
                if (hitThing.tag == "MenuButton")
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log(hitThing.name);
                        if (hitThing.name == "PauseMutton_Option") {
                            current_panel = "option";
                        }
                        if (hitThing.name == "PauseMutton_Quit" || hitThing.name == "GameOverMutton_Quit")
                        {
                            Exit();
                        }
                        if (hitThing.name == "PauseMutton_Back")
                        {
                            Continue();
                        }
                        if (hitThing.name == "OptionMutton_Back") {
                            current_panel = "pause";
                        }
                        if (hitThing.name == "GameOverMutton_Back") {
                            //Application.LoadLevel(0);
                            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                        }
                    }
                }

            }
        }
	}
    
    public void GameOver() {
        current_panel = "gameOver";
        gameover = true;
        //should pause game when game over?
        /*
        isPause = true;
        Time.timeScale = 0;
        */
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
