using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollider : MonoBehaviour
{
    [SerializeField]
    private int score;

    private bool score_calculation_trigger = false;

    public void OnTriggerStay(Collider other)
    {
        if (score_calculation_trigger)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<BallScoreCollider>().Score = score;
                Destroy(other.gameObject);
            }
        }
    }

    public bool ScoreCalculationTrigger
    {
        set { score_calculation_trigger = value; }
    }
}
