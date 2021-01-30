using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public float startTime;
    public float currentTime;
    public bool gameStarted = false;

    public int roundNum = 0;
    public Text roundInfoText;
    public Text countdownText;

    public int phase = 0;

    public List<GameObject> listOfGO = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        RoundStart();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        switch (phase) {
            case 0:
                RoundStart();
                break;
            case 1:
                WaitPhase();
                break;
            case 2:
                GamePhase();
                break;
            case 3:
                PlayerSelectionPhase();
                break;
        }

    }

    void RoundStart() {

        currentTime = 0;
        countdownText.text = (startTime - (int)currentTime).ToString();
        roundInfoText.text = "Round Starts: ";
        roundNum++;
        phase = 1;
        // tell the rats to go to for marbles...reachedbox = false  
    }

    void RoundOver() { 
       
        //player has made selections
        //  call round start
    }
    void WaitPhase() {

        // check if game ready to start
        if (currentTime > startTime)
        {
            gameStarted = true;
            countdownText.text = " ";
            roundInfoText.text = "Round: " + roundNum.ToString();
            phase = 2;
        }
        else
        {
            // set text to be countdown value
            countdownText.text = (startTime - (int)currentTime).ToString();
        }
    }
    void GamePhase() {

        // Debug for checking the round start code works... change this to be called after rats rturn to holes
        if (currentTime > 20)
        {
            phase = 3;
        }
    }

    void PlayerSelectionPhase() {
        roundInfoText.text = "Find the INSERTCOLOURHERE Marble!";

        // Debug for checking the round start code works... change this to be called after player makes choices
        //if (currentTime > 25)
        //{
        //    phase = 0;
        //}
    }
}
