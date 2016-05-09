using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IN_SeeSaw : MonoBehaviour {
    public string playerTag = "player";
    public float bounceForce = 100;
    List<Collision> touchList;
    int count;
    // Use this for initialization
    void Start () {
        count = 0;
        touchList = new List<Collision>();
    }
	
	// Update is called once per frame
	void Update () {
		/*try balance seesaw, faild
		 * if (touchList.Count == 0) {
			if (GameObject.Find ("Seesaw_Left").transform.position.y!= GameObject.Find ("Seesaw_Right").transform.position.y) {
				this.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 50);
			}
		}
		*/
	}

    
    void OnCollisionEnter(Collision touchItem) {
        //print(touchItem.gameObject.name + " enter");
		if (touchItem.gameObject.name == "Plane" || touchItem.gameObject.name == "Cone") return;
        bool flag = false;
        for (int i = 0; i < count; i++) {
			if (touchList[i].gameObject.name == touchItem.gameObject.name) {
                flag = true;
            }
        }

        if (!flag) {
            touchList.Add(touchItem);
            count++;
        }

        if (touchItem.gameObject.transform.position.y < this.transform.position.y) return;

        string touch = "";
        for (int i = 0; i < count; i++)
        {
            touch += touchList[i].gameObject.name + ", ";
        }
        print(touch);

        for (int i = 0; i < count; i++) {
            Collision other = touchList[i];
            if (touchItem.gameObject.transform.position.y < other.gameObject.transform.position.y) continue;
            bool onSameSide = true;
            float otherX = other.gameObject.transform.position.x - this.gameObject.transform.position.x;
            float touchItemX = touchItem.gameObject.transform.position.x - this.gameObject.transform.position.x;
            if (otherX * touchItemX < 0) { onSameSide = false; }
            if (onSameSide) continue;

            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce * (Mathf.Abs(otherX) / (this.transform.localScale.x/3)));
            string force = (Vector3.up * bounceForce * (Mathf.Abs(otherX) / this.transform.localScale.x) * (Mathf.Abs(touchItemX) / this.transform.localScale.x)).ToString();
			print("add force to " + other.collider.gameObject.name);
            print(force);

        }

        
        
    }

    void OnCollisionExit(Collision other)
    {
        for (int i = 0; i < count; i++)
        {
            if (touchList[i].gameObject.name == other.gameObject.name)
            {
                touchList.RemoveAt(i);
                count--;
                break;
            }
        }
    }
}
