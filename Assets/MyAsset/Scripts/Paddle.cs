using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    GameController gc;
    GameObject ball;
	// Use this for initialization
	void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        ball = GameObject.Find("ball");
    }
	
	// Update is called once per frame
	void Update () {

        if (!isDemo())
        {

            float pos_x = Input.mousePosition.x / Screen.width * 16 - 9;
            //        print("Mous pos is " + pos_x);
            Transform tr = GetComponent<Transform>();
            Vector3 pos = new Vector3(pos_x, tr.position.y, tr.position.z);
            tr.position = pos;
        }
        else
        {
            Transform tr = GetComponent<Transform>();
            Vector3 pos = new Vector3(ball.GetComponent<Transform>().position.x , tr.position.y, tr.position.z);
            tr.position = pos;
        }
    }

    bool isDemo()
    {
        return gc.IsDemoMode();
    }
}
