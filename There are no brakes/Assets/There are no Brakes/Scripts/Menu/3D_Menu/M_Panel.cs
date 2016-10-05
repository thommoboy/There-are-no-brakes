using UnityEngine;
using System.Collections;

public class M_Panel : MonoBehaviour
{
    public GameObject firstButton;
    private Vector3 ori_pos;
    private Vector3 down_pos;
    private bool isActive;
    // Use this for initialization
    void Start()
    {
        ori_pos = this.transform.position;
        down_pos = ori_pos;
        down_pos.y = 230;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 0.05f;
        if (isActive)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, down_pos, speed);
        }
        else {
            this.transform.position = Vector3.Lerp(this.transform.position, ori_pos, speed);
        }
    }

    public GameObject getFirstButton()
    {
        return firstButton;
    }

    public void active() {
        this.gameObject.SetActive(true);
        isActive = true;
    }

    public void disactive() {
        isActive = false;
    }
}

    
