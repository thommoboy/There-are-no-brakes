using UnityEngine;
using System.Collections;

public class CM_ArrowSwitch : MonoBehaviour {
    public GameObject[] arrows;
    private ArrayList[] arrowsMap;
    private bool[] isPlayerChoosen;
    private int[] playerChoise;
    private float horizontalGap = 8.0f;
    private float verticalGap = 3.0f;
    private float minYPos;
    const int maxRow = 3;
	// Use this for initialization
	void Start () {
        isPlayerChoosen = new bool[maxRow];
        playerChoise = new int[maxRow];
        horizontalGap = GameObject.Find("Player2").transform.position.x - GameObject.Find("Player1").transform.position.x + 0.2f;
        //Debug.Log(horizontalGap);
        minYPos = arrows[0].transform.position.y;
        arrowsMap = new ArrayList[maxRow] { new ArrayList(), new ArrayList(), new ArrayList()};
        for (int i = 0; i < arrows.Length; i++) {
            arrowsMap[0].Add(arrows[i]);
            isPlayerChoosen[i] = false;
            playerChoise[i] = -1;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        int controllingIndex = getLeftButton();
        if (controllingIndex != -1) {
            int row = arrows[controllingIndex].GetComponent<CM_ChooseArrow>().getVerticalPos();
            changeRow(controllingIndex, (row - 1 + maxRow) % maxRow);
            return;
        }

        controllingIndex = getRightButton();
        if (controllingIndex != -1)
        {
            int row = arrows[controllingIndex].GetComponent<CM_ChooseArrow>().getVerticalPos();
            changeRow(controllingIndex, (row + 1) % maxRow);
            return;
        }

        controllingIndex = getConfirmButton();
        if (controllingIndex != -1)
        {
            int row = arrows[controllingIndex].GetComponent<CM_ChooseArrow>().getVerticalPos();
            if (!isPlayerChoosen[row])
            {
                toMapFirst(controllingIndex);
                arrows[controllingIndex].GetComponent<CM_ChooseArrow>().switchLockStatu();
                playerChoise[controllingIndex] = row;
                isPlayerChoosen[row] = true;
                checkAll();
            }
            else {
                if (playerChoise[controllingIndex] == row) {
                    isPlayerChoosen[row] = false;
                    arrows[controllingIndex].GetComponent<CM_ChooseArrow>().switchLockStatu();
                }
            }
            return;
        }
    }

    void transferData() {
        for (int i = 0; i < maxRow; i++) {
            PlayerPrefs.SetInt("player" + (i+1) + "Choise", playerChoise[i]);
        }
    }

    void checkAll() {
        for (int i = 0; i < maxRow; i++) {
            if (!isPlayerChoosen[i]) {
                return;
            }
        }
        transferData();
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    void toMapFirst(int arrowIndex) {
        int row = arrows[arrowIndex].GetComponent<CM_ChooseArrow>().getVerticalPos();
        int order = arrowsMap[row].IndexOf(arrows[arrowIndex]);
        if (order != 0) {
            object temp = arrowsMap[row][0];
            arrowsMap[row][0] = arrowsMap[row][order];
            arrowsMap[row][order] = temp;
        }
        refreshRowPos(row);
    }

    void changeRow(int arrowIndex, int destinationRow) {
        if (arrows[arrowIndex].GetComponent<CM_ChooseArrow>().getLocked()) {
            return;
        }
        int row = arrows[arrowIndex].GetComponent<CM_ChooseArrow>().getVerticalPos();
        //float horizontalMoveDis = (destinationHorizontalIndex - arrowIndex) * horizontalGap;
        float verticalMoveDis = (destinationRow - row) * horizontalGap;
        //translate arrow to new position
        //arrows[arrowIndex].transform.Translate(new Vector3(verticalMoveDis, 0,0));
        arrows[arrowIndex].transform.position += Vector3.right * verticalMoveDis;
        //delete from current row
        arrowsMap[row].Remove(arrows[arrowIndex]);
        //add to new row
        arrowsMap[destinationRow].Add(arrows[arrowIndex]);
        //refresh arrow statu
        arrows[arrowIndex].GetComponent<CM_ChooseArrow>().changeVerticalPos(destinationRow);
        //refresh row statu
        refreshRowPos(row);
        refreshRowPos(destinationRow);
    }

    void refreshRowPos(int row) {
        int number = 0;
        foreach (GameObject o in arrowsMap[row]) {
            o.transform.position =new Vector3 (o.transform.position.x , minYPos + number * verticalGap ,o.transform.position.z );
            number++;
        }
    }
    float temp = 0.7f;
    private int getLeftButton() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetAxis("L_XAxis_1") < temp) {
            return 0;
        }
        if (Input.GetKeyDown(KeyCode.J) || Input.GetAxis("L_XAxis_2") < temp)
        {
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("L_XAxis_3") < temp)
        {
            return 2;
        }
        return -1;
    }

    private int getRightButton()
    {
        if (Input.GetKeyDown(KeyCode.D)||Input.GetAxis("L_XAxis_1") > temp)
        {
            return 0;
        }
        if (Input.GetKeyDown(KeyCode.L)||Input.GetAxis("L_XAxis_1") > temp)
        {
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)||Input.GetAxis("L_XAxis_1") > temp)
        {
            return 2;
        }
        return -1;
    }

    private int getConfirmButton()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("A_1"))
        {
            return 0;
        }
        if (Input.GetKeyDown(KeyCode.K) || Input.GetButtonDown("A_2"))
        {
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("A_3"))
        {
            return 2;
        }
        return -1;
    }
}
