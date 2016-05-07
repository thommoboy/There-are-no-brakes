using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Seesaw : MonoBehaviour {
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
	    
	}

    
    void OnCollisionEnter(Collision touchItem) {
        if (touchItem.gameObject.name == "Plane" || touchItem.gameObject.transform.position.y < this.transform.position.y) return;

        if (!touchList.Contains(touchItem)) {
            touchList.Add(touchItem);
            count++;
        }
        

        for (int i = 0; i < count; i++) {
            Collision other = touchList[i];
            if (touchItem.gameObject.transform.position.y < other.gameObject.transform.position.y) continue;
            bool onSameSide = true;
            float otherX = other.gameObject.transform.position.x - this.gameObject.transform.position.x;
            float touchItemX = touchItem.gameObject.transform.position.x - this.gameObject.transform.position.x;
            if (otherX * touchItemX < 0) { onSameSide = false; }
            if (onSameSide) continue;
            
            other.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce );
            //string force = (Vector3.up * bounceForce * (Mathf.Abs(otherX) / this.transform.localScale.x) * (Mathf.Abs(touchItemX) / this.transform.localScale.x)).ToString();
            //print("give force");
            //print(force);

        }

        string touch = "";
        for (int i = 0; i < count; i++)
        {
            touch += touchList[i].gameObject.name + ", ";
        }
        print(touch);
        
    }

    void OnCollisionExit(Collision other)
    {
        touchList.Remove(other);
        count--;
    }
}
