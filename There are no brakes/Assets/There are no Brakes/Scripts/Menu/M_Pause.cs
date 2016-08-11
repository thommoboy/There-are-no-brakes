using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class M_Pause : MonoBehaviour {
    public bool isPause = false;
    Vector3 ori_pos;
    Vector3 destination;
    GameObject[] pauseMenuButtons;
    public GameObject gameOverText;
    // Use this for initialization
    void Start () {
        ori_pos = this.transform.localPosition;
        destination = transform.localPosition;
        destination.y = -17.3f;
    }

    public Camera GUIcamera;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) ) {
            if (isPause)
            {
                this.Continue();

            }
            else {
                isPause = true;
                Time.timeScale = 0;
            }
        }


        if (isPause)
        {
            this.gameObject.SetActive(true);
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, destination, 0.1f);

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = GUIcamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            GameObject hitThing;
            if (Physics.Raycast(ray, out hit, 1000.00f))
            {
                hitThing = hit.collider.gameObject;
                Debug.Log(hitThing.name);
                if (hitThing.tag == "MenuButton")
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (hitThing.name == "Reset") {
                            Reset();
                        }

                        if (hitThing.name == "Exit")
                        {
                            Exit();
                        }

                        if (hitThing.name == "Continue")
                        {
                            Continue();
                        }
                    }
                }

            }
        }
        else {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, ori_pos, 0.1f);
        }
	}

    public void GameOver() {
        gameOverText.SetActive(true);
        isPause = true;
        Time.timeScale = 0;
    }

    void Reset() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    void Continue() {
        Time.timeScale = 1;
        isPause = false;
    }
    void Exit() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
