using UnityEngine;
using System.Collections;

public class M_MenuController : MonoBehaviour {
    private GameObject rightPanel;
    private bool isStart = false;
    float changeTime;
    private GameObject focusObject;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1.0f;
        changeTime = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {
        getRayCast();
        getContollerInput();
        if (isStart) {
            GameObject menuButtons = GameObject.Find("MainMenuButtons");
            menuButtons.transform.position = menuButtons.transform.position + Vector3.left * 10;
        }
        
    }
    
    private void getContollerInput(){
        float temp = 0.7f;
        float gap = 0.5f;
        //down
        if ((Input.GetAxis("L_YAxis_1") > temp || Input.GetAxis("L_YAxis_2") > temp
            || Input.GetAxis("L_YAxis_3") > temp || Input.GetAxis("L_YAxis_4") > temp) && (Time.realtimeSinceStartup > changeTime + gap))
        {
            if (focusObject != null)
            {
                switchFocus(focusObject.GetComponent<M_ContollerSwitch>().Down());
            }
            else {
                switchFocus(GameObject.Find("MenuButton_Start"));
            }
            changeTime = Time.realtimeSinceStartup;
            
        }
        //up
        if ((Input.GetAxis("L_YAxis_1") < -temp || Input.GetAxis("L_YAxis_2") < -temp
            || Input.GetAxis("L_YAxis_3") < -temp || Input.GetAxis("L_YAxis_4") < -temp) && Time.realtimeSinceStartup > changeTime + gap)
        {
            if (focusObject != null)
            {
                switchFocus(focusObject.GetComponent<M_ContollerSwitch>().Up());
            }
            else
            {
                switchFocus(GameObject.Find("MenuButton_Exit"));
            }
            changeTime = Time.realtimeSinceStartup;
        }
        //left
        if ((Input.GetAxis("L_XAxis_1") < -temp || Input.GetAxis("L_XAxis_2") < -temp
            || Input.GetAxis("L_XAxis_3") < -temp || Input.GetAxis("L_XAxis_4") < -temp) && Time.realtimeSinceStartup > changeTime + gap)
        {
            if (focusObject != null)
            {
                if (focusObject.GetComponent<M_ContollerSwitch>().Left() != null )
                    switchFocus(focusObject.GetComponent<M_ContollerSwitch>().Left());
            }
            changeTime = Time.realtimeSinceStartup;
        }
        //right
        if ((Input.GetAxis("L_XAxis_1") > temp || Input.GetAxis("L_XAxis_2") > temp
            || Input.GetAxis("L_XAxis_3") > temp || Input.GetAxis("L_XAxis_4") > temp) && Time.realtimeSinceStartup > changeTime + gap)
        {
            if (focusObject != null)
            {
                if (focusObject.GetComponent<M_ContollerSwitch>().Right() == null && rightPanel != null)
                {
                    if (rightPanel.GetComponent<M_Panel>().firstButton != null)
                        switchFocus( rightPanel.GetComponent<M_Panel>().firstButton);
                }
                else if (focusObject.GetComponent<M_ContollerSwitch>().Right() != null)
                {
                    switchFocus(focusObject.GetComponent<M_ContollerSwitch>().Right());
                }
            }
            changeTime = Time.realtimeSinceStartup;
        }

        //confirm
        if (Input.GetButtonDown("A_1") || Input.GetButtonDown("A_2") || Input.GetButtonDown("A_3") || Input.GetButtonDown("A_4"))
        {
            if (focusObject != null)
            {
                if (focusObject.tag == "MenuButton")
                {
                    clickMenuButton(focusObject);
                }
            }
            if (focusObject != null)
            {
                if (focusObject.GetComponent<M_ContollerSwitch>().isMusicSlider || focusObject.GetComponent<M_ContollerSwitch>().isGrahpicSlider)
                {
                    focusObject.GetComponent<M_ContollerSwitch>().switchConfirm();
                }
            }
            
        }

    }


    void getRayCast() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject hitThing;
        if (Physics.Raycast(ray, out hit, 1000.00f))
        {
            hitThing = hit.collider.gameObject;
            if (hitThing.tag == "MenuButton")
            {
                switchFocus(hitThing);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    clickMenuButton(hitThing);
                }
            }
        }
    }

    void clickMenuButton(GameObject hitThing) {
        GameObject temp = hitThing.GetComponent<M_Button>().clicked();
        if (temp.name == "GraphicMenu") {
            focusObject = null;
        }
        if (temp.tag == "Weight")
        {
            if (rightPanel != null)
            {
                //Debug.Log(rightPanel.name + "####" + temp.name);
                rightPanel.GetComponent<M_Panel>().disactive();
                if (rightPanel == temp)
                {
                    rightPanel = null;
                    
                   // focusObject = null;
                }
                else
                {
                    rightPanel = temp;
                }
            }
            else
            {
                rightPanel = temp;
            }
        }
    }

    void switchFocus(GameObject currentFocus) { 
        if (focusObject != null) {
            if (focusObject.GetComponent<M_ContollerSwitch>().IsConfirmed())
                return;
            focusObject.GetComponent<M_ContollerSwitch>().focusLeave();
        }
        focusObject = currentFocus;
        focusObject.GetComponent<M_ContollerSwitch>().focusOn();

    }

    public void gameStart() {
		if (rightPanel!= null)
       	 	rightPanel.GetComponent<M_Panel>().disactive();
        isStart = true;
    }
}
