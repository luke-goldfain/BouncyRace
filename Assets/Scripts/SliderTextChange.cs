using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderTextChange : MonoBehaviour {

    [SerializeField]
    Text SliderHandleText;

    [SerializeField]
    Slider OxygenSlider;

	// Update is called once per frame
	void Update () {
        SliderHandleText.text = OxygenSlider.value.ToString();		
	}
}
