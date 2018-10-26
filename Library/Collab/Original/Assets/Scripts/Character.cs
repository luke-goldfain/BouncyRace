using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Character : MonoBehaviour
{

    [SerializeField]
    GameManager GameManager;
    public int PlayerNumber;

    [HideInInspector]
    public int LapsCompleted;

    //input fields
    private string HorizontalInputAxis
    {
        get { return "Horizontal" + PlayerNumber;  }
    }
    private string VerticalInputAxis
    {
        get { return "Vertical" + PlayerNumber; }
    }
    private string JetpackAxis
    {
        get { return "Fire" + PlayerNumber; }
    }

    private float angle;
    private bool hasControlEnabled;
    

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        StateCheck();

	}

    private void GetInput()
    {

    }

    //aim direction reference
    //private void HandleAimingDirection()
    //{
    //    horizontalShootingAxis = Input.GetAxis("ShootHorizontal" + playerNumber) * Time.deltaTime * 15;
    //    verticalShootingAxis = Input.GetAxis("ShootVertical" + playerNumber) * Time.deltaTime * 15;

    //    float angle = Mathf.Atan2(horizontalShootingAxis, verticalShootingAxis) * Mathf.Rad2Deg;

    //    GunAxis.transform.eulerAngles = new Vector3(0, 0, angle);
    //}

    private void StateCheck()
    {

        switch(GameManager.GetState())
        {

            case PlayState.STARTING:
                {
                    if (hasControlEnabled)
                        hasControlEnabled = false;
                    break;
                }
            case PlayState.PLAYING:
                {
                    if (!hasControlEnabled)
                        hasControlEnabled = true;
                    break;
                }
            case PlayState.ENDING:
                {
                    if (hasControlEnabled)
                        hasControlEnabled = false;
                    break;
                }
        }

    }

}
