using UnityEngine;
using System.Collections;

public class C_Start : MonoBehaviour {
    GameObject switchManager;
    public GameObject[] players;
    public GameObject[] arrows;
    string stage;
	// Use this for initialization
	void Start () {
        switchManager = this.transform.gameObject;
        stage = "";
	}
	
	// Update is called once per frame
	void Update () {

        GameObject[] arrows = switchManager.GetComponent<CM_ArrowSwitch>().arrows;
        if (arrows[0].GetComponent<CM_ChooseArrow>().getLocked()
            && arrows[1].GetComponent<CM_ChooseArrow>().getLocked()
            && arrows[2].GetComponent<CM_ChooseArrow>().getLocked() && stage == "")
        {
            foreach (GameObject ob in arrows) {
                ob.SetActive(false);
            }

            stage = "rotate";
            Debug.Log("rotate");
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                stage = "walk";
                Debug.Log("walk");
            }, 3.5f));

            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                stage = "start";
                //save player choose data
                PlayerPrefs.SetInt("player1choose", arrows[0].GetComponent<CM_ChooseArrow>().getVerticalPos() + 1);
                PlayerPrefs.SetInt("player2choose", arrows[1].GetComponent<CM_ChooseArrow>().getVerticalPos() + 1);
                PlayerPrefs.SetInt("player3choose", arrows[2].GetComponent<CM_ChooseArrow>().getVerticalPos() + 1);

                Debug.Log("player 1 choose" + (PlayerPrefs.GetInt("player1choose")));
                Debug.Log("player 2 choose" + (PlayerPrefs.GetInt("player2choose")));
                Debug.Log("player 3 choose" + (PlayerPrefs.GetInt("player3choose")));


                Application.LoadLevel("Tutorial Level");
            }, 6.0f));
        }

        if (stage == "rotate")
        {
            
            float speed = 50f;
            foreach (GameObject player in players) {
                //Debug.Log(player.transform.rotation.y);
                if (player.transform.rotation.y < 0.99f)
                    player.transform.Rotate(Vector3.down * Time.deltaTime * speed);
            }
        }
        else if (stage == "walk")
        {
            
            float speed = 0.05f;
            foreach (GameObject player in players)
            {
                player.transform.Translate(Vector3.left * speed);
            }
        }
	}

}
