using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public float startTime;
    public float currentTime;
    public bool gameStarted = false;

    public Text countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        countdownText.text = (startTime - (int)currentTime).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;


        if (currentTime > startTime) {
            gameStarted = true;
            countdownText.text = " ";
        }
        else {
            countdownText.text = (startTime - (int)currentTime).ToString();
        }
    }
}
