using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject brick1;
    public GameObject brick2;
    public GameObject brick3;

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

        SetupBricks(1);
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
        ClearAllBricks();
        SetupBricks( 1 );
    }

    private void GameOver()
    {
        isDemoMode = true;
        messageText.text = "Game Over";
    }

    private void ClearAllBricks()
    {
        GameObject[] bricks;
        bricks = GameObject.FindGameObjectsWithTag("IsBrick");
        foreach ( GameObject obj in bricks){
            Destroy(obj);
        }
    }

    private void SetupBricks(int level)
    {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 11; x++)
            {
                GameObject prefab;
                switch (y)
                {
                    case 0:
                    case 1:
                        prefab = brick1;
                        break;
                    case 2:
                    case 3:
                        prefab = brick2;
                        break;
                    case 4:
                    case 5:
                        prefab = brick3;
                        break;
                    default:
                        prefab = brick1;
                        break;

                }
                Instantiate(prefab, new Vector3((float)x * 7.0f/ 5.0f - 7.0f, (float)y* 0.5f + 2.0f, -1.0f), Quaternion.identity);
            }
        }

    }
}