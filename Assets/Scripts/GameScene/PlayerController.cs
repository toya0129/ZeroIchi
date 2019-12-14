using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BallShoot()
    {
        gameController.CoroutineStop();
        float power = GameController.Power * 100;
        ball.GetComponent<Rigidbody>().AddForce(ball.transform.right * power);
    }
    public void FloorSweep()
    {

    }
}
