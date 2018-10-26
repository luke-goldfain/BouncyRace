using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    [SerializeField]
    bool HitOtherMissiles;
    [SerializeField]
    int BounceMax;
    [SerializeField]
    float DetonationTime;
    [SerializeField]
    float ExplosionSize;

	// Use this for initialization
	void Start ()
    {

        Detonated = false;
        StartCoroutine(Detonate());

	}

    private bool Detonated;

	// Update is called once per frame
	void Update ()
    {


	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Projectile" || !HitOtherMissiles)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            StartCoroutine(Explode());

        }

    }

    private IEnumerator Detonate()
    {

        yield return new WaitForSeconds(DetonationTime);
        StartCoroutine(Explode());

    }

    private IEnumerator Explode()
    {

        Detonated = true;
        this.GetComponent<Animator>().Play("Explode");
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);

    }

}
