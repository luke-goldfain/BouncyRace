using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMissiles : MonoBehaviour
{

    [SerializeField]
    Text MissileText;

    [SerializeField]
    Text StopText;

    [SerializeField]
    float MissileThrust;
    [SerializeField]
    int CurrentMissiles;
    [SerializeField]
    int StopPower;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        StopText.text = string.Format("stop:{0}", StopPower);
        MissileText.text = string.Format("missiles:{0}", CurrentMissiles);   

        if (Input.GetButtonDown("FireMissile" + this.gameObject.GetComponent<Character>().PlayerNumber) && CurrentMissiles > 0)
        {

            GameObject NewMissile = Instantiate(Resources.Load<GameObject>("Missile"));
            NewMissile.transform.position = this.transform.position + transform.up * 4.0f;
            NewMissile.transform.rotation = this.transform.rotation;
            NewMissile.GetComponent<Rigidbody2D>().AddForce(transform.up * MissileThrust);
            NewMissile.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up);
            CurrentMissiles--;

        }
        if (Input.GetButtonDown("StopNow" + this.gameObject.GetComponent<Character>().PlayerNumber) && StopPower > 0)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.Lerp(this.gameObject.GetComponent<Rigidbody2D>().velocity, Vector3.zero, 0.75f);
            StopPower--;

        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "RandomPickup")
        {

            switch(collision.gameObject.GetComponent<RandomPickup>().Type)
            {

                case 0:
                    {

                        CurrentMissiles++;
                        break;

                    }
                case 1:
                    {

                        StopPower++;
                        break;
                    }

            }
        }

    }

}
