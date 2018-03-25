using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int InitialLife;
    public GameObject smokeParticle;
    private int life;
    GameController gc;

    // Use this for initialization
    void Start () {
        life = InitialLife;
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Hit! Life is" + life);
        if (--life == 0)
        {
            print("Destroyed " + life);
            Instantiate(smokeParticle, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            gc.AddScore(InitialLife);
            Destroy(gameObject);
        }
    }


}
