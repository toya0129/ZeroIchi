using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private GameObject power_bar;
    [SerializeField]
    private GameObject speed_bar;

    [SerializeField]
    private GameObject map;

    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject swipe_character;

    // Start is called before the first frame update
    private void Start()
    {
        SpriteRenderer spriteRenderer = map.GetComponent<SpriteRenderer>();
        spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        spriteRenderer.receiveShadows = true;

        power_bar.transform.parent.gameObject.SetActive(true);
        speed_bar.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        power_bar.GetComponent<Image>().fillAmount = playerController.Power;
        speed_bar.GetComponent<Image>().fillAmount = playerController.Power;
    }

    public void SwitchGaugeInShoot()
    {
        power_bar.transform.parent.gameObject.SetActive(false);
        speed_bar.transform.parent.gameObject.SetActive(true);
    }
    public void SwitchGaugeInLastSweep()
    {
        power_bar.transform.parent.gameObject.SetActive(false);
        speed_bar.transform.parent.gameObject.SetActive(false);
        button.SetActive(false);
        StartCoroutine(ExitSweepCharacter());
    }

    public IEnumerator EntrySweepCharacter()
    {
        while(swipe_character.transform.localPosition.z < 17f)
        {
            swipe_character.transform.localPosition += new Vector3(0, 0, 1f);
            yield return new WaitForSeconds(0.01f);
        }
        yield break;
    }
    public IEnumerator ExitSweepCharacter()
    {
        while (swipe_character.transform.localPosition.z > -25f)
        {
            swipe_character.transform.localPosition -= new Vector3(0, 0, 1f);
            yield return new WaitForSeconds(0.001f);
        }
    }
    public IEnumerator SweepCharacter()
    {
        while(swipe_character.transform.localPosition.x < -2f)
        {
            swipe_character.transform.localPosition += new Vector3(1f, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }

        while(swipe_character.transform.localPosition.x > -25f)
        {
            swipe_character.transform.localPosition -= new Vector3(1f, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        yield break;
    }
}
