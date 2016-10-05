using UnityEngine;
using System.Collections;

public class M_ContollerSwitch : MonoBehaviour {
    private bool isConfirmed;
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public GameObject arrow;
    public bool isMusicSlider;
    public bool isGrahpicSlider;

    // Use this for initialization
    void Start () {
        isConfirmed = false;
        if (isMusicSlider || isGrahpicSlider)
            setHide(arrow, false);
    }

    // Update is called once per frame
    void Update() {
        float temp = 0.1f;
        float scale = 0.01f;
        if (isMusicSlider && isConfirmed)
        {
            float value = getContollerAxisValue();
            if (value != 0)
            {
                GameObject.Find("SoundEffect").GetComponent<M_MusicVolumeScript>().changeVoiceValue(this.name, value * scale);
            }
        }
        else if (isGrahpicSlider && isConfirmed) {
            float value = getContollerAxisValue();
            if (value != 0) {
                this.GetComponent<M_GraphicSlider>().changeValue(this.transform.parent.gameObject.name,value * scale);
            }  
        }
	}

    private float getContollerAxisValue() {
        float value = Input.GetAxis("L_XAxis_1");
        if (value != 0)
        {
            return value;
        }
        value = Input.GetAxis("L_XAxis_2");
        if (value != 0)
        {
            return value;
        }
        value = Input.GetAxis("L_XAxis_3");
        if (value != 0)
        {
            return value;
        }
        value = Input.GetAxis("L_XAxis_4");
        if (value != 0)
        {
            return value;
        }
        return 0;
    }

    public bool IsConfirmed() {
        return isConfirmed;
    }

    public void switchConfirm() {
        isConfirmed = !isConfirmed;
        arrow.GetComponent<CM_ChooseArrow>().switchLockStatu();
    }

    private void setHide(GameObject temp,bool flag) {
        temp.GetComponent<SpriteRenderer>().enabled = flag;
    }

    public void focusLeave() {
        isConfirmed = false;
        if (this.tag == "MenuButton") {
            this.GetComponent<M_Button>().mouseLeave();
        }
        if (isMusicSlider || isGrahpicSlider) {
            setHide(arrow, false);
            arrow.GetComponent<CM_ChooseArrow>().switchLockStatu();
        }
    }

    public void focusOn() {
        if (this.tag == "MenuButton") {
            this.GetComponent<M_Button>().mouseOver();
        }
        if (isMusicSlider || isGrahpicSlider)
        {
            setHide(arrow, true);
            arrow.GetComponent<CM_ChooseArrow>().switchLockStatu();
        }
    }


    public GameObject Up()
    {
        return up;
    }

    public GameObject Down()
    {
        return down;
    }

    public GameObject Left()
    {
        return left;
    }

    public GameObject Right()
    {
        return right;
    }
}
