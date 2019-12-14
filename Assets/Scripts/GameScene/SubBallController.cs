using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBallController : MonoBehaviour
{
    private int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * speed;
        }
    }
}
