using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public float despawnTime = 3;
    private AudioSource pickupAudio;

	// Use this for initialization
	void Start ()
    {
        pickupAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            pickupAudio.Play();

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(WaitForTime());

        }

    }

    private IEnumerator WaitForTime()
    {

        yield return new WaitForSeconds(despawnTime);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;

    }
}
