using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class District : MonoBehaviour, IClickable
{
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = transform.position;
        endPos = transform.position + new Vector3 (0, 0.2f, 0);
    }

    public void OnPointer()
    {
        StopAllCoroutines();
        StartCoroutine(MoveUp());
    }

    public void OffPointer()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDown());
    }

    public void OnClick()
    {
        BackgroundManager.instance.BlackIn();
        InputManager.instance.disable = true;
        OffPointer();
    }

    IEnumerator MoveUp()
    {
        float lerpTime = 0.25f;
        float elapsedTime = 0f;
        Vector3 _startPos = transform.position;
        Vector3 targetPos = endPos;

        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPos, targetPos, elapsedTime / lerpTime);
            yield return null;
        }

        transform.position = targetPos;
    }

    IEnumerator MoveDown()
    {
        float lerpTime = 0.25f;
        float elapsedTime = 0f;
        Vector3 _startPos = transform.position;
        Vector3 targetPos = startPos;

        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPos, targetPos, elapsedTime / lerpTime);
            yield return null;
        }

        transform.position = targetPos;
    }
}
