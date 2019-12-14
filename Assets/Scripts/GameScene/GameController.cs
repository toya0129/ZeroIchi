using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Coroutine power_coroutine;

    private static int score;

    private static float power;
    [SerializeField]
    private GameObject bar;

    // Start is called before the first frame update
    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        score = 0;
        power_coroutine = StartCoroutine(PowerGauge());
    }

    public void CoroutineStop()
    {
        StopCoroutine(power_coroutine);
    }
 
    private IEnumerator PowerGauge()
    {
        bool t = true;

        while (true)
        {
            if (t)
            {
                power += 0.1f;
            }
            else
            {
                power -= 0.1f;
            }
            bar.GetComponent<Slider>().value = power;

            if (power > 1)
            {
                t = false;
            }
            else if (power < 0)
            {
                t = true;
            }
            yield return new WaitForSeconds(0.05f);
        }
        yield break;
    }


    #region Getter and Setter
    public static float Power
    {
        get { return power; }
    }
    #endregion

    #region Scene Load
    public static void LoadTitleScene()
    {
        SceneManager.LoadScene("");
    }
    public static void LoadGameScene()
    {
        SceneManager.LoadScene("");
    }
    public static void LoadResultScene()
    {
        SceneManager.LoadScene("");
    }
    #endregion
}
