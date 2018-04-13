using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameState GameState;
    [SerializeField]
    List<GameObject> Players;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        switch(GameState)
        {

            case GameState.STARTING:
                {

                    Starting();
                    break;

                }
            case GameState.PLAYING:
                {

                    Playing();
                    break;

                }
            case GameState.ENDING:
                {

                    Ending();
                    break;

                }

        }

	}

    private void Starting()
    {


    }

    private void Playing()
    {


    }

    private void Ending()
    {



    }

}
