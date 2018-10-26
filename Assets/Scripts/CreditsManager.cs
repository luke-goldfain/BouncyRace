using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{

    public string backToLoad;

    public void OnBackClick()
    {
        SceneManager.LoadScene(backToLoad);
    }
}
