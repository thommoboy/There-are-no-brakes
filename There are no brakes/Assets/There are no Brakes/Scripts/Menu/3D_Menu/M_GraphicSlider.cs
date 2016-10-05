using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class M_GraphicSlider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeValue(string sliderName, float value) {
        float temp = this.GetComponent<Slider>().value;

        if (value > 0)
        {
            temp = Mathf.Min(1.0f, temp + value);
        }
        else if (value < 0)
        {
            temp = Mathf.Max(0.0f, temp + value);
        }

        this.GetComponent<Slider>().value = temp;
    }
}
