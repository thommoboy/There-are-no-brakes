using UnityEngine;
using System.Collections;

public class M_GrahpicPanel : MonoBehaviour {
    int currentPage = 1;
    int maxpage = 2;
    public GameObject panel;
    private float distance = 0.8f;
    public GameObject[] GrahpicOptions;
    public int optionsNumberPrePage;
	// Use this for initialization
	void Start () {
        updateTextStatu();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextPage() {
        if (currentPage + 1 <= maxpage) {
            currentPage += 1;
            move(1);
        }
        updateTextStatu();
    }

    public void prePage() {
        if (currentPage - 1 > 0)
        {
            currentPage -= 1;
            move(-1);
        }
        updateTextStatu();
    }

    private void updateTextStatu() {
        //GameObject list = this.gameObject.transform.GetChild(0).gameObject;
        //list = list.gameObject.transform.GetChild(0).gameObject;
        for (int i=0;i< GrahpicOptions.Length;i++) {
            if ( (currentPage - 1) * optionsNumberPrePage <= i && i< currentPage * optionsNumberPrePage)
                GrahpicOptions[i].gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            else
                GrahpicOptions[i].gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }

        GameObject.Find("Graphcis_Pre").GetComponent<M_ContollerSwitch>().up = GrahpicOptions[currentPage * optionsNumberPrePage - 3].transform.GetChild(1).gameObject;
        GameObject.Find("Graphcis_Next").GetComponent<M_ContollerSwitch>().up = GrahpicOptions[currentPage * optionsNumberPrePage - 1].transform.GetChild(1).gameObject;
    }


    private void move(float derection) {
        panel.transform.localPosition -= Vector3.up *797 *  derection;
    }
}
