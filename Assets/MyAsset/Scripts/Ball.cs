using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    bool released ;
    Vector3 initialGapBetweenPaddle;
    GameObject paddle;
    GameController gc;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        released = false;

        paddle = GameObject.Find("paddle");
        Transform tr_paddle, tr_ball;
        tr_paddle = paddle.GetComponent<Transform>();
        tr_ball = this.GetComponent<Transform>();

        initialGapBetweenPaddle = tr_ball.position - tr_paddle.position;
        Debug.Log("Initial gap is " + initialGapBetweenPaddle);
            Debug.Log("Add initial force to ball");
	}
	
	// Update is called once per frame
	void Update () {
        if (isDemo())
        {
            if (!released)
            {
                if (Random.Range(0f, 100f) < 2f)
                {
                    ShootBall();
                }
            }

        }
        else
        {

            if (!released)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShootBall();
                }
                else
                {
                    AttachBallToPaddle();
                }
            }
        }
    }

    void AttachBallToPaddle()
    {
        Transform tr_paddle, tr_ball;
        tr_paddle = paddle.GetComponent<Transform>();
        //        Debug.Log("Paddle is " + tr_paddle.position);
        tr_ball = this.GetComponent<Transform>();
        Vector3 pos = tr_paddle.position + initialGapBetweenPaddle;
        //        Debug.Log("Calculated ball pos is " + pos);
        tr_ball.position = pos;
    }

    void ShootBall()
    {
        Vector2 initial = new Vector2(4f, 10f);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = initial;

        released = true;

    }

    bool isDemo()
    {
        return gc.IsDemoMode();
    }

    public void ResetBall()
    {
        released = false;

        Vector2 stop2 = new Vector2(0, 0);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = stop2;
        AttachBallToPaddle();
    }
}
