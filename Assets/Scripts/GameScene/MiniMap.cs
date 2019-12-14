using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField]
    private EnemyScript enemyScript;

    [SerializeField]
    private RectTransform mini_map_player;
    [SerializeField]
    private Transform real_player;

    [SerializeField]
    private GameObject player_sub_area;
    [SerializeField]
    private GameObject enemy_sub_area;

    private List<GameObject> player_sub;
    private List<GameObject> enemy_sub;

    private float offset = -25.3f;

    // Start is called before the first frame update
    private void Start()
    {
        player_sub_area.SetActive(true);
        enemy_sub_area.SetActive(true);
        player_sub = enemyScript.PlayerSubBall;
        enemy_sub = enemyScript.EnemySubBall;
    }

    // Update is called once per frame
    private void Update()
    {
        mini_map_player.localPosition = new Vector3(mini_map_player.localPosition.x, real_player.localPosition.x * offset, mini_map_player.localPosition.z);

        for(int i = 0; i < player_sub.Count; i++)
        {
            player_sub_area.transform.GetChild(i).localPosition = new Vector3(player_sub_area.transform.GetChild(i).localPosition.x, player_sub[i].transform.localPosition.x * offset, player_sub_area.transform.GetChild(i).localPosition.z);
        }

        for (int j = 0; j < enemy_sub.Count; j++)
        {
            enemy_sub_area.transform.GetChild(j).localPosition = new Vector3(enemy_sub_area.transform.GetChild(j).localPosition.x, enemy_sub[j].transform.localPosition.x * offset, enemy_sub_area.transform.GetChild(j).localPosition.z);
        }
    }
}
