using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Jamie3");
    }
    public void OnHelpButtonClick()
    {
        SceneManager.LoadScene("Phil");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}