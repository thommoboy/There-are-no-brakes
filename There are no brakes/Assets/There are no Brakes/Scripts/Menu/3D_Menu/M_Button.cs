using UnityEngine;
using System.Collections;

public class M_Button : MonoBehaviour {
    private Vector3 ori_scale;
    private Vector3 over_scale;
    private bool isOver;
    


	// Use this for initialization
	void Start () {
        isOver = false;
        ori_scale = this.transform.localScale;
        over_scale = ori_scale * 1.3f;
    }
	
	// Update is called once per frame
	void Update () {
        float speed = 0.1f;
        if (isOver)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, over_scale, speed);
        }
        else {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, ori_scale, speed);
        }

	}

    public GameObject clicked() {
        string buttonName = this.name;
        if (buttonName == "MenuButton_Start")
        {
            GameObject.Find("MenuButton_Start").GetComponent<M_3D_OnMouseOver>().gameStart();
        }
        if (buttonName == "MenuButton_Option")
        {
            GameObject.Find("OptionMenu").GetComponent<M_Panel>().active();
            return GameObject.Find("OptionMenu");
        }
        if (buttonName == "MenuButton_Credits")
        {
            GameObject.Find("CreditsMenu").GetComponent<M_Panel>().active();
            return GameObject.Find("CreditsMenu");
        }
        if (buttonName == "MenuButton_Exit")
        {
            Application.Quit();
        }
        if (buttonName == "Graphcis_Pre")
        {
            GameObject.Find("GraphicMenu").GetComponent<M_GrahpicPanel>().prePage();
        }
        if (buttonName == "Graphcis_Next")
        {
            GameObject.Find("GraphicMenu").GetComponent<M_GrahpicPanel>().nextPage();
        }
        if (buttonName == "Option_graphcis")
        {
            GameObject.Find("GraphicMenu").GetComponent<M_Panel>().active();
            return GameObject.Find("GraphicMenu");
        }
        return this.gameObject;
    }

    public void mouseOver() {
        isOver = true;
    }

    public void mouseLeave() {
        isOver = false;
       // Debug.Log("mouse leave");
    }

    
}
