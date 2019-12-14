using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private EnemyScript enemyScript;

    private static int score;
    private static bool game_end_flag;

    private List<GameObject> player_sub;
    private List<GameObject> enemy_sub;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject[] score_object;

    // Start is called before the first frame update
    private void Start()
    {
        Initialized();
    }
    private void Update()
    {
        Debug.Log(score);
    }

    private void Initialized()
    {
        score = 0;
        game_end_flag = false;
    }

    public IEnumerator GameEnd()
    {
        player_sub = enemyScript.PlayerSubBall;
        enemy_sub = enemyScript.EnemySubBall;

        player.GetComponent<SphereCollider>().enabled = false;

        for(int i = 0; i < player_sub.Count; i++)
        {
            player_sub[i].GetComponent<SphereCollider>().enabled = false;
            player_sub[i].transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;
            player_sub[i].GetComponent<Rigidbody>().useGravity = false;
        }
        for(int j = 0; j < enemy_sub.Count; j++)
        {
            enemy_sub[j].GetComponent<SphereCollider>().enabled = false;
            enemy_sub[j].transform.GetChild(0).GetComponent<SphereCollider>().enabled = true;
            enemy_sub[j].GetComponent<Rigidbody>().useGravity = false;
        }
        yield return StartCoroutine(ScoreCalulation());

        LoadResultScene();
        yield break;
    }

    private IEnumerator ScoreCalulation()
    {
        yield return new WaitForSeconds(1f);
        for (int i=0;i< score_object.Length; i++)
        {
            score_object[i].GetComponent<GoalCollider>().ScoreCalculationTrigger = true;
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < player_sub.Count; i++)
        {
            player_sub[i].GetComponent<Rigidbody>().useGravity = false;
        }
        for (int j = 0; j < enemy_sub.Count; j++)
        {
            enemy_sub[j].GetComponent<Rigidbody>().useGravity = false;
        }
        yield break;
    }

    public void AddScore(int obj_score)
    {
        score += obj_score;
    }
    public void SubScore(int obj_score)
    {
        score -= obj_score;
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
        SceneManager.LoadScene("Title");
    }
    #endregion
}
