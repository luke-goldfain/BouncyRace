using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    [SerializeField]
    GameManager GameManager;

    private AudioSource lapAudio;

	// Use this for initialization
	void Start ()
    {
        lapAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Character Player = collision.gameObject.GetComponent<Character>();

        if (collision.gameObject.tag == "Player")
        {

            if (Player.HasHitCheckpoint)
            {
                lapAudio.Play();

                if (Player.CurrentLap > GameManager.GetMaxLaps())
                {

                    GameManager.Win(Player);

                }
                else
                {

                    Player.CurrentLap++;
                    Player.SetHitCheckpoint(false);
                   
                    Debug.Log(string.Format("Player {0} just finished lap {1}", Player.PlayerNumber, Player.CurrentLap));

                }
            }
               
        }

    }

}
