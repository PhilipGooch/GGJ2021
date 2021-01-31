using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public float startTime;
    public float currentTime;
    public bool gameStarted = false;

    public int roundNum = 0;
    public Text roundInfoText;
    public Text countdownText;
    public Text livesText;

    public RatManager ratManager;
    public RatAudioFeedback audioFeedback;

    public List<GameObject> marbles;

    public int currentMarble = 0;
    public PlayerHoleSelection selection;
    public BoxContainer boxContainer;

    int score = 0;
    int lives = 3;
    int marblesInRound = 1;

    enum PHASE {START, WAIT, GAME, SELECTION };
    PHASE phase;
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
            case PHASE.START:
                RoundStart();
                break;
            case PHASE.WAIT:
                WaitPhase();
                break;
            case PHASE.GAME:
                GamePhase();
                break;
            case PHASE.SELECTION:
                PlayerSelectionPhase();
                break;
        }

    }

    void RoundStart() {
        roundInfoText.color = Color.black;
        currentTime = 0;
        currentMarble = 0;
        countdownText.text = (startTime - (int)currentTime).ToString();
        roundInfoText.text = "Round Starts: ";
        roundNum++;
        marblesInRound++;
        livesText.gameObject.SetActive(false);
        livesText.text = "Lives: " + lives.ToString();
        boxContainer.PopulateBox(marblesInRound);
        marbles.Clear();
        for(int i = 0; i < boxContainer.marbles.Count; i++)
        {
            marbles.Add(boxContainer.marbles[i]);
        }
        phase = PHASE.WAIT;
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
            //gameStarted = true;
            ratManager.ResetRats();
            ratManager.ReleaseRats();
            countdownText.text = " ";
            roundInfoText.text = "Round: " + roundNum.ToString();
            phase = PHASE.GAME;
        }
        else
        {
            // set text to be countdown value
            countdownText.text = (startTime - (int)currentTime).ToString();
        }
    }
    void GamePhase() {

        // Debug for checking the round start code works... change this to be called after rats rturn to holes
        if (ratManager.allRatsReturned())
        {
            phase = PHASE.SELECTION;
        }
    }

    void PlayerSelectionPhase() {

        if (currentMarble == marblesInRound)
        {
            
            phase = PHASE.START;
            return;
        }

        livesText.gameObject.SetActive(true);
        if (lives > 0)
        {
            switch (marbles[currentMarble].name)
            {
                case "Red":
                    roundInfoText.color = Color.red;
                    break;
                case "Green":
                    roundInfoText.color = Color.green;
                    break;
                case "Blue":
                    roundInfoText.color = Color.blue;
                    break;
                case "Yellow":
                    roundInfoText.color = Color.yellow;
                    break;
                case "Cyan":
                    roundInfoText.color = Color.cyan;
                    break;
                case "Majenta":
                    roundInfoText.color = Color.magenta;
                    break;
            }

            
            roundInfoText.text = "Find the " + marbles[currentMarble].name + " Marble!";

            GameObject selcted = selection.PlayerChoice();
            if (selcted)
            {
                // if the hole has a marble 
                if (selcted.GetComponent<HoleContentsCheck>().marble)
                {
                    // check the holes marble with the current marble
                    if (selcted.GetComponent<HoleContentsCheck>().marble.name == marbles[currentMarble].name +"(Clone)")
                    {
                        // selected right marble
                        if (currentMarble < 6)
                        {
                            audioFeedback.RatComment(true);
                            score++;
                            currentMarble++;
                            selection.MoveSelectedRat();
                        }
                        if(currentMarble >= 6)
                        {
                            SceneManager.LoadScene("Win");
                            return;
                        }
                    }
                    // the hole has the wrong marble
                    else
                    {
                        audioFeedback.RatComment(false);
                        lives--;
                        livesText.text = "Lives: " + lives.ToString();
                        
                    }
                }
                // the hole has no marble
                else {

                    audioFeedback.RatComment(false);
                    lives--;
                    livesText.text = "Lives: " + lives.ToString();
                    selection.MoveSelectedRat();
                }
            }
        }
        else {
            SceneManager.LoadScene("LoseScreen");
        }

       
    }
}
