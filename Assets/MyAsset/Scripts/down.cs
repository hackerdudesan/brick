using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour {
    GameController gc;

	// Use this for initialization
	void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gc.BallLost();
    }


}
