using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField]
    private RectTransform mini_map_player;
    [SerializeField]
    private Transform real_player;

    private float offset = -25.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mini_map_player.localPosition = new Vector3(mini_map_player.localPosition.x, real_player.localPosition.x * offset, mini_map_player.localPosition.z);
    }
}
