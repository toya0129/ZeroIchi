using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    Image startLogo;
    [SerializeField]
    RectTransform titleLogo;
    [SerializeField]
    RectTransform result;
    [SerializeField]
    RectTransform score;
    [SerializeField]
    RectTransform[] ranks;

    float alpha = 1.0f;
    float fadeTime = 1.0f;
    int key = 1;

    bool canSkip = false;

    float moveSpeed = 20.0f;

    private static Coroutine state = null;

    // Start is called before the first frame update
    void Start()
    {
        result.localPosition = new Vector3(2000, 340, 0);
        score.localPosition = new Vector3(2000, 100, 0);
        ranks[0].localPosition = new Vector3(2000, -75, 0);
        ranks[1].localPosition = new Vector3(2000, -250, 0);
        ranks[2].localPosition = new Vector3(2000, -425, 0);

        if (state == null)
        {
            titleLogo.localPosition = new Vector3(0, 0, 0);
            state = StartCoroutine(TitleState());
        }
        else
        {
            titleLogo.localPosition = new Vector3(2000, 0, 0);
            state = StartCoroutine(InResultState());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canSkip)
        {
            
        }
    }

    // Title
    IEnumerator TitleState()
    {
        while (true)
        {
            if (alpha <= -0.10f)
                key = -1;
            if (alpha >= 1.10f)
                key = 1;

            alpha -= key * Time.deltaTime / fadeTime;
            startLogo.color = new Color(startLogo.color.r, startLogo.color.g, startLogo.color.b, alpha);

            yield return null;
        }
    }
    // Resultへ突入
    IEnumerator InResultState()
    {
        StartCoroutine(MoveIN_UI(result));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveIN_UI(score));
        yield return new WaitForSeconds(1.0f);

        StartCoroutine(MoveIN_UI(ranks[0]));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveIN_UI(ranks[1]));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveIN_UI(ranks[2]));
        while(ranks[2].localPosition.x >= 0)
        {
            yield return null;
        }
        canSkip = true;
        yield return new WaitForSeconds(2.0f);

        state = StartCoroutine(OutResultState());
    }
    // UIの移動（右から左）
    IEnumerator MoveIN_UI(RectTransform ui)
    {
        float positionX = ui.localPosition.x;
        while (ui.localPosition.x >= 0)
        {
            ui.localPosition = new Vector3(positionX, ui.localPosition.y, ui.localPosition.z);
            positionX -= moveSpeed;
            yield return null;
        }
        ui.localPosition = new Vector3(0, ui.localPosition.y, ui.localPosition.z);
    }
    // リザルトが捌けていく
    IEnumerator OutResultState()
    {
        StartCoroutine(MoveOUT_UI(result));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveOUT_UI(score));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveOUT_UI(ranks[0]));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveOUT_UI(ranks[1]));
        yield return new WaitForSeconds(0.5f);

        StartCoroutine(MoveOUT_UI(ranks[2]));
        yield return new WaitForSeconds(2.0f);

        StartCoroutine(MoveIN_UI(titleLogo));
        while(titleLogo.localPosition.x >= 0)
        {
            yield return null;
        }
        state = StartCoroutine(TitleState());
    }
    // UIの移動（右から左）
    IEnumerator MoveOUT_UI(RectTransform ui)
    {
        float positionX = ui.localPosition.x;
        while (ui.localPosition.x >= -2000)
        {
            ui.localPosition = new Vector3(positionX, ui.localPosition.y, ui.localPosition.z);
            positionX -= moveSpeed;
            yield return null;
        }
    }

}
