using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //
    [SerializeField]
    int StartCount;
    [SerializeField]
    int EndCount;
    [SerializeField]
    int CountdownFade;
    [SerializeField]
    int TotalLaps;

    //
    [SerializeField]
    Text Countdown;
    [SerializeField]
    List<AudioClip> Sounds;

    //
    [SerializeField]
    PlayState GameState;
    [SerializeField]
    List<GameObject> Players;
    [SerializeField]
    private AudioSource musicAudioSources;
    private AudioSource stingerAudioSource;

	// Use this for initialization
	void Start ()
    {

        StartCoroutine(StartCountdown());
        stingerAudioSource = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update ()
    {


    }

    private IEnumerator StartCountdown()
    {

        Color BaseColor = Countdown.color;

        this.GetComponent<AudioSource>().PlayOneShot(Sounds[0]);

        int Count = StartCount;
        while (Count != 0)
        {

            Countdown.text = Count.ToString();
            Countdown.CrossFadeAlpha(0, 1.0f, false);
            yield return new WaitForSeconds(1);
            Countdown.CrossFadeAlpha(255, 1.0f, true);
            Count--;

        }
        
        //
        Countdown.text = "start";
        GameState = PlayState.PLAYING;
        Countdown.CrossFadeAlpha(0, 1.0f, false);

    }

    private IEnumerator EndCountdown(Character WP)
    {

        
        Countdown.CrossFadeAlpha(255, 5.0f, true);
        Countdown.text = string.Format("player {0} wins!", WP.PlayerNumber);
        this.GetComponent<AudioSource>().PlayOneShot(Sounds[1]);
        yield return new WaitForSeconds(EndCount);
        SceneManager.LoadScene("End");
    }

    public void Win(Character WinningPlayer)
    {

        Countdown.text = "";
        GameState = PlayState.ENDING;
        musicAudioSources.Stop();
        stingerAudioSource.Play();
        StartCoroutine(EndCountdown(WinningPlayer));

    }

    public PlayState GetState()
    {

        return GameState;

    }

    public int GetMaxLaps()
    {

        return TotalLaps;

    }

}
