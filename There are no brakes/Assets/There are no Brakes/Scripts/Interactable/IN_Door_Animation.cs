/***********************
 * M_Pause.cs
 * Originally Written by Xinyu Feng
 * This Script only work on Tutorial Level. 24/08/2016
 * Modified By:
	
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Door_Animation : MonoBehaviour {
    //public IN_Group_Checkpoint checkPoint;
    public GameObject door_0;
    //public GameObject door_1;

    //public Vector3 door_0_open_position;
    //public Vector3 door_1_open_position;

    private Vector3 door_0_ori_position;
    //private Vector3 door_1_ori_position;

    private float speed = 0.03f;

    public enum Deriction {x_inc,y_inc,z_inc,x_dec,y_dec,z_dec};
    public Deriction open_deriction;
    //turn on this float if use two doors
    //private float two_doors_delay;
    private float door_close_delay = 10f;
    public float distance;

    private Vector3 basic_move_unit;

    private string door_0_statu;
    private string door_1_statu;

    // Use this for initialization
    void Start () {
        door_0_ori_position = door_0.transform.localPosition;
        //door_1_ori_position = door_1.transform.localPosition;

        switch (open_deriction) {
            case Deriction.x_inc:
                basic_move_unit = new Vector3(1, 0, 0);
                break;
            case Deriction.x_dec:
                basic_move_unit = new Vector3(-1, 0, 0);
                break;
            case Deriction.y_inc:
                basic_move_unit = new Vector3(0, 1, 0);
                break;
            case Deriction.y_dec:
                basic_move_unit = new Vector3(0, -1, 0);
                break;
            case Deriction.z_inc:
                basic_move_unit = new Vector3(0, 0, 1);
                break;
            case Deriction.z_dec:
                basic_move_unit = new Vector3(0, 0, -1);
                break;
        }



    }
	
	// Update is called once per frame
	void Update () {
        if (door_0_statu == "opening") {
            Move_door(0, "opening");
        }
        if (door_0_statu == "closing")
        {
            Move_door(0, "closing");
        }
        /*
         * Should I control two door in one script?
        if (door_1_statu == "opening")
        {
            Move_door(1, "opening");
        }
        if (door_1_statu == "closing")
        {
            Move_door(1, "closing");
        }
        */

    }

    public void Open_door(int first_door_index) {
        door_0_statu = "opening";
        /*
         * not sure should open another door?
        //open other door after delay
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            door_1_statu = "opening";
        }, two_doors_delay));
        */

        
        // Shoud I close door after delay?
        //close this door after delay, close another door after.
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Close_door(first_door_index);
        }, door_close_delay));
        
    }

    public void Close_door(int first_door_index)
    {
        door_0_statu = "closing";
        /*
         * same as above
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            door_1_statu = "closing";
        }, two_doors_delay));
        */
    }

    void Move_door(int door_index, string statu) {
        GameObject door = door_0;
        Vector3 destination = door_0_ori_position;

        if (door_index == 0)
        {
            door = door_0;
            if (statu == "opening")
               destination = door_0_ori_position + basic_move_unit * distance;
            else if (statu == "closing")
               destination = door_0_ori_position ;
        }
        /*
        else
        {
            door = door_1;
            if (statu == "opening")
                destination = door_1_ori_position + basic_move_unit * distance;
            else if (statu == "closing")
                destination = door_1_ori_position ;
        }
        */
        door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, destination, speed);
    }
}

