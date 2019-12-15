using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSweep : MonoBehaviour
{
    [SerializeField]
    private InputScript inputScript;
    [SerializeField]
    private CanvasController canvasController;

    private bool trigger = true;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if(trigger)
            {
                trigger = false;
                canvasController.SwitchGaugeInLastSweep();
                inputScript.InputPhase = 99;
            }
        }
    }
}
