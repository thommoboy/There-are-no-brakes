using UnityEngine;
using System.Collections;

public class M_GrahpicPanel : MonoBehaviour {
    int currentPage = 1;
    int maxpage = 2;
    public GameObject panel;
    private float distance = 0.8f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextPage() {
        if (currentPage + 1 <= maxpage) {
            currentPage += 1;
            move(1);
        }
    }

    public void prePage() {
        if (currentPage - 1 > 0)
        {
            currentPage -= 1;
            move(-1);
        }
    }

    private void move(float derection) {
        panel.transform.localPosition -= Vector3.up *797 *  derection;
    }
}
