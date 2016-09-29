/***********************
 * M_3DMenuButton.cs
 * Originally Written by Xinyu Feng
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class M_3DMenuButton : MonoBehaviour {
    public GameObject[] MenuButtonList;
	public GameObject[] MenuList;
	private int[] MenuMoveStatu;
    private Vector3[] buttons_ori_scale;
    private int[] sizeStatu;
    private float resizeSpeed = 1.03f;
    private int focusedButtonIndex = -1;
	private Vector3 menu_ori_position;
	bool right_menu = false;
	float menuMoveSpeed  = 20;
	public bool started = false;
    private int controllerSelected = -1;
	
	private AudioClip MenuSwitch;
    // Use this for initialization

	void removeAllUI(){
		for (int i = 0; i < MenuList.Length; i++) {
			if (MenuList [i].transform.position.y < 600) {
				MenuMoveStatu [i] = 2;
				break;
			}
		}
		GameObject menuButtons = GameObject.Find ("MainMenuButtons");
		menuButtons.transform.position = menuButtons.transform.position + Vector3.left * menuMoveSpeed/2;

	}

    void Start () {
		MenuSwitch = Resources.Load("Sounds/MenuSwitch") as AudioClip;
		//init menu movement statu and button size statu
		//0: stay
		//1: go up / being bigger
		//-1: go down // being smaller
		//2: go up until not in screen
		MenuMoveStatu = new int[MenuList.Length];
		for (int i = 0; i < MenuMoveStatu.Length; i++) {
			MenuMoveStatu[i] = 0;
        }
		sizeStatu = new int[MenuButtonList.Length];
        buttons_ori_scale = new Vector3[MenuButtonList.Length];

        for (int i = 0; i < sizeStatu.Length; i++) {
			sizeStatu[i] = 0;
            buttons_ori_scale[i] = MenuButtonList[i].transform.localScale;
        }

		menu_ori_position = MenuList [0].transform.position;
        
		lastButton = GameObject.Find ("Cube");
	}
    float changeTime;
    // Update is called once per frame
    void FixedUpdate () {
		
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		GameObject hitThing;

        for (int i = 0; i < MenuButtonList.Length; i++)
        {
            if (controllerSelected != i) {
                sizeStatu[i] = -1;
            }
        }
        /*
            if (focusedButtonIndex != -1) {
			sizeStatu [focusedButtonIndex] = -1;
		}*/

		if (Physics.Raycast (ray, out hit, 1000.00f)) {
			hitThing = hit.collider.gameObject;
			if (hitThing.tag == "MenuButton") {
				ButtonOnSelected (hitThing);

                for (int i = 0; i < MenuButtonList.Length; i++) {
                    if (hitThing == MenuButtonList[i]) {
                        controllerSelected = i;
                        break;
                    }
                }

				if (Input.GetKeyDown (KeyCode.Mouse0)) {
					onClick (hitThing.name);
				}
			}
		}
		if (started) {
			removeAllUI ();
		}
        float temp = 0.7f;
        float gap = 0.5f;
        if (Input.GetAxis("L_YAxis_1") > temp || Input.GetAxis("L_YAxis_2") > temp
            || Input.GetAxis("L_YAxis_3") > temp || Input.GetAxis("L_YAxis_4") > temp)
        {
            
            if (Time.realtimeSinceStartup > changeTime + gap) {
                //Debug.Log(Time.realtimeSinceStartup + "   " + (changeTime + gap));
                controllerSelected = (controllerSelected + 1) % 4;
                changeTime = Time.realtimeSinceStartup;
                ButtonOnSelected(MenuButtonList[controllerSelected]);
				M_AudioManager.PlayAudioSelf(MenuSwitch);
            }
                
        }

        if (Input.GetAxis("L_YAxis_1") < -temp || Input.GetAxis("L_YAxis_2") < -temp
            || Input.GetAxis("L_YAxis_3") < -temp || Input.GetAxis("L_YAxis_4") < -temp)
        {
            if (controllerSelected != -1 && Time.realtimeSinceStartup > changeTime + gap) {
                controllerSelected = (controllerSelected - 1) % 4;
                changeTime = Time.realtimeSinceStartup;
                ButtonOnSelected(MenuButtonList[controllerSelected]);
                M_AudioManager.PlayAudioSelf(MenuSwitch);
            }
        }

        if (Input.GetButtonDown("A_1") || Input.GetButtonDown("A_2") || Input.GetButtonDown("A_3") || Input.GetButtonDown("A_4"))
        {
            if (controllerSelected != -1)
            {
                onClick(MenuButtonList[controllerSelected].name);
            }
            
        }

        updateButton ();
		updateMenu ();
    }

	void updateMenu(){
		for (int i = 0; i < MenuList.Length; i++) {
			if (MenuMoveStatu [i] == 1) {
                MenuList[i].transform.position = MenuList[i].transform.position + Vector3.up * menuMoveSpeed ;
				if (MenuList [i].transform.position.y > 250) {
					MenuMoveStatu [i] = 0;
				}
			}

			if (MenuMoveStatu [i] == -1) {
                MenuList[i].active = true;
                MenuList[i].transform.position = MenuList[i].transform.position - Vector3.up * menuMoveSpeed;
				if (MenuList [i].transform.position.y < 170) {
					MenuMoveStatu [i] = 1;
				}
			}

			if (MenuMoveStatu [i] == 2) {
                MenuList[i].transform.position = MenuList[i].transform.position + Vector3.up * menuMoveSpeed;
				if (MenuList [i].transform.position.y > 700) {
					MenuMoveStatu [i] = 1;
				}
			}
		}
	}

	void onClick(string buttonName){
		if (buttonName == "MenuButton_Start") {
            GameObject.Find("MenuButton_Start").GetComponent<M_3D_OnMouseOver>().gameStart();
		}
		if (buttonName == "MenuButton_Option") {
			updateMenuStatu (1);
		}
		if (buttonName == "MenuButton_Credits") {
			updateMenuStatu (2);
		}
		if (buttonName == "MenuButton_Exit") {
			Application.Quit ();
		}
        if (buttonName == "Graphcis_Pre") {
            GameObject.Find("GraphicMenu").GetComponent<M_GrahpicPanel>().prePage();
        }
        if (buttonName == "Graphcis_Next")
        {
            GameObject.Find("GraphicMenu").GetComponent<M_GrahpicPanel>().nextPage();
        }
        if (buttonName == "Option_graphcis") {
            updateMenuStatu(3);
        }
    }

	void updateMenuStatu(int menuIndex){
		if ( MenuMoveStatu[menuIndex] != 0) {
			return;
		}
		if (MenuList [menuIndex].transform.position.y < 700) {
			MenuMoveStatu [menuIndex] = 2;
			right_menu = false;;
			return;
		}

		MenuMoveStatu [menuIndex] = -1;
        //让当前menu延迟下降
		if (right_menu) {
			MenuList [menuIndex].transform.position = MenuList [menuIndex].transform.position + Vector3.up * 450;
		}

		if (right_menu) {
			for (int i = 0; i < MenuList.Length; i++) {
				if (i == menuIndex)
                {
                    continue;
                }
					
				if (MenuList [i].transform.position.y < 600) {
					MenuMoveStatu [i] = 2;
					break;
				}
			}
		}
		right_menu = true;
	}


	void updateButton(){
		for (int i = 0; i < MenuButtonList.Length; i++)
		{
			if (sizeStatu[i] == 1)
			{
                if (MenuButtonList[i].transform.localScale.x < buttons_ori_scale[i].x * 1.3)
				{
					MenuButtonList[i].transform.localScale = MenuButtonList[i].transform.localScale * resizeSpeed;
				}
				else { sizeStatu[i] = 0;  }
			}

			if (sizeStatu[i] == -1){
                if (MenuButtonList[i].transform.localScale.x > buttons_ori_scale[i].x)
				{
					MenuButtonList[i].transform.localScale = MenuButtonList[i].transform.localScale * (1/resizeSpeed);
				}
				else { sizeStatu[i] = 0;  }
			}
		}
	}

	private GameObject lastButton;

    void ButtonOnSelected(GameObject button) {

        for (int i = 0; i < MenuButtonList.Length; i++)
        {
            if (MenuButtonList[i] == button) {
				//button_ori_scale = button.transform.localScale;
                focusedButtonIndex = i;
				if (sizeStatu[i] != 0 && sizeStatu[i] != 1 && (button.name != lastButton.name)) {
					//Debug.Log (1 + " " + lastButton.name + "   " + button.name);
                    M_AudioManager.PlayAudioSelf(MenuSwitch);
					lastButton = button;
					//Debug.Log (2 + " " + lastButton.name + "   " + button.name);
                }
                sizeStatu[i] = 1;
            }
        }
    }

    void MouseOnOver(GameObject overButton) {
        
    }
		
}
