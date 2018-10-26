using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsManager : MonoBehaviour
{

    public string playToLoad;
    public string backToLoad;
    [SerializeField]
    private GameObject soundTrackObject;

    private void Start()
    {
        if (GameObject.Find("Soundtrack(Clone)") == null)
        {
            Instantiate(soundTrackObject);
        }
    }

    public void OnPlayButtonClick()
    {
        Destroy(GameObject.Find("Soundtrack(Clone)"));
        SceneManager.LoadScene(playToLoad);
    }

    public void OnBackClick()
    {
        SceneManager.LoadScene(backToLoad);
    }

}
