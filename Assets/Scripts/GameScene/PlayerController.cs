using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
	[SerializeField]
	private CameraMove cameraMove;

    [SerializeField]
    private GameObject ball;

	private Coroutine power_coroutine;
	private float power;
	private const float max_velocity;


	// Start is called before the first frame update
	void Start()
    {
		power_coroutine = StartCoroutine(PowerGauge());
	}

    // Update is called once per frame
    void Update()
    {
	}

	public void BallShoot()
    {
		StopCoroutine(power_coroutine);
		ball.GetComponent<Rigidbody>().velocity = new Vector3(-power, 0, 0);

		cameraMove.SetTarget(ball.transform);
	}
    public void FloorSweep()
    {
        
    }

    private void FixedVelocity()
	{
		Vector3 velocity = ball.GetComponent<Rigidbody>().velocity;
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
