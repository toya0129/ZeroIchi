using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_prefab;
    [SerializeField]
    private GameObject player_prefab;

    private Vector3[,] player_spawn = new Vector3[2, 4]
    {
        { new Vector3(-18f,1,-0.7f),new Vector3(-16f,1,-0.7f),new Vector3(-16f,1,0),new Vector3(-17f,1,2f) },
        { new Vector3(-17f,1,0.8f),new Vector3(-14f,1,0),new Vector3(-19f,1,1),new Vector3(-17f,1,0.2f) }
    };
    private Vector3[,] enemy_spawn = new Vector3[3, 4]
    {
        { new Vector3(-18f,1,0),new Vector3(-15f,1,1f),new Vector3(-18f,1,-2f),new Vector3(-18f,1,2f) },
        { new Vector3(-17f,1,0),new Vector3(-15f,1,0),new Vector3(-15f,1,-2f),new Vector3(-17f,1,-0.2f) },
        { new Vector3(-18.2f,1,1),new Vector3(-17.5f,1,0.2f),new Vector3(-19f,1,-1),new Vector3(-17.9f,1,2f) }
    };

    // Start is called before the first frame update
    private void Start()
    {
        EnemyAndPlayerGenerate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnemyAndPlayerGenerate()
    {
        GameObject obj;

        // player generate
        for (int i = 0; i < 2; i++){
            int rand = Random.Range(0, 4);
            obj = Instantiate(player_prefab);
            obj.transform.localPosition = player_spawn[i, rand];
        }

        // enemy generate
        for (int j = 0; j < 3; j++)
        {
            int rand = Random.Range(0, 4);
            obj = Instantiate(enemy_prefab);
            obj.transform.localPosition = enemy_spawn[j, rand];
        }
    } 
}
