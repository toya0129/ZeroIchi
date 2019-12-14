using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScoreCollider : MonoBehaviour
{
    private int score;

    private void OnDestroy()
    {
        GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();
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
