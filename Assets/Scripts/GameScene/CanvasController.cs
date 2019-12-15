using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private GameObject bar;

    [SerializeField]
    private GameObject map;

    // Start is called before the first frame update
    private void Start()
    {
        //FadeIn
        FadeManager.FadeIn();

        SpriteRenderer spriteRenderer = map.GetComponent<SpriteRenderer>();
        spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        spriteRenderer.receiveShadows = true;
    }

    // Update is called once per frame
    private void Update()
    {
        bar.GetComponent<Image>().fillAmount = playerController.Power;
    }
}
