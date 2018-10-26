using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public string startToLoad;
    public string creditsToLoad;
    [SerializeField]
    private GameObject soundTrackObject;

    private void Start()
    {
        if (GameObject.Find("Soundtrack(Clone)") == null)
        {
            Instantiate(soundTrackObject);
        }
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(startToLoad);
    }

    public void OnCreditsClick()
    {
        
        SceneManager.LoadScene(creditsToLoad);

    }

    public void OnExitClick()
    {
        Application.Quit();
    }
    
}
