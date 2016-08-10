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
    private Vector3 button_ori_scale;
    private int[] sizeStatu;
    private float resizeSpeed = 1.03f;
    private int focusedButtonIndex = -1;
	private Vector3 menu_ori_position;
	bool right_menu = false;
	float menuMoveSpeed  = 20;
	public bool started = false;
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
		for (int i = 0; i < sizeStatu.Length; i++) {
			sizeStatu[i] = 0;
		}

		menu_ori_position = MenuList [0].transform.position;
        button_ori_scale = MenuButtonList[0].transform.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		GameObject hitThing;
		if (focusedButtonIndex != -1) {
			sizeStatu [focusedButtonIndex] = -1;
		}
		if (Physics.Raycast (ray, out hit, 1000.00f)) {
			hitThing = hit.collider.gameObject;
			if (hitThing.tag == "MenuButton") {
				ButtonOnSelected (hitThing);
				if (Input.GetKeyDown (KeyCode.Mouse0)) {
					onClick (hitThing.name);
				}
			}

		}
		if (started) {
			removeAllUI ();
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
			//updateMenuStatu (0);
		}
		if (buttonName == "MenuButton_Option") {
			updateMenuStatu (1);
		}
		if (buttonName == "MenuButton_Credits") {
			updateMenuStatu (2);
		}
		if (buttonName == "new_game") {
			updateMenuStatu (3);
		}
		if (buttonName == "MenuButton_Exit") {
			Application.Quit ();
		}
	}

	void updateMenuStatu(int menuIndex){
		if (MenuList [menuIndex].transform.position.y < 700 || MenuMoveStatu[menuIndex] != 0) {
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
			if (MenuButtonList [i].name == "new_game")
				continue;
			if (sizeStatu[i] == 1)
			{
                if (MenuButtonList[i].transform.localScale.x < button_ori_scale.x * 1.3)
				{
					MenuButtonList[i].transform.localScale = MenuButtonList[i].transform.localScale * resizeSpeed;
				}
				else { sizeStatu[i] = 0;  }
			}

			if (sizeStatu[i] == -1){
                if (MenuButtonList[i].transform.localScale.x > button_ori_scale.x)
				{
					MenuButtonList[i].transform.localScale = MenuButtonList[i].transform.localScale * (1/resizeSpeed);
				}
				else { sizeStatu[i] = 0;  }
			}
		}
	}

    void ButtonOnSelected(GameObject button) {

        for (int i = 0; i < MenuButtonList.Length; i++)
        {
            if (MenuButtonList[i] == button) {
				//button_ori_scale = button.transform.localScale;
                focusedButtonIndex = i;
                sizeStatu[i] = 1;
            }
        }
    }

    void MouseOnOver(GameObject overButton) {
        
    }
		
}
