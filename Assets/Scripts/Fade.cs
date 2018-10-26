using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {


    Text ThisText;

	// Use this for initialization
	void Start ()
    {

        ThisText = this.gameObject.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update ()
    {



	}


    private IEnumerator JustFade()
    {


        while (ThisText.color.a > 0)
        {

            Debug.Log("test");
            yield return new WaitForEndOfFrame();
            ThisText.color = new Color(ThisText.color.r, ThisText.color.g, ThisText.color.b, ThisText.color.a - (Time.deltaTime * 1));

        }

    }

}
