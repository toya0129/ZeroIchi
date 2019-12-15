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
    private CanvasController canvasController;

    [SerializeField]
    private GameObject ball;

	private Coroutine power_coroutine;
	private Coroutine interva_coroutine;
    private Coroutine sweep;
	private float power;
	private float first_power;

	public float velocity;
    private float old_velocity = 0f;
	private float max_velocity = 5.0f;
    private float default_velocity = 0.005f;
    private float sub_velocity = 0.005f;
	private bool shoot_trigger = false;

    [SerializeField]
    private float sweep_sub_velocity = 0.002f;

	// Start is called before the first frame update
	private void Start()
    {
		power_coroutine = StartCoroutine(PowerGauge());
	}

    // Update is called once per frame
    private void Update()
    {
		if (shoot_trigger)
		{
            if (velocity < 0.5f)
            {
                velocity = ball.GetComponent<Rigidbody>().velocity.x;
                velocity += sub_velocity;
                ball.GetComponent<Rigidbody>().velocity = new Vector3(velocity, 0, 0);
            }
            else
            {
                shoot_trigger = false;
                ball.GetComponent<Rigidbody>().isKinematic = true;
                velocity = 0.0f;
                if (interva_coroutine != null)
                {
                    StopCoroutine(interva_coroutine);
                }
                StartCoroutine(gameController.GameEnd());
            }
            power = Math.Abs(velocity / max_velocity);
            old_velocity = velocity;
		}
	}

	public void BallShoot()
    {
        canvasController.SwitchGaugeInShoot();
        StartCoroutine(canvasController.EntrySweepCharacter());
		StopCoroutine(power_coroutine);
		ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * power * max_velocity;
        velocity = ball.GetComponent<Rigidbody>().velocity.x;
        shoot_trigger = true;
        cameraMove.SetTarget(ball.transform);
	}
	public void FloorSweep()
	{
        sweep = StartCoroutine(canvasController.SweepCharacter());

        sub_velocity = sweep_sub_velocity;

        if (interva_coroutine == null)
        {
            interva_coroutine = StartCoroutine(Interval());
        }
    }

    private IEnumerator Interval()
    {
        yield return new WaitForSeconds(1f);
        sub_velocity = default_velocity;
        interva_coroutine = null;
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
