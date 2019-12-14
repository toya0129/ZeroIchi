using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static int score;
    private static bool game_end_flag;

    // Start is called before the first frame update
    private void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
        score = 0;
        game_end_flag = false;

    }

    #region Getter and Setter
    public static bool GameEndFlag
    {
        get { return game_end_flag; }
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
