using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Phil 2");
    }
    public void OnHelpButtonClick()
    {
        SceneManager.LoadScene("Help");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}