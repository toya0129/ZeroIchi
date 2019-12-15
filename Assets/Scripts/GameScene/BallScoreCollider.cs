using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScoreCollider : MonoBehaviour
{
    private GameController gameController;
    private int score;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void OnDestroy()
    {
        if(this.gameObject.tag == "Player")
        {
            gameController.AddScore(score);
        }
        else if(this.gameObject.tag == "Enemy")
        {
            gameController.SubScore(score);
        }
    }

    public int Score
    {
        set { score = value; }
    }
}
