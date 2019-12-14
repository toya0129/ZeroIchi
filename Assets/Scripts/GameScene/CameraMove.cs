using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 offset;     // 相対座標

    private IEnumerator MoveStart(Transform target_transform)
    {
        while (!GameController.GameEndFlag)
        {
            this.transform.position = target_transform.position + offset;
            yield return new WaitForSeconds(0.001f);
        }
        yield break;
    }

    public void SetTarget(Transform target)
    {
        offset = this.transform.position - target.position;
        StartCoroutine(MoveStart(target));
    }
}
