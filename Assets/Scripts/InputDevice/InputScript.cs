using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    // 入力手順
    private int input_phase;

    // 入力かのであるか
    private bool input_enable;

    // Start is called before the first frame update
    private void Start()
    {
        Initialized();
    }

    // Update is called once per frame
    private void Update()
    {
        Key_Input();
        Digital_Input();
        //Analog_Input();
        //ActionStart();
    }

    private void Initialized()
    {
        input_phase = 0;
        input_enable = true;
    }

    private void ActionStart()
    {
        switch (input_phase)
        {
            case 0:
                playerController.BallShoot();
                input_phase++;
                break;
            case 1:
                playerController.FloorSweep();
                break;
        }
    }

    private void Analog_Input()
    {

    }

    private void Digital_Input()
    {

    }

    // Debug
    private void Key_Input()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ActionStart();
            }
        }
    }
}
