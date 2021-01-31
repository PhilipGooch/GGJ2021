using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    public void OnReturnClick() {
        SceneManager.LoadScene("Menu");
    }
}
