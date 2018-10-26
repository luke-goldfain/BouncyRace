using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickup : MonoBehaviour
{
    [SerializeField]
    List<Sprite> Images;
    [SerializeField]
    public int Type;
    public float despawnTime = 3;

    // Use this for initialization
    void Start()
    {

        RandomizeLoot();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

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
        RandomizeLoot();

    }

    private void RandomizeLoot()
    {

        switch (Random.Range(0, 2))
        {

            case 0:
                {

                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Images[0];
                    Type = 0;
                    break;
                }
            case 1:
                {

                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Images[1];
                    Type = 1;
                    break;
                }
            default:
                {

                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Images[1];
                    Type = 0;
                    break;
                }

        }

    }

}
