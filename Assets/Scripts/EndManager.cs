using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{

    public string playAgainToLoad;
    public string backToMenuToLoad;

    [SerializeField]
    private GameObject soundTrackObject;

    private void Start()
    {
        if (GameObject.Find("Soundtrack(Clone)") == null)
        {
            Instantiate(soundTrackObject);
        }
    }

    public void OnPlayAgainClick()
    {
        Destroy(GameObject.Find("Soundtrack(Clone)"));
        SceneManager.LoadScene(playAgainToLoad);
    }

    public void OnBackToMenuClick()
    {
        SceneManager.LoadScene(backToMenuToLoad);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

}
