using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSweep : MonoBehaviour
{
    [SerializeField]
    private InputScript inputScript;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            inputScript.InputPhase = 99;
        }
    }
}
