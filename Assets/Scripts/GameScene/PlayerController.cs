using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
	[SerializeField]
	private CameraMove cameraMove;

    [SerializeField]
    private GameObject ball;

	private Coroutine power_coroutine;
	private Coroutine velocity_coroutine;
	private float power;
	private float first_power;

	public float velocity;
	private float max_velocity = 15.0f;
	private bool shoot_trigger = false;

	// Start is called before the first frame update
	void Start()
    {
		power_coroutine = StartCoroutine(PowerGauge());
	}

    // Update is called once per frame
    void Update()
    {
		if (shoot_trigger)
		{
            if (velocity < 0.0f)
            {
                Debug.Log("aa");
                velocity = ball.GetComponent<Rigidbody>().velocity.x;
                velocity += 0.06f;
                ball.GetComponent<Rigidbody>().velocity = new Vector3(velocity, 0, 0);
            }
            else
            {
                velocity = 0.0f;
            }
            power = Math.Abs(velocity / max_velocity);
		}
	}

	public void BallShoot()
    {
		StopCoroutine(power_coroutine);
		ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * power * max_velocity;
        velocity = ball.GetComponent<Rigidbody>().velocity.x;
        //velocity_coroutine = StartCoroutine(FixedVelocity());
        shoot_trigger = true;
        cameraMove.SetTarget(ball.transform);
	}
	public void FloorSweep()
	{
		//StopCoroutine(velocity_coroutine);
        velocity -= 1f;
		ball.GetComponent<Rigidbody>().velocity = new Vector3(velocity, 0, 0);
        //velocity_coroutine = StartCoroutine(FixedVelocity());
    }

	private IEnumerator FixedVelocity()
	{
		do
		{
			velocity = ball.GetComponent<Rigidbody>().velocity.x;
			velocity += 0.00001f;
			ball.GetComponent<Rigidbody>().velocity = new Vector3(velocity, 0, 0);
			yield return new WaitForSeconds(0.01f);
		} while (velocity < 0.0f);
		velocity = 0.0f;
        shoot_trigger = false;
		yield break;
	}

	private IEnumerator PowerGauge()
	{
		bool trigger = true;

		while (true)
		{
			if (trigger)
			{
				power += 0.1f;
			}
			else
			{
				power -= 0.1f;
			}

			if (power > 1)
			{
				trigger = false;
			}
			else if (power < 0)
			{
				trigger = true;
			}
			yield return new WaitForSeconds(0.05f);
		}
		yield break;
	}

	#region Getter and Setter
    public float Power
	{
		get { return power; }
	}
	#endregion
}
