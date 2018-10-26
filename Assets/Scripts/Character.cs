using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //variables for tracking gamestate
    [HideInInspector]
    public int CurrentLap;
    [HideInInspector]
    public bool HasHitCheckpoint;
    [HideInInspector]
    public int LapsCompleted;

    //editor-accessible
    [SerializeField]
    GameManager GameManager;
    [SerializeField]
    private Slider gasSlider;
    public int PlayerNumber;
    [SerializeField]
    private float turnSpeed = 15;
    [SerializeField]
    private float boostForce = 100;
    [SerializeField]
    Text LapCounter;

    //Fuel Variables
    [SerializeField]
    private float fuelConsuptionRate = 0.04f;
    [SerializeField]
    private float fuelRechargeRate = 0.1f;
    private float fuelMax = 100;
    private float currentFuelLevel;

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
    //input variables
    private float horizontalInput;
    private float verticalInput;
    private bool canBoost;
    private bool isRefuelling = false;
    private Vector3 LookDirection;

    private bool hasControlEnabled = true;

    //component references
    private Rigidbody2D rigidbody;
    private ParticleSystem particle;
    private SpriteRenderer renderer;
    private AudioSource flyingAudio;

	// Use this for initialization
	void Start ()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        particle = GetComponentInChildren<ParticleSystem>();
        currentFuelLevel = fuelMax;
        flyingAudio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        StateCheck();
        GetInput();
        SetRotation();
        CheckForEmpty();
        RedWhenRefilling();
        UpdateGasUI();
        UpdateLapUI();
    }

    private void FixedUpdate()
    {
        Boost();
    }

    private void CheckForEmpty()
    {
        if (currentFuelLevel <= 0)
        {
            StartCoroutine(EmptyRefillCoroutine());
        }
    }

    private void GetInput()
    {
        if (hasControlEnabled)
        {
            horizontalInput = Input.GetAxis(HorizontalInputAxis);
            verticalInput = Input.GetAxis(VerticalInputAxis);
            //button pressed
            if (Input.GetButtonDown(JetpackAxis))
            {
                StartCoroutine(FuelConsumptionCoroutine());
                flyingAudio.Play();
            }
            //button held
            if (Input.GetButton(JetpackAxis) && currentFuelLevel > 0)
            {
                canBoost = true;
            }
            else
            {
                canBoost = false;
                flyingAudio.Stop();
            }
        }
    }

    private void SetRotation()
    {
        float angle = Mathf.Atan2(horizontalInput * Time.deltaTime * turnSpeed, verticalInput * Time.deltaTime * turnSpeed) * Mathf.Rad2Deg;
        LookDirection = new Vector3(0, 0, angle);
        transform.eulerAngles = LookDirection;
    }

    private void UpdateGasUI()
    {
        gasSlider.value = currentFuelLevel;
    }

    private void UpdateLapUI()
    {

        LapCounter.text = string.Format("{0}/3", CurrentLap + 1);

    }

    private void Boost()
    {
        if (canBoost && !isRefuelling)
        {
            particle.Play();
            rigidbody.AddForce(transform.up * boostForce);
        }
        else
        {
            particle.Stop();
        }
    }

    private IEnumerator FuelConsumptionCoroutine()
    {
        while (Input.GetButton(JetpackAxis) && currentFuelLevel > 0 && !isRefuelling)
        {
            currentFuelLevel--;
            yield return new WaitForSeconds(fuelConsuptionRate);
        }
    }

    private IEnumerator EmptyRefillCoroutine()
    {
        isRefuelling = true;
        while (currentFuelLevel < fuelMax)
        {
            currentFuelLevel++;
            yield return new WaitForSeconds(fuelRechargeRate);
        }
        isRefuelling = false;
    }

    private void RedWhenRefilling()
    {
        if (isRefuelling)
        {
            renderer.color = Color.red;
        }
        else
        {
            renderer.color = Color.white;
        }
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "FinishLine")
        {

            Debug.Log(HasHitCheckpoint);

            if (HasHitCheckpoint)
            {
                // Don't increment CurrentLap here, as it is incremented in "Finish.cs"

            }

        }
        else if(collision.gameObject.tag == "Checkpoint")
        {

            HasHitCheckpoint = true;

            Debug.Log(String.Format("Player {0} Hit checkpoint! Current lap: {1}",PlayerNumber, CurrentLap));

        }
        else if (collision.gameObject.tag == "pickup")
        {
            currentFuelLevel = fuelMax; 
        }

    }

    public void SetHitCheckpoint(bool SetCheckpoint)
    {

        HasHitCheckpoint = SetCheckpoint;

    }

    public bool GetHitCheckpoint()
    {

        return HasHitCheckpoint;

    }

    public int GetLaps()
    {

        return CurrentLap;

    }

}
