using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GC_GameComplete : MonoBehaviour {
    private bool up = false;
    private bool swing = false;
    private Vector3 ori_pos;
    public Vector3 destination;
    private string message = "";
    public Text text;
    public Text rateText;
    private Vector3 text_pos;
    public string[] rateTextInfo;
    public float[] GameRateTimeUsed;
	// Use this for initialization
	void Start () {
        ori_pos = this.transform.position;
        temp = swingSpeed;
        float maxGameTime = (float)new P_HUD().getMaxTime();
        float usedGameTime = maxGameTime - PlayerPrefs.GetFloat("RemainingCloudTime");
        //Debug.Log(maxGameTime + "    " + PlayerPrefs.GetFloat("RemainingCloudTime"));
        //message = "Used Time:        " + usedGameTime + "\n";
		message = message + "Level 1: " + System.Math.Round(PlayerPrefs.GetFloat("Level1Time"),2) + " Seconds \n";
		message = message + "Level 2: " + System.Math.Round(PlayerPrefs.GetFloat("Level2Time"),2) + " Seconds \n";
		message = message + "Level 3: " + System.Math.Round(PlayerPrefs.GetFloat("Level3Time"),2) + " Seconds \n";
		//Debug.Log (usedGameTime);
		usedGameTime = PlayerPrefs.GetFloat ("Level1Time") + PlayerPrefs.GetFloat ("Level2Time") + PlayerPrefs.GetFloat ("Level3Time");
		//Debug.Log (usedGameTime);
        for (int i = GameRateTimeUsed.Length - 1; i >= 0; i--) {
			if (usedGameTime / maxGameTime >= GameRateTimeUsed[i] ) {
                rateMessage = "Game rate:\n          " + rateTextInfo[i];
				//Debug.Log (rateTextInfo [i]);
                break;
            }
        }

        text_pos = text.transform.position;

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            up = true;
        }, 3.0f));

        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            swing = true;
            firstDisplayTime = Time.time;
        }, 3.4f));
    }
    public float swingSpeed;
    float angle = 0.02f;
    float temp;
    // Update is called once per frame
    void Update () {
        if (up) {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, destination, 0.05f);
        }
        if (swing) {
            if (transform.rotation.z <= -angle)
            {
                temp = swingSpeed;
            }
            else if (transform.rotation.z >= angle) {
                temp = -swingSpeed;
            }

            this.transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * temp);
            if (i < message.Length) {
                DisplayText();
            }
        }
        if (rate) {
            //rateText.transform.position = Vector3.Lerp(rateText.transform.position, text_pos, 0.05f);
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                //DisplayRateText();
				btns.SetActive(true);
            }, 1.5f));
        }
        checkClick();

    }
    private float textDelay = 0.1f;
    private float firstDisplayTime;
    private float lastDisplayTime = 0;
    private int i = 0;
    private int j = 0;
    private bool rate = false;
    void DisplayText() {
        if (Time.time > lastDisplayTime + textDelay) {
            text.text = text.text + message[i];
            i++;
            lastDisplayTime = Time.time;
        }
        if (i == message.Length - 1) {
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                rate = true;
            }, 2.0f));
        }
    }
    private string rateMessage;
    public GameObject btns;
    void DisplayRateText() {
        if (Time.time > lastDisplayTime + textDelay)
        {
            rateText.text = rateText.text + rateMessage[j];
            j++;
            lastDisplayTime = Time.time;
        }
        if (j >= rateMessage.Length - 1)
        {
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                btns.SetActive(true);
            }, 1.5f));
        }
    }


    void checkClick() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject hitThing;
        if (Physics.Raycast(ray, out hit, 1000.00f))
        {
            hitThing = hit.collider.gameObject;

            if (hitThing.tag == "MenuButton")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    //Debug.Log(hitThing.name);
                    if (hitThing.name == "CompleteMutton_Quit" || hitThing.name == "GameOverMutton_Quit")
                    {
                        Application.Quit();
                    }
                    if (hitThing.name == "CompleteMutton_Back")
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    }
                }
            }

        }
    }
}
