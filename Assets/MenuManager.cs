using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Phil2");
    }
    public void OnHelpButtonClick()
    {
        SceneManager.LoadScene("Jamie");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}