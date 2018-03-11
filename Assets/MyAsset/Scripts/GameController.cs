using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int balls_left;
    int score;
    bool isDemoMode;
    Text messageText, ballText, scoreText;
    Ball ball;

    int countsToClearMessage;
    string nextMessage = "";

    // Use this for initialization
    void Start()
    {
        isDemoMode = true;
        balls_left = 0;
        score = 0;
        messageText = GameObject.Find("messageText").GetComponent<Text>();
        ballText = GameObject.Find("ballsText").GetComponent<Text>();
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        ball = GameObject.Find("ball").GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMessage();
        if (isDemoMode)
        {
            if (Input.GetMouseButtonDown(1))
            {

                isDemoMode = false;
                StartGame();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            BallLost();
        }
    }

    private void UpdateMessage()
    {
        if (countsToClearMessage != 0)
        {
            if (--countsToClearMessage == 0)
            {
                messageText.text = nextMessage;

            }
        }

        if (isDemoMode)
        {
            ballText.text = "";
        }
        else
        {
            ballText.text = "BALL Left: " + balls_left;
        }
        scoreText.text = "SCORE: " + score;
    }

    public bool IsDemoMode()
    {
        return isDemoMode;
    }

    public int AddScore(int add)
    {
        score += add;
        return (score);
    }

    public void BallLost()
    {
        balls_left--;
        ball.ResetBall();

        if (balls_left == 0)
        {
            GameOver();
        }
        
    
    }

    private void StartGame()
    {
        balls_left = 5;
        ball.ResetBall();
        messageText.text = "Game Start";
        countsToClearMessage = 60;
        nextMessage = "";
    }

    private void GameOver()
    {
        isDemoMode = true;
        messageText.text = "Game Over";
    }
}